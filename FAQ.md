# ? FAQ - Czêsto zadawane pytania

## ?? Ogólne

### Czym jest ZgloszeniaApp?
ZgloszeniaApp to nowoczesna aplikacja webowa do zarz¹dzania zg³oszeniami, zbudowana w technologii Blazor WebAssembly z backendem ASP.NET Core Web API.

### Jakie technologie s¹ u¿ywane?
- **Frontend**: Blazor WebAssembly, Bootstrap 5
- **Backend**: ASP.NET Core 8, Entity Framework Core
- **Baza danych**: SQL Server
- **Uwierzytelnianie**: JWT + ASP.NET Core Identity

### Czy aplikacja jest darmowa?
Tak, kod Ÿród³owy jest dostêpny na licencji MIT.

---

## ?? Instalacja i konfiguracja

### Jakie s¹ wymagania systemowe?
- .NET 8 SDK
- SQL Server (LocalDB, Express lub pe³na wersja)
- Visual Studio 2022 lub VS Code (opcjonalnie)
- 4GB RAM minimum
- System Windows, Linux lub macOS

### Jak zainstalowaæ projekt?
1. Sklonuj repozytorium: `git clone https://github.com/...`
2. Uruchom skrypt instalacyjny: `./setup.ps1` (Windows) lub `./setup.sh` (Linux/Mac)
3. Lub wykonaj kroki manualne opisane w README.md

### B³¹d: "Unable to connect to database"
**Mo¿liwe przyczyny:**
1. SQL Server nie jest uruchomiony
2. Nieprawid³owy connection string w `appsettings.json`
3. Brak uprawnieñ do utworzenia bazy danych

**Rozwi¹zanie:**
- SprawdŸ czy SQL Server dzia³a
- Zweryfikuj connection string
- Upewnij siê ¿e u¿ytkownik ma uprawnienia do tworzenia baz danych

### Jak zmieniæ connection string?
Edytuj plik `ZgloszeniaApp.Backend/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Twoj-connection-string"
  }
}
```

### B³¹d: "dotnet ef command not found"
Zainstaluj narzêdzie Entity Framework:
```bash
dotnet tool install --global dotnet-ef
```

---

## ?? Uwierzytelnianie i bezpieczeñstwo

### Jakie s¹ domyœlne dane logowania?
- **Email**: admin@example.com
- **Has³o**: AdminHaslo123!

?? **WA¯NE**: Zmieñ has³o natychmiast po pierwszym logowaniu!

### Jak zresetowaæ has³o administratora?
1. Zaloguj siê jako administrator
2. PrzejdŸ do panelu u¿ytkowników
3. ZnajdŸ konto admina i zresetuj has³o

Lub bezpoœrednio w bazie danych:
```sql
UPDATE AspNetUsers 
SET PasswordHash = ... 
WHERE Email = 'admin@example.com'
```

### Jak d³ugo wa¿ny jest token JWT?
Domyœlnie token jest wa¿ny przez 24 godziny. Mo¿esz to zmieniæ w `AccountController.cs`:
```csharp
expires: DateTime.UtcNow.AddHours(24) // Zmieñ na swoj¹ wartoœæ
```

### Czy mogê zmieniæ klucz JWT?
Tak, i **powinieneœ** to zrobiæ w œrodowisku produkcyjnym! 

Edytuj `appsettings.json`:
```json
{
  "Jwt": {
    "Key": "Twój-super-bezpieczny-klucz-minimum-32-znaki"
  }
}
```

### Jak dodaæ now¹ rolê?
W `Program.cs` w sekcji inicjalizacji ról:
```csharp
string[] roleNames = { "Administrator", "User", "NowaRola" };
```

---

## ?? Rozwi¹zywanie problemów

### Aplikacja nie startuje - b³¹d kompilacji
1. SprawdŸ czy masz zainstalowany .NET 8 SDK
2. Uruchom: `dotnet restore`
3. Uruchom: `dotnet build`
4. SprawdŸ komunikaty b³êdów w Output

### Frontend nie ³¹czy siê z Backend
1. SprawdŸ czy Backend dzia³a (powinien byæ na https://localhost:7XXX)
2. SprawdŸ `appsettings.json` we Frontend:
   ```json
   {
     "ApiBaseUrl": "https://localhost:7XXX/"
   }
   ```
3. SprawdŸ CORS w Backend `Program.cs`

### "401 Unauthorized" przy ka¿dym ¿¹daniu
1. SprawdŸ czy token JWT jest zapisany w LocalStorage
2. SprawdŸ czy token nie wygas³
3. Wyloguj siê i zaloguj ponownie
4. SprawdŸ konfiguracjê JWT w Backend

### Zg³oszenia nie zapisuj¹ siê do bazy danych
1. SprawdŸ czy `SaveChangesAsync()` jest wywo³ane w kontrolerze
2. SprawdŸ logi b³êdów
3. SprawdŸ czy baza danych jest dostêpna
4. Zobacz szczegó³y w oryginalnym pytaniu u¿ytkownika (by³ to g³ówny problem!)

### B³¹d CORS
Dodaj konfiguracjê CORS w `Program.cs`:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

app.UseCors("AllowAll");
```

---

## ?? Funkcjonalnoœci

### Jak eksportowaæ zg³oszenia do Excel?
Funkcja dostêpna tylko dla administratorów:
1. Zaloguj siê jako admin
2. PrzejdŸ do strony zg³oszeñ
3. Kliknij przycisk "Eksport do Excel" (prawy dolny róg)

### Jak dodaæ nowe pole do zg³oszenia?
1. Dodaj w³aœciwoœæ w `Zgloszenie.cs` (Shared/Models)
2. Utwórz migracjê: `dotnet ef migrations add NazwaMigracji`
3. Zaktualizuj bazê: `dotnet ef database update`
4. Dodaj pole w formularzu `Zgloszenia.razor`

### Czy u¿ytkownicy mog¹ usuwaæ swoje zg³oszenia?
Tak, domyœlnie ka¿dy u¿ytkownik mo¿e usuwaæ swoje zg³oszenia.

### Jak ograniczyæ usuwanie tylko do administratorów?
W `ZgloszeniaController.cs` dodaj:
```csharp
[Authorize(Roles = "Administrator")]
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
```

---

## ?? Deployment i produkcja

### Jak wdro¿yæ aplikacjê na Azure?
1. Utwórz Azure App Service dla Backend
2. Utwórz Azure App Service dla Frontend
3. Utwórz Azure SQL Database
4. Skonfiguruj connection stringi
5. Deploy przez Visual Studio lub Azure DevOps

### Jak zabezpieczyæ klucze w produkcji?
U¿yj Azure Key Vault lub zmiennych œrodowiskowych:
```csharp
builder.Configuration["Jwt:Key"] = Environment.GetEnvironmentVariable("JWT_KEY");
```

### Czy mogê u¿ywaæ innej bazy danych ni¿ SQL Server?
Tak! Entity Framework Core wspiera:
- PostgreSQL
- MySQL
- SQLite
- Cosmos DB
- i inne...

Zmieñ provider w `Program.cs`:
```csharp
options.UseNpgsql(connectionString) // PostgreSQL
options.UseMySql(connectionString)  // MySQL
```

---

## ?? Rozwój

### Jak dodaæ nowy kontroler API?
1. Utwórz klasê w `Controllers/`
2. Dziedzicz po `ControllerBase`
3. Dodaj atrybut `[ApiController]` i `[Route("api/[controller]")]`
4. Dodaj metody z odpowiednimi atrybutami HTTP

### Jak dodaæ now¹ stronê Blazor?
1. Utwórz plik `.razor` w `Pages/`
2. Dodaj dyrektywê `@page "/nazwa-strony"`
3. Dodaj link w `NavMenu.razor`

### Jak testowaæ API?
U¿yj:
- Swagger (dostêpny pod `/swagger`)
- Postman
- cURL
- Thunder Client (VS Code extension)

### Jak w³¹czyæ Swagger?
W `Program.cs`:
```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

---

## ?? Dodatkowe zasoby

### Gdzie znajdê wiêcej dokumentacji?
- README.md - podstawowe informacje
- ARCHITECTURE.md - szczegó³y architektury
- CONTRIBUTING.md - jak pomóc w rozwoju
- SECURITY.md - bezpieczeñstwo

### Czy jest dostêpna dokumentacja API?
Po w³¹czeniu Swaggera: `https://localhost:7XXX/swagger`

### Gdzie zg³osiæ b³¹d?
Utwórz issue na GitHubie u¿ywaj¹c szablonu Bug Report.

### Gdzie zaproponowaæ now¹ funkcjê?
Utwórz issue na GitHubie u¿ywaj¹c szablonu Feature Request.

---

## ? Nie znalaz³eœ odpowiedzi?

1. SprawdŸ [Issues](https://github.com/twoja-nazwa/ZgloszeniaApp/issues) na GitHubie
2. Utwórz nowe issue z pytaniem
3. Skontaktuj siê z autorem: [email@example.com]

---

*Dokument jest regularnie aktualizowany. Ostatnia aktualizacja: 2024-12*
