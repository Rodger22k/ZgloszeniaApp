# ?? ZgloszeniaApp - System Zarz¹dzania Zg³oszeniami

Nowoczesna aplikacja webowa do zarz¹dzania zg³oszeniami, zbudowana w architekturze Blazor WebAssembly z ASP.NET Core Web API.

## ?? Opis projektu

ZgloszeniaApp to profesjonalny system do zarz¹dzania zg³oszeniami, który umo¿liwia u¿ytkownikom tworzenie, przegl¹danie i zarz¹dzanie zg³oszeniami. Aplikacja oferuje rozbudowany system uwierzytelniania i autoryzacji z rolami u¿ytkowników oraz funkcje administracyjne.

## ? Funkcjonalnoœci

### Dla u¿ytkowników:
- ?? Tworzenie nowych zg³oszeñ (tytu³, opis)
- ?? Przegl¹danie listy zg³oszeñ
- ??? Usuwanie w³asnych zg³oszeñ
- ?? Bezpieczne logowanie i rejestracja
- ?? Zarz¹dzanie swoim profilem

### Dla administratorów:
- ?? Zarz¹dzanie u¿ytkownikami
- ?? Resetowanie hase³ u¿ytkowników
- ?? Eksport wszystkich zg³oszeñ do pliku Excel
- ??? Pe³ny dostêp do wszystkich funkcji systemu

## ??? Architektura

Projekt sk³ada siê z trzech g³ównych komponentów:

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
- [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads) (LocalDB, Express lub pe³na wersja)
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

PrzejdŸ do folderu Backend i wykonaj migracjê:

```bash
cd ZgloszeniaApp.Backend
dotnet ef database update
```

### 4. Konfiguracja JWT

W pliku `ZgloszeniaApp.Backend/appsettings.json` znajduje siê konfiguracja JWT:

```json
{
  "Jwt": {
    "Key": "TwojaBardzoD³ugaIBezpiecznaTajnaWartoscKluczaJWT",
    "Issuer": "ZgloszeniaApp",
    "Audience": "ZgloszeniaApp"
  }
}
```

?? **WA¯NE**: W œrodowisku produkcyjnym zmieñ `Key` na silny, losowy klucz!

### 5. Uruchomienie aplikacji

#### Opcja A: Visual Studio
1. Otwórz plik `ZgloszeniaApp.sln`
2. Ustaw `ZgloszeniaApp.Backend` jako projekt startowy
3. Naciœnij F5 lub kliknij "Start"

#### Opcja B: Wiersz poleceñ

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

Aplikacja bêdzie dostêpna domyœlnie pod adresem: `https://localhost:7XXX`

## ?? Domyœlne konto administratora

Po pierwszym uruchomieniu aplikacji automatycznie tworzony jest administrator:

- **Email**: `admin@example.com`
- **Has³o**: `AdminHaslo123!`

?? **WA¯NE**: Zmieñ has³o administratora po pierwszym logowaniu!

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
?   ??? Excel/                 # Obs³uga eksportu do Excel
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

## ?? Bezpieczeñstwo

- **Uwierzytelnianie**: JWT Token-based authentication
- **Autoryzacja**: Role-based access control (Administrator, User)
- **Hashowanie hase³**: ASP.NET Core Identity (PBKDF2)
- **HTTPS**: Wymuszony protokó³ HTTPS
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
- `POST /api/Account/register` - Rejestracja nowego u¿ytkownika
- `POST /api/Account/login` - Logowanie

### Admin
- `GET /api/Admin/users` - Lista wszystkich u¿ytkowników (tylko admin)
- `POST /api/Admin/reset-password` - Reset has³a (tylko admin)

### Zgloszenia
- `GET /api/Zgloszenia` - Pobierz wszystkie zg³oszenia
- `GET /api/Zgloszenia/{id}` - Pobierz zg³oszenie po ID
- `POST /api/Zgloszenia` - Utwórz nowe zg³oszenie
- `DELETE /api/Zgloszenia/{id}` - Usuñ zg³oszenie
- `GET /api/Zgloszenia/ExportAllZgloszenia` - Eksport do Excel (tylko admin)

## ?? Wk³ad w projekt

Jeœli chcesz wnieœæ wk³ad w projekt:

1. Zforkuj repozytorium
2. Utwórz branch dla swojej funkcjonalnoœci (`git checkout -b feature/AmazingFeature`)
3. Commituj zmiany (`git commit -m 'Add some AmazingFeature'`)
4. Push do brancha (`git push origin feature/AmazingFeature`)
5. Otwórz Pull Request

## ?? Licencja

Ten projekt jest licencjonowany na zasadach licencji MIT - szczegó³y w pliku [LICENSE](LICENSE).

## ?? Kontakt

Twoje Imiê - [@twitter_handle](https://twitter.com/twitter_handle) - email@example.com

Link do projektu: [https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp](https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp)

## ?? Podziêkowania

- [Bootstrap](https://getbootstrap.com/)
- [Bootstrap Icons](https://icons.getbootstrap.com/)
- [EPPlus](https://www.epplussoftware.com/)
- [Blazor.DownloadFileFast](https://github.com/StefH/Blazor.DownloadFileFast)

---

? Jeœli podoba Ci siê ten projekt, zostaw gwiazdkê na GitHubie!
