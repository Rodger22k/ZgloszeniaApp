# ?? ZgloszeniaApp - System Zarządzania Zgłoszeniami

Nowoczesna aplikacja webowa do zarządzania zgłoszeniami, zbudowana w architekturze Blazor WebAssembly z ASP.NET Core Web API.

## ?? Opis projektu naukowego 

ZgloszeniaApp to system do zarządzania zgłoszeniami, który umożliwia użytkownikom tworzenie, przeglądanie i zarządzanie zgłoszeniami. Aplikacja oferuje rozbudowany system uwierzytelniania i autoryzacji z rolami użytkowników oraz funkcje administracyjne.

## ? Funkcjonalności

### Dla użytkowników:
- ?? Tworzenie nowych zgłoszeń (tytuł, opis)
- ?? Przeglądanie listy zgłoszeń
- ??? Usuwanie własnych zgłoszeń
- ?? Bezpieczne logowanie i rejestracja
- ?? Zarządzanie swoim profilem

### Dla administratorów:
- ?? Zarządzanie użytkownikami
- ?? Resetowanie haseł użytkowników
- ?? Eksport wszystkich zgłoszeń do pliku Excel
- ??? Pełny dostęp do wszystkich funkcji systemu

## ??? Architektura

Projekt składa się z trzech głównych komponentów:

```
ZgloszeniaApp/
??? ZgloszeniaApp.Frontend/    # Blazor WebAssembly (klient)
??? ZgloszeniaApp.Backend/     # ASP.NET Core Web API (serwer)
??? ZgloszeniaApp.Shared/      # Wspólne modele danych
```

### Frontend (Blazor WebAssembly)
- **Framework**: Blazor WebAssembly (.NET 8)
- **Uwierzytelnianie**: JWT Token-based authentication
- **UI**: Bootstrap 5 + Bootstrap Icons
- **Funkcje**: Pobieranie plików Excel (Blazor.DownloadFileFast)

### Backend (ASP.NET Core Web API)
- **Framework**: ASP.NET Core 8
- **Baza danych**: SQL Server + Entity Framework Core
- **Uwierzytelnianie**: ASP.NET Core Identity + JWT
- **Funkcje**: Generowanie plików Excel (EPPlus)
- **Monitoring**: Application Insights

### Shared
- **Modele**: DTOs i wspólne klasy wykorzystywane przez frontend i backend

## ?? Technologie

- **Backend**:
  - ASP.NET Core 8
  - Entity Framework Core
  - ASP.NET Core Identity
  - JWT Authentication
  - SQL Server
  - EPPlus (Excel)
  - Application Insights

- **Frontend**:
  - Blazor WebAssembly
  - Bootstrap 5
  - Bootstrap Icons
  - Blazor.DownloadFileFast

## ?? Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads) (LocalDB, Express lub pełna wersja)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) lub [Visual Studio Code](https://code.visualstudio.com/)

## ?? Instalacja i uruchomienie

### 1. Klonowanie repozytorium

```bash
git clone https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp.git
cd ZgloszeniaApp
```

### 2. Konfiguracja bazy danych

Otwórz `ZgloszeniaApp.Backend/appsettings.json` i skonfiguruj connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ZgloszeniaDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Migracja bazy danych

Przejdź do folderu Backend i wykonaj migrację:

```bash
cd ZgloszeniaApp.Backend
dotnet ef database update
```

### 4. Konfiguracja JWT

W pliku `ZgloszeniaApp.Backend/appsettings.json` znajduje się konfiguracja JWT:

```json
{
  "Jwt": {
    "Key": "TwojaBardzoDługaIBezpiecznaTajnaWartoscKluczaJWT",
    "Issuer": "ZgloszeniaApp",
    "Audience": "ZgloszeniaApp"
  }
}
```

?? **WAŻNE**: W środowisku produkcyjnym zmień `Key` na silny, losowy klucz!

### 5. Uruchomienie aplikacji

#### Opcja A: Visual Studio
1. Otwórz plik `ZgloszeniaApp.sln`
2. Ustaw `ZgloszeniaApp.Backend` jako projekt startowy
3. Naciśnij F5 lub kliknij "Start"

#### Opcja B: Wiersz poleceń

**Terminal 1 - Backend:**
```bash
cd ZgloszeniaApp.Backend
dotnet run
```

**Terminal 2 - Frontend:**
```bash
cd ZgloszeniaApp.Frontend
dotnet run
```

Aplikacja będzie dostępna domyślnie pod adresem: `https://localhost:7XXX`

## ?? Domyślne konto administratora

Po pierwszym uruchomieniu aplikacji automatycznie tworzony jest administrator:

- **Email**: `admin@example.com`
- **Hasło**: `AdminHaslo123!`

?? **WAŻNE**: Zmień hasło administratora po pierwszym logowaniu!

## ?? Struktura projektu

```
ZgloszeniaApp/
?
??? ZgloszeniaApp.Backend/
?   ??? Controllers/           # API endpoints
?   ?   ??? AccountController.cs
?   ?   ??? AdminController.cs
?   ?   ??? ZgloszeniaController.cs
?   ??? Data/                  # Entity Framework DbContext
?   ??? Excel/                 # Obsługa eksportu do Excel
?   ??? Migrations/            # Migracje bazy danych
?   ??? Models/                # Modele danych (ApplicationUser)
?   ??? Program.cs             # Konfiguracja aplikacji
?
??? ZgloszeniaApp.Frontend/
?   ??? Pages/                 # Strony Blazor
?   ?   ??? Home.razor
?   ?   ??? Login.razor
?   ?   ??? Register.razor
?   ?   ??? Users.razor
?   ?   ??? Zgloszenia.razor
?   ??? Services/              # Serwisy komunikacji z API
?   ??? Shared/                # Wspólne komponenty (NavMenu, MainLayout)
?   ??? wwwroot/               # Pliki statyczne
?
??? ZgloszeniaApp.Shared/
    ??? Models/                # Wspólne modele (DTOs)
        ??? LoginModel.cs
        ??? LoginResult.cs
        ??? RegisterModel.cs
        ??? UserDto.cs
        ??? ResetPasswordDto.cs
        ??? Zgloszenie.cs
```

## ?? Bezpieczeństwo

- **Uwierzytelnianie**: JWT Token-based authentication
- **Autoryzacja**: Role-based access control (Administrator, User)
- **Hashowanie haseł**: ASP.NET Core Identity (PBKDF2)
- **HTTPS**: Wymuszony protokół HTTPS
- **Walidacja**: DataAnnotations w modelach

## ?? Model danych

### Zgloszenie
```csharp
public class Zgloszenie
{
    public int Id { get; set; }
    public string Tytul { get; set; }
    public string Opis { get; set; }
    public DateTime DataUtworzenia { get; set; }
    public string? UserId { get; set; }
}
```

### ApplicationUser
Rozszerza standardowy `IdentityUser` z ASP.NET Core Identity.

## ?? API Endpoints

### Account
- `POST /api/Account/register` - Rejestracja nowego użytkownika
- `POST /api/Account/login` - Logowanie

### Admin
- `GET /api/Admin/users` - Lista wszystkich użytkowników (tylko admin)
- `POST /api/Admin/reset-password` - Reset hasła (tylko admin)

### Zgloszenia
- `GET /api/Zgloszenia` - Pobierz wszystkie zgłoszenia
- `GET /api/Zgloszenia/{id}` - Pobierz zgłoszenie po ID
- `POST /api/Zgloszenia` - Utwórz nowe zgłoszenie
- `DELETE /api/Zgloszenia/{id}` - Usuń zgłoszenie
- `GET /api/Zgloszenia/ExportAllZgloszenia` - Eksport do Excel (tylko admin)

## ?? Wkład w projekt

Jeśli chcesz wnieść wkład w projekt:

1. Zforkuj repozytorium
2. Utwórz branch dla swojej funkcjonalności (`git checkout -b feature/AmazingFeature`)
3. Commituj zmiany (`git commit -m 'Add some AmazingFeature'`)
4. Push do brancha (`git push origin feature/AmazingFeature`)
5. Otwórz Pull Request

## ?? Licencja

Ten projekt jest licencjonowany na zasadach licencji MIT - szczegóły w pliku [LICENSE](LICENSE).


## ?? Podziękowania

- [Bootstrap](https://getbootstrap.com/)
- [Bootstrap Icons](https://icons.getbootstrap.com/)
- [EPPlus](https://www.epplussoftware.com/)
- [Blazor.DownloadFileFast](https://github.com/StefH/Blazor.DownloadFileFast)

---

? Jeśli podoba Ci się ten projekt, zostaw gwiazdkę na GitHubie!
