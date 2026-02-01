using System;
using System.ComponentModel.DataAnnotations;

namespace ZgloszeniaApp.Shared.Models
{
    public class Zgloszenie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        public string Tytul { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        public string Opis { get; set; }

        public DateTime DataUtworzenia { get; set; } = DateTime.Now;

        public string? UserId { get; set; }

    }
}
