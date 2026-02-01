# ??? Szczegó³owa struktura projektu

```
ZgloszeniaApp/
?
??? ?? ZgloszeniaApp.Frontend/          # Blazor WebAssembly (Client)
?   ??? ?? Pages/                       # Strony Blazor
?   ?   ??? Home.razor                  # Strona g³ówna
?   ?   ??? Login.razor                 # Logowanie
?   ?   ??? Register.razor              # Rejestracja
?   ?   ??? Zgloszenia.razor            # Lista zg³oszeñ (+ dodawanie)
?   ?   ??? Users.razor                 # Zarz¹dzanie u¿ytkownikami (Admin)
?   ?
?   ??? ?? Services/                    # Serwisy HTTP
?   ?   ??? ZgloszenieService.cs        # Komunikacja z API zg³oszeñ
?   ?   ??? CustomAuthenticationStateProvider.cs # Zarz¹dzanie stanem autentykacji
?   ?
?   ??? ?? Shared/                      # Komponenty wspó³dzielone
?   ?   ??? MainLayout.razor            # G³ówny layout
?   ?   ??? NavMenu.razor               # Menu nawigacyjne
?   ?
?   ??? ?? wwwroot/                     # Pliki statyczne
?   ?   ??? ?? css/                     # Style CSS
?   ?   ?   ??? app.css                 # G³ówny plik stylów
?   ?   ??? ?? images/                  # Obrazy
?   ?   ?   ??? background.svg          # T³o strony
?   ?   ??? appsettings.json            # Konfiguracja (API URL)
?   ?   ??? appsettings.example.json    # Przyk³ad konfiguracji
?   ?   ??? index.html                  # Strona HTML (entry point)
?   ?
?   ??? App.razor                       # G³ówny komponent aplikacji
?   ??? Program.cs                      # Konfiguracja, DI, startup
?   ??? ZgloszeniaApp.Frontend.csproj   # Plik projektu
?
??? ?? ZgloszeniaApp.Backend/           # ASP.NET Core Web API (Server)
?   ??? ?? Controllers/                 # Kontrolery API
?   ?   ??? AccountController.cs        # Login, Rejestracja, JWT
?   ?   ??? AdminController.cs          # Funkcje administracyjne
?   ?   ??? ZgloszeniaController.cs     # CRUD zg³oszeñ, Eksport Excel
?   ?
?   ??? ?? Data/                        # Entity Framework
?   ?   ??? ApplicationDbContext.cs     # DbContext, konfiguracja tabel
?   ?
?   ??? ?? Excel/                       # Generowanie raportów
?   ?   ??? ExcelHelper.cs              # EPPlus - eksport do Excel
?   ?
?   ??? ?? Migrations/                  # Migracje Entity Framework
?   ?   ??? 20241210182648_IdentitySetup.cs
?   ?   ??? ApplicationDbContextModelSnapshot.cs
?   ?
?   ??? ?? Models/                      # Modele domenowe
?   ?   ??? ApplicationUser.cs          # Rozszerzony IdentityUser
?   ?
?   ??? appsettings.json                # Konfiguracja (ConnectionString, JWT)
?   ??? appsettings.example.json        # Przyk³ad konfiguracji
?   ??? appsettings.Development.json    # Konfiguracja dla dev
?   ??? Program.cs                      # Startup, middleware, DI
?   ??? ZgloszeniaApp.Backend.csproj    # Plik projektu
?
??? ?? ZgloszeniaApp.Shared/            # Biblioteka wspó³dzielona
?   ??? ?? Models/                      # DTOs i modele
?       ??? LoginModel.cs               # Model logowania
?       ??? LoginResult.cs              # Wynik logowania (token, expiry)
?       ??? RegisterModel.cs            # Model rejestracji
?       ??? UserDto.cs                  # DTO u¿ytkownika
?       ??? ResetPasswordDto.cs         # DTO resetowania has³a
?       ??? Zgloszenie.cs               # Model zg³oszenia
?
??? ?? .github/                         # GitHub
?   ??? ?? ISSUE_TEMPLATE/
?   ?   ??? bug_report.md               # Szablon zg³oszenia b³êdu
?   ?   ??? feature_request.md          # Szablon propozycji funkcji
?   ??? ?? workflows/
?   ?   ??? dotnet.yml.example          # Przyk³ad CI/CD
?   ??? PULL_REQUEST_TEMPLATE.md        # Szablon Pull Request
?
??? ?? README.md                        # ? G³ówna dokumentacja projektu
??? ?? LICENSE                          # Licencja MIT
??? ?? CONTRIBUTING.md                  # Wytyczne dla wspó³twórców
??? ?? CHANGELOG.md                     # Historia zmian
??? ?? SECURITY.md                      # Polityka bezpieczeñstwa
??? ?? ARCHITECTURE.md                  # Szczegó³owa architektura
??? ?? FAQ.md                           # Najczêœciej zadawane pytania
??? ?? QUICKSTART.md                    # Szybki przewodnik
??? ?? GITHUB_SETUP.md                  # Instrukcja dodania na GitHub
??? ?? CODE_OF_CONDUCT.md               # Kodeks postêpowania
??? ?? _PODSUMOWANIE_GITHUB.md          # To co w³aœnie czytasz! ??
?
??? ?? setup.ps1                        # Skrypt instalacyjny (Windows)
??? ?? setup.sh                         # Skrypt instalacyjny (Linux/Mac)
??? ?? .gitignore                       # Pliki ignorowane przez Git
?
??? ?? ZgloszeniaApp.sln                # Solution Visual Studio

```

## ?? Statystyki projektu

- **Liczba projektów**: 3 (Frontend, Backend, Shared)
- **Jêzyki**: C# 12, Razor, HTML, CSS, JavaScript
- **Framework**: .NET 8
- **Liczba kontrolerów**: 3
- **Liczba stron Blazor**: 5
- **Liczba serwisów**: 2
- **Liczba modeli**: 6

## ?? Kluczowe pliki do edycji

### Dla developerów:
1. **Controllers/** - dodawanie nowych API endpoints
2. **Pages/** - tworzenie nowych stron
3. **Models/** - definiowanie nowych modeli danych
4. **Services/** - komunikacja z API

### Dla konfiguracji:
1. **appsettings.json** - connection string, JWT, logging
2. **Program.cs** (Backend) - middleware, DI, autoryzacja
3. **Program.cs** (Frontend) - konfiguracja Blazor, HTTP client

### Dla dokumentacji:
1. **README.md** - g³ówny opis
2. **ARCHITECTURE.md** - architektura
3. **FAQ.md** - pytania i odpowiedzi

## ?? Stack technologiczny

### Frontend
- Blazor WebAssembly 8.0
- Bootstrap 5.3
- Bootstrap Icons
- Blazor.DownloadFileFast

### Backend
- ASP.NET Core 8.0
- Entity Framework Core
- ASP.NET Core Identity
- JWT Authentication
- EPPlus (Excel)
- Application Insights

### Database
- SQL Server
- LocalDB (development)
- Azure SQL (production)

### Tools
- Visual Studio 2022
- Git
- PowerShell/Bash
- dotnet CLI

---

*Struktura projektu wersja 1.0 - Ostatnia aktualizacja: Grudzieñ 2024*
