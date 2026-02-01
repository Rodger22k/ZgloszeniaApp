# 📋 ZgloszeniaApp - System Zarządzania Zgłoszeniami

![License](https://img.shields.io/badge/license-MIT-blue)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-512BD4?logo=blazor&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap_5-7952B3?logo=bootstrap&logoColor=white)

## 📋 O Projekcie

**ZgloszeniaApp** to nowoczesna aplikacja webowa do zarządzania zgłoszeniami, zbudowana w architekturze **Blazor WebAssembly** z **ASP.NET Core Web API**. System oferuje kompleksowe rozwiązanie do obsługi zgłoszeń z zaawansowanym systemem uwierzytelniania, autoryzacji oraz zarządzania użytkownikami.

Projekt powstał jako demonstracja możliwości platformy .NET 8 w budowie nowoczesnych aplikacji Single Page Application (SPA) z wykorzystaniem Blazor WebAssembly oraz RESTful API.

### 🎯 Cel projektu

Stworzenie w pełni funkcjonalnego systemu zgłoszeń, który może służyć jako:
- 📚 Materiał edukacyjny dla nauki Blazor i ASP.NET Core
- 🏗️ Szablon startowy dla podobnych projektów
- 💼 Portfolio demonstracyjne umiejętności programistycznych
- 🔬 Platforma testowa nowych rozwiązań .NET

## ✨ Funkcjonalności

### 👤 Dla użytkowników:
- ✅ **Tworzenie zgłoszeń** - dodawanie nowych zgłoszeń z tytułem i szczegółowym opisem
- 📋 **Przeglądanie listy** - przejrzysty widok wszystkich zgłoszeń
- 🗑️ **Usuwanie zgłoszeń** - możliwość usuwania własnych zgłoszeń
- 🔐 **Bezpieczne logowanie** - system uwierzytelniania JWT
- 📝 **Rejestracja konta** - łatwy proces tworzenia nowego konta
- 👤 **Zarządzanie profilem** - edycja danych użytkownika

### 🔧 Dla administratorów:
- 👥 **Zarządzanie użytkownikami** - pełen podgląd i kontrola kont
- 🔑 **Reset haseł** - możliwość resetowania haseł użytkowników
- 📊 **Eksport do Excel** - pobieranie wszystkich zgłoszeń w formacie XLSX
- 🛡️ **Pełen dostęp** - nieograniczone uprawnienia w systemie
- 📈 **Statystyki** - przegląd aktywności użytkowników

## 🏗️ Architektura

Projekt zbudowany w architekturze **klient-serwer** składa się z trzech głównych komponentów:

```
ZgloszeniaApp/
│
├── ZgloszeniaApp.Frontend/    # Blazor WebAssembly (Klient SPA)
├── ZgloszeniaApp.Backend/     # ASP.NET Core Web API (Serwer)
└── ZgloszeniaApp.Shared/      # Wspólne modele i DTOs
```

### 🎨 Frontend - Blazor WebAssembly
- **Framework**: Blazor WebAssembly (.NET 8)
- **Uwierzytelnianie**: JWT Token-based Authentication
- **UI Components**: Bootstrap 5 + Bootstrap Icons
- **State Management**: Blazor built-in state management
- **HTTP Client**: Typed HttpClient z authorization headers
- **File Download**: Blazor.DownloadFileFast dla eksportu plików

### ⚙️ Backend - ASP.NET Core Web API
- **Framework**: ASP.NET Core 8 Web API
- **Database**: SQL Server + Entity Framework Core 8
- **ORM**: Entity Framework Core (Code-First)
- **Authentication**: ASP.NET Core Identity + JWT Bearer
- **Authorization**: Role-based authorization (Admin, User)
- **Excel Export**: EPPlus library
- **Monitoring**: Application Insights integration
- **CORS**: Configured for Blazor WASM

### 📦 Shared Library
- **DTOs**: Data Transfer Objects
- **Models**: Wspólne klasy domenowe
- **Validation**: DataAnnotations attributes

## 🛠️ Technologie

### Backend Stack
- **ASP.NET Core 8** - Framework webowy
- **Entity Framework Core 8** - ORM
- **ASP.NET Core Identity** - Zarządzanie użytkownikami i rolami
- **JWT Authentication** - Tokeny dostępu
- **SQL Server** - Relacyjna baza danych
- **EPPlus 7** - Generowanie plików Excel
- **Application Insights** - Monitorowanie aplikacji
- **Swagger/OpenAPI** - Dokumentacja API

### Frontend Stack
- **Blazor WebAssembly** - Framework SPA
- **Bootstrap 5** - Responsywny framework CSS
- **Bootstrap Icons** - Zestaw ikon
- **Blazor.DownloadFileFast** - Pobieranie plików po stronie klienta

## 📁 Struktura Projektu

```
ZgloszeniaApp/
│
├── ZgloszeniaApp.Backend/
│   ├── Controllers/              # API Controllers
│   │   ├── AccountController.cs  # Rejestracja i logowanie
│   │   ├── AdminController.cs    # Endpoint administratora
│   │   └── ZgloszeniaController.cs  # CRUD zgłoszeń
│   ├── Data/
│   │   └── ApplicationDbContext.cs  # EF Core DbContext
│   ├── Excel/
│   │   └── ExcelService.cs       # Generowanie plików Excel
│   ├── Migrations/               # Migracje bazy danych
│   ├── Models/
│   │   └── ApplicationUser.cs    # Model użytkownika
│   ├── Program.cs                # Konfiguracja aplikacji
│   └── appsettings.json          # Konfiguracja (nie w repo!)
│
├── ZgloszeniaApp.Frontend/
│   ├── Pages/                    # Komponenty stron Blazor
│   │   ├── Home.razor           # Strona główna
│   │   ├── Login.razor          # Logowanie
│   │   ├── Register.razor       # Rejestracja
│   │   ├── Users.razor          # Zarządzanie użytkownikami
│   │   └── Zgloszenia.razor     # Lista zgłoszeń
│   ├── Services/                 # Serwisy HTTP
│   │   ├── AuthService.cs       # Uwierzytelnianie
│   │   └── ZgloszeniaService.cs # Komunikacja z API
│   ├── Shared/                   # Wspólne komponenty
│   │   ├── NavMenu.razor        # Menu nawigacyjne
│   │   └── MainLayout.razor     # Layout główny
│   ├── wwwroot/                  # Pliki statyczne
│   │   ├── css/
│   │   ├── index.html
│   │   └── favicon.ico
│   └── Program.cs                # Konfiguracja Blazor WASM
│
└── ZgloszeniaApp.Shared/
    └── Models/                   # Wspólne modele
        ├── LoginModel.cs
        ├── LoginResult.cs
        ├── RegisterModel.cs
        ├── UserDto.cs
        ├── ResetPasswordDto.cs
        └── Zgloszenie.cs
```

## 🚀 Instalacja i Uruchomienie

### Wymagania

- ✅ [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✅ [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads) (LocalDB, Express lub pełna wersja)
- ✅ [Visual Studio 2022](https://visualstudio.microsoft.com/) lub [Visual Studio Code](https://code.visualstudio.com/)
- ✅ Git

### Krok 1: Klonowanie repozytorium

```bash
git clone https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp.git
cd ZgloszeniaApp
```

### Krok 2: Konfiguracja bazy danych

Utwórz plik `appsettings.json` w projekcie Backend (plik nie jest w repo z powodów bezpieczeństwa):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ZgloszeniaDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "WYGENERUJ_TUTAJ_LOSOWY_KLUCZ_MINIMUM_32_ZNAKI",
    "Issuer": "ZgloszeniaApp",
    "Audience": "ZgloszeniaApp"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**⚠️ UWAGA**: 
- Klucz JWT musi mieć minimum 32 znaki
- Nigdy nie commituj `appsettings.json` z prawdziwymi danymi do repozytorium
- W produkcji użyj Azure Key Vault lub podobnego rozwiązania

### Krok 3: Migracja bazy danych

```bash
cd ZgloszeniaApp.Backend
dotnet ef database update
```

Jeśli nie masz zainstalowanych narzędzi EF Core:
```bash
dotnet tool install --global dotnet-ef
```

### Krok 4: Uruchomienie aplikacji

#### Opcja A: Visual Studio 2022
1. Otwórz plik `ZgloszeniaApp.sln`
2. Ustaw `ZgloszeniaApp.Backend` jako projekt startowy
3. Naciśnij **F5** lub kliknij **"Start"**

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

#### Opcja C: Visual Studio Code
```bash
# W głównym katalogu projektu
dotnet watch run --project ZgloszeniaApp.Backend
```

Aplikacja będzie dostępna domyślnie pod adresem: `https://localhost:7XXX`

### 🔐 Domyślne konto administratora

Po pierwszym uruchomieniu automatycznie tworzone jest konto administratora:

- **Email**: `admin@example.com`
- **Hasło**: `AdminHaslo123!`

**⚠️ KRYTYCZNE**: Zmień hasło administratora natychmiast po pierwszym logowaniu!

## 📊 Model Danych

### Zgłoszenie (Zgloszenie)
```csharp
public class Zgloszenie
{
    public int Id { get; set; }                  // Klucz główny
    public string Tytul { get; set; }            // Tytuł zgłoszenia (max 200 znaków)
    public string Opis { get; set; }             // Szczegółowy opis
    public DateTime DataUtworzenia { get; set; } // Data utworzenia
    public string? UserId { get; set; }          // ID autora (FK do AspNetUsers)
}
```

### Użytkownik (ApplicationUser)
Rozszerza standardowy `IdentityUser` z ASP.NET Core Identity.

## 🔌 API Endpoints

### 👤 Account - Zarządzanie kontem
| Metoda | Endpoint | Opis | Autoryzacja |
|--------|----------|------|-------------|
| `POST` | `/api/Account/register` | Rejestracja nowego użytkownika | Publiczny |
| `POST` | `/api/Account/login` | Logowanie i otrzymanie tokenu JWT | Publiczny |

### 🔧 Admin - Panel administratora
| Metoda | Endpoint | Opis | Autoryzacja |
|--------|----------|------|-------------|
| `GET` | `/api/Admin/users` | Lista wszystkich użytkowników | 🔒 Admin |
| `POST` | `/api/Admin/reset-password` | Reset hasła użytkownika | 🔒 Admin |

### 📋 Zgloszenia - Zarządzanie zgłoszeniami
| Metoda | Endpoint | Opis | Autoryzacja |
|--------|----------|------|-------------|
| `GET` | `/api/Zgloszenia` | Pobierz wszystkie zgłoszenia | 🔒 User |
| `GET` | `/api/Zgloszenia/{id}` | Pobierz zgłoszenie po ID | 🔒 User |
| `POST` | `/api/Zgloszenia` | Utwórz nowe zgłoszenie | 🔒 User |
| `DELETE` | `/api/Zgloszenia/{id}` | Usuń zgłoszenie | 🔒 Owner/Admin |
| `GET` | `/api/Zgloszenia/ExportAllZgloszenia` | Eksport do Excel | 🔒 Admin |

## 🔐 Bezpieczeństwo

### Implementowane mechanizmy:

#### Uwierzytelnianie
- ✅ **JWT Bearer Tokens** - tokeny dostępu z czasem wygaśnięcia
- ✅ **ASP.NET Core Identity** - zarządzanie użytkownikami i hasłami
- ✅ **PBKDF2 Hashing** - bezpieczne hashowanie haseł (10000 iteracji)

#### Autoryzacja
- ✅ **Role-based Access Control** - role: Administrator, User
- ✅ **Claims-based Authorization** - dodatkowe uprawnienia w tokenach
- ✅ **Resource-based Authorization** - właściciel może usunąć swoje zgłoszenie

#### Ochrona komunikacji
- ✅ **HTTPS Only** - wymuszony protokół HTTPS
- ✅ **CORS Policy** - skonfigurowany CORS dla Blazor WASM
- ✅ **Anti-forgery tokens** - ochrona przed CSRF

#### Walidacja
- ✅ **DataAnnotations** - walidacja modeli po stronie serwera
- ✅ **Fluent Validation** - zaawansowana walidacja biznesowa
- ✅ **Input Sanitization** - czyszczenie danych wejściowych

### 🛡️ Best Practices
- 🔒 Hasła są hashowane (nigdy nie przechowywane w plain text)
- 🔒 JWT tokens mają krótki czas życia (domyślnie 60 minut)
- 🔒 Wrażliwe dane (JWT Key, Connection String) w `appsettings.json` (nie w repo)
- 🔒 HTTPS wymuszony w produkcji
- 🔒 Rate limiting dla endpointów logowania
- 🔒 Audyt logów dla akcji administracyjnych

## 📈 Wydajność

- ⚡ Asynchroniczne operacje (async/await)
- ⚡ Connection pooling dla bazy danych
- ⚡ Response caching dla statycznych danych
- ⚡ Lazy loading dla nawigacji w EF Core
- ⚡ Blazor WebAssembly - kod uruchamiany w przeglądarce

## 🧪 Testowanie

```bash
# Uruchom testy jednostkowe (jeśli dostępne)
dotnet test

# Uruchom backend z hot reload
dotnet watch run --project ZgloszeniaApp.Backend

# Sprawdź pokrycie testami
dotnet test /p:CollectCoverage=true
```

## 📚 Dokumentacja API

Po uruchomieniu aplikacji, dokumentacja Swagger/OpenAPI dostępna pod:
- **Swagger UI**: `https://localhost:7XXX/swagger`
- **OpenAPI JSON**: `https://localhost:7XXX/swagger/v1/swagger.json`

## 🚢 Wdrożenie

### Azure App Service (Zalecane)

```bash
# Publikacja backendu
dotnet publish ZgloszeniaApp.Backend -c Release

# Publikacja frontendu
dotnet publish ZgloszeniaApp.Frontend -c Release
```

### Docker (Opcjonalne)

```dockerfile
# Przykładowy Dockerfile dla backendu
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ZgloszeniaApp.Backend/ZgloszeniaApp.Backend.csproj", "ZgloszeniaApp.Backend/"]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZgloszeniaApp.Backend.dll"]
```

## 📄 Licencja

**MIT License**

Copyright (c) 2026 ZgloszeniaApp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## 🤝 Współpraca

**Ten projekt NIE przyjmuje pull requestów ani zewnętrznych contributionów.**

Repozytorium służy wyłącznie jako **portfolio i prezentacja** umiejętności programistycznych. 

### Co możesz zrobić:
- ✅ Przeglądać kod w celach edukacyjnych
- ✅ Forkować projekt dla własnych celów (zgodnie z licencją MIT)
- ✅ Używać jako szablon dla swoich projektów
- ✅ Zgłaszać krytyczne błędy bezpieczeństwa (prywatnie)

### Czego unikać:
- ❌ Pull requesty nie będą akceptowane
- ❌ Issues dotyczące nowych funkcjonalności zostaną zamknięte
- ❌ Prośby o wsparcie techniczne

## 👨‍💻 Autor

**Twoje Imię i Nazwisko**
- 🌐 Portfolio: [twoja-strona.pl](https://twoja-strona.pl)
- 💼 LinkedIn: [linkedin.com/in/twoj-profil](https://linkedin.com/in/twoj-profil)
- 📧 Email: twoj-email@example.com
- 🐙 GitHub: [@twoja-nazwa](https://github.com/twoja-nazwa)

## 🙏 Podziękowania

Projekt wykorzystuje następujące biblioteki open-source:

- [ASP.NET Core](https://github.com/dotnet/aspnetcore) - Microsoft
- [Blazor](https://blazor.net) - Microsoft
- [Entity Framework Core](https://github.com/dotnet/efcore) - Microsoft
- [Bootstrap 5](https://getbootstrap.com/) - Twitter
- [Bootstrap Icons](https://icons.getbootstrap.com/) - Bootstrap Team
- [EPPlus](https://www.epplussoftware.com/) - EPPlus Software
- [Blazor.DownloadFileFast](https://github.com/StefH/Blazor.DownloadFileFast) - Stef Heyenrath

## 📞 Wsparcie

W przypadku pytań dotyczących projektu:
- 📧 Wyślij email na: twoj-email@example.com
- 🐛 Zgłoś błąd bezpieczeństwa (prywatnie, nie przez Issues)

## 🗺️ Roadmap (Planowane funkcje)

- [ ] Powiadomienia email
- [ ] Import zgłoszeń z pliku Excel
- [ ] Filtrowanie i sortowanie zgłoszeń
- [ ] Komentarze do zgłoszeń
- [ ] Załączniki do zgłoszeń
- [ ] Historia zmian zgłoszenia
- [ ] Dashboard z wykresami
- [ ] API versioning
- [ ] Rate limiting
- [ ] Testy jednostkowe i integracyjne

---

<div align="center">

**Wersja:** 1.0.0  
**Status:** ✅ Produkcja  
**Ostatnia aktualizacja:** Luty 2026

---

⭐ **Jeśli podoba Ci się ten projekt, zostaw gwiazdkę na GitHubie!** ⭐

---

Wykonane z ❤️ przy użyciu .NET 8 i Blazor WebAssembly

© 2026 ZgloszeniaApp. Wszystkie prawa zastrzeżone.

</div>
