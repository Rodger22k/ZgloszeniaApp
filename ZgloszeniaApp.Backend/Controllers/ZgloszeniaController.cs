using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZgloszeniaApp.Backend.Data;
using ZgloszeniaApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ZgloszeniaApp.Backend.Excel;
using System.Data;

namespace ZgloszeniaApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZgloszeniaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ZgloszeniaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Zgloszenia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zgloszenie>>> GetZgloszenia()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (User.IsInRole("Administrator"))
            {
                return await _context.Zgloszenia.ToListAsync();
            }
            else
            {
                return await _context.Zgloszenia
                    .Where(z => z.UserId == userId)
                    .ToListAsync();
            }
        }

        // GET: api/Zgloszenia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zgloszenie>> GetZgloszenie(int id)
        {
            var zgloszenie = await _context.Zgloszenia.FindAsync(id);

            if (zgloszenie == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (zgloszenie.UserId != userId && !User.IsInRole("Administrator"))
            {
                return Forbid();
            }

            return zgloszenie;
        }

        // PUT: api/Zgloszenia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZgloszenie(int id, Zgloszenie zgloszenie)
        {
            if (id != zgloszenie.Id)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (zgloszenie.UserId != userId && !User.IsInRole("Administrator"))
            {
                return Forbid();
            }

            _context.Entry(zgloszenie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZgloszenieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Zgloszenia
        [HttpPost]
        public async Task<ActionResult<Zgloszenie>> PostZgloszenie(Zgloszenie zgloszenie)
        {
            zgloszenie.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Zgloszenia.Add(zgloszenie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZgloszenie", new { id = zgloszenie.Id }, zgloszenie);
        }

        // DELETE: api/Zgloszenia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZgloszenie(int id)
        {
            var zgloszenie = await _context.Zgloszenia.FindAsync(id);
            if (zgloszenie == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (zgloszenie.UserId != userId && !User.IsInRole("Administrator"))
            {
                return Forbid();
            }

            _context.Zgloszenia.Remove(zgloszenie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZgloszenieExists(int id)
        {
            return _context.Zgloszenia.Any(e => e.Id == id);
        }

        [HttpGet("ExportAllZgloszenia")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ExportAllZgloszenia()
        {
            // 1. Pobierz listę zgłoszeń
            var lista = await _context.Zgloszenia.ToListAsync();

            // 2. Zamień na DataTable
            DataTable dt = new DataTable("Zgloszenia");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Tytul", typeof(string));
            dt.Columns.Add("Opis", typeof(string));
            dt.Columns.Add("DataUtworzenia", typeof(DateTime));
            dt.Columns.Add("UserId", typeof(string));

            foreach (var z in lista)
            {
                dt.Rows.Add(z.Id, z.Tytul, z.Opis, z.DataUtworzenia, z.UserId);
            }

            // 3. Stwórz plik tymczasowy
            string tempFile = Path.GetTempFileName();
            ExcelHelper.CreateExcelFile(dt, tempFile);

            // 4. Wczytaj bajty z pliku
            var fileBytes = System.IO.File.ReadAllBytes(tempFile);
            System.IO.File.Delete(tempFile);

            // 5. Zwróć plik Excel
            return File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Zgloszenia.xlsx"
            );
        }

        [HttpPost("ImportZgloszenia")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ImportZgloszenia(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return BadRequest("Nie wybrano pliku lub plik jest pusty.");
            }

            // 1. Zapis pliku do tymczasowego folderu
            string tempFile = Path.GetTempFileName();
            using (var stream = new FileStream(tempFile, FileMode.Create))
            {
                await excelFile.CopyToAsync(stream);
            }

            DataTable dt;
            try
            {
                // 2. Odczyt pliku Excel do DataTable
                dt = ExcelHelper.ReadExcelSheet(tempFile, firstRowIsHeader: true);

                // (Jeśli w Helperze jest inna metoda, dopasuj)
            }
            catch (Exception ex)
            {
                System.IO.File.Delete(tempFile);
                return BadRequest($"Błąd przetwarzania pliku: {ex.Message}");
            }

            // 3. Mapowanie wierszy DataTable na obiekty "Zgloszenie"
            // Upewnij się, że w arkuszu masz kolumny: Tytul, Opis, DataUtworzenia, itp.
            
            int dodanych = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (!dt.Columns.Contains("Tytul") || !dt.Columns.Contains("Opis"))
                {
                    System.IO.File.Delete(tempFile);
                    return BadRequest("W pliku Excel brakuje kolumn 'Tytul' i/lub 'Opis'.");
                }

                var zgl = new Zgloszenie
                {
                    Tytul = row["Tytul"]?.ToString(),
                    Opis = row["Opis"]?.ToString(),
                    
                };

                // Obsługa DataUtworzenia (opcjonalnie)
                if (dt.Columns.Contains("DataUtworzenia"))
                {
                    if (DateTime.TryParse(row["DataUtworzenia"]?.ToString(), out DateTime dtUtw))
                    {
                        zgl.DataUtworzenia = dtUtw;
                    }
                }

                if (dt.Columns.Contains("UserId"))
                {
                    zgl.UserId = row["UserId"]?.ToString();
                }


                // Dodajemy do kontekstu
                _context.Zgloszenia.Add(zgl);
                dodanych++;
            }

            await _context.SaveChangesAsync();

            // 4. Usunięcie pliku tymczasowego
            System.IO.File.Delete(tempFile);

            return Ok($"Zaimportowano {dodanych} zgłoszeń.");
        }




    }
}
