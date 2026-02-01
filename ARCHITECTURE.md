# ??? Architektura Projektu ZgloszeniaApp

## ?? Architektura ogólna

Projekt ZgloszeniaApp jest zbudowany w architekturze klient-serwer wykorzystuj¹cej:

```
???????????????????????????????????????????????????????????????
?                    Blazor WebAssembly                        ?
?                      (Frontend)                              ?
?  ??????????????  ??????????????  ??????????????            ?
?  ?   Pages    ?  ?  Services  ?  ?   Shared   ?            ?
?  ?  (Razor)   ?  ?   (API)    ?  ? Components ?            ?
?  ??????????????  ??????????????  ??????????????            ?
???????????????????????????????????????????????????????????????
                            ?
                            ? HTTPS / JWT
                            ?
???????????????????????????????????????????????????????????????
?                   ASP.NET Core Web API                       ?
?                       (Backend)                              ?
?  ??????????????  ??????????????  ??????????????            ?
?  ?Controllers ?  ?   Models   ?  ?    Data    ?            ?
?  ?   (API)    ?  ?  (Domain)  ?  ?  (DbCtx)   ?            ?
?  ??????????????  ??????????????  ??????????????            ?
???????????????????????????????????????????????????????????????
                            ?
                            ? Entity Framework Core
                            ?
                    ?????????????????
                    ?  SQL Server   ?
                    ?   Database    ?
                    ?????????????????
```

## ?? Komponenty projektu

### 1. **ZgloszeniaApp.Frontend** (Blazor WebAssembly)

#### Struktura folderów:
```
Frontend/
??? Pages/                    # Strony Blazor (komponenty routowane)
?   ??? Home.razor           # Strona g³ówna
?   ??? Login.razor          # Strona logowania
?   ??? Register.razor       # Rejestracja u¿ytkownika
?   ??? Zgloszenia.razor     # Lista zg³oszeñ
?   ??? Users.razor          # Panel zarz¹dzania u¿ytkownikami (Admin)
??? Services/                 # Serwisy do komunikacji z API
?   ??? ZgloszenieService.cs # Obs³uga zg³oszeñ
?   ??? CustomAuthenticationStateProvider.cs # Zarz¹dzanie stanem uwierzytelnienia
??? Shared/                   # Wspó³dzielone komponenty
?   ??? MainLayout.razor     # G³ówny layout aplikacji
?   ??? NavMenu.razor        # Menu nawigacyjne
??? wwwroot/                  # Pliki statyczne
?   ??? css/                 # Style CSS
?   ??? images/              # Obrazy
?   ??? appsettings.json     # Konfiguracja frontendu
??? App.razor                 # G³ówny komponent aplikacji
??? Program.cs               # Punkt wejœcia, konfiguracja DI
```

#### Odpowiedzialnoœci:
- **Warstwa prezentacji** (UI/UX)
- Komunikacja z API przez HTTP
- Zarz¹dzanie stanem uwierzytelnienia (JWT)
- Walidacja danych po stronie klienta

#### Technologie:
- Blazor WebAssembly (.NET 8)
- Bootstrap 5
- Bootstrap Icons
- Blazor.DownloadFileFast

---

### 2. **ZgloszeniaApp.Backend** (ASP.NET Core Web API)

#### Struktura folderów:
```
Backend/
??? Controllers/              # API Endpoints
?   ??? AccountController.cs # Rejestracja, logowanie
?   ??? AdminController.cs   # Funkcje administracyjne
?   ??? ZgloszeniaController.cs # CRUD zg³oszeñ
??? Data/                     # Warstwa dostêpu do danych
?   ??? ApplicationDbContext.cs # Entity Framework DbContext
??? Excel/                    # Obs³uga eksportu do Excel
?   ??? ExcelHelper.cs       # Generator plików Excel
??? Migrations/               # Migracje Entity Framework
??? Models/                   # Modele domenowe
?   ??? ApplicationUser.cs   # Model u¿ytkownika (rozszerza IdentityUser)
??? appsettings.json         # Konfiguracja (connection string, JWT)
??? Program.cs               # Konfiguracja aplikacji, middleware, DI
```

#### Odpowiedzialnoœci:
- **Logika biznesowa**
- Uwierzytelnianie i autoryzacja (JWT)
- Dostêp do bazy danych (EF Core)
- Walidacja danych po stronie serwera
- Generowanie raportów Excel

#### Technologie:
- ASP.NET Core 8
- Entity Framework Core
- ASP.NET Core Identity
- JWT Bearer Authentication
- EPPlus (Excel generation)
- SQL Server

---

### 3. **ZgloszeniaApp.Shared** (Biblioteka klas)

#### Struktura folderów:
```
Shared/
??? Models/                   # Modele wspó³dzielone
    ??? LoginModel.cs        # Model logowania
    ??? LoginResult.cs       # Wynik logowania (token, expiration)
    ??? RegisterModel.cs     # Model rejestracji
    ??? UserDto.cs           # DTO u¿ytkownika
    ??? ResetPasswordDto.cs  # DTO resetowania has³a
    ??? Zgloszenie.cs        # Model zg³oszenia
```

#### Odpowiedzialnoœci:
- **Data Transfer Objects (DTOs)**
- Modele wspó³dzielone miêdzy frontendem a backendem
- Atrybuty walidacji (Data Annotations)

---

## ?? Przep³yw uwierzytelniania

```
1. U¿ytkownik wprowadza login/has³o
                ?
                ?
2. Frontend ? POST /api/Account/login
                ?
                ?
3. Backend weryfikuje dane (Identity)
                ?
                ?
4. Backend generuje JWT Token
                ?
                ?
5. Frontend zapisuje token w LocalStorage
                ?
                ?
6. Ka¿de kolejne ¿¹danie zawiera token w nag³ówku:
   Authorization: Bearer {token}
                ?
                ?
7. Backend waliduje token przy ka¿dym ¿¹daniu
```

## ?? Model bazy danych

### Tabele:

#### **Zgloszenia**
```sql
CREATE TABLE Zgloszenia (
    Id INT PRIMARY KEY IDENTITY,
    Tytul NVARCHAR(MAX) NOT NULL,
    Opis NVARCHAR(MAX) NOT NULL,
    DataUtworzenia DATETIME2 NOT NULL,
    UserId NVARCHAR(450) NULL,
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
)
```

#### **AspNetUsers** (Identity)
- Standardowe tabele ASP.NET Core Identity:
  - AspNetUsers
  - AspNetRoles
  - AspNetUserRoles
  - AspNetUserClaims
  - AspNetUserLogins
  - AspNetUserTokens
  - AspNetRoleClaims

### Relacje:
- **Zgloszenie** ? **ApplicationUser** (Many-to-One)
  - Jedno zg³oszenie nale¿y do jednego u¿ytkownika
  - U¿ytkownik mo¿e mieæ wiele zg³oszeñ

## ?? Przep³yw danych (przyk³ad: dodanie zg³oszenia)

```
1. U¿ytkownik wype³nia formularz w Zgloszenia.razor
                ?
                ?
2. Frontend wywo³uje ZgloszenieService.AddZgloszenie()
                ?
                ?
3. Service wysy³a POST /api/Zgloszenia z JWT tokenem
                ?
                ?
4. Backend (ZgloszeniaController) otrzymuje request
                ?
                ?
5. [Authorize] weryfikuje token JWT
                ?
                ?
6. Controller waliduje model (DataAnnotations)
                ?
                ?
7. EF Core dodaje zg³oszenie do DbContext
                ?
                ?
8. SaveChangesAsync() zapisuje do SQL Server
                ?
                ?
9. Backend zwraca utworzone zg³oszenie (201 Created)
                ?
                ?
10. Frontend aktualizuje UI i dodaje zg³oszenie do listy
```

## ??? Warstwy bezpieczeñstwa

### 1. **Uwierzytelnianie (Authentication)**
- JWT Bearer Tokens
- Token expiration (configurable)
- Secure token storage (LocalStorage)

### 2. **Autoryzacja (Authorization)**
- Role-based access control:
  - **User**: Podstawowe operacje (CRUD w³asnych zg³oszeñ)
  - **Administrator**: Pe³ny dostêp + zarz¹dzanie u¿ytkownikami

### 3. **Walidacja**
- **Client-side**: Data Annotations + Blazor Forms
- **Server-side**: Data Annotations + Model State validation

### 4. **Bezpieczeñstwo danych**
- Password hashing (PBKDF2 via Identity)
- HTTPS enforcement
- SQL Injection prevention (EF Core parametrized queries)
- XSS prevention (Blazor automatic escaping)

## ?? Dependency Injection

### Frontend:
```csharp
builder.Services.AddScoped<ZgloszenieService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IBlazorDownloadFileService, BlazorDownloadFileService>();
```

### Backend:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddControllers();
```

## ?? Lifecycle i State Management

### Frontend (Blazor):
- **Component Lifecycle**:
  - OnInitialized / OnInitializedAsync
  - OnParametersSet / OnParametersSetAsync
  - OnAfterRender / OnAfterRenderAsync

- **State Management**:
  - Component-local state (private fields)
  - AuthenticationState (global)
  - LocalStorage dla JWT token

### Backend:
- **Scoped**: DbContext (per-request)
- **Transient**: Controllers (per-request)
- **Singleton**: Configuration

## ?? Deployment Architecture

```
Production Environment:
????????????????????????
?   Azure App Service  ?
?    (Frontend WASM)   ?
????????????????????????
           ?
           ? HTTPS
           ?
????????????????????????
?   Azure App Service  ?
?    (Backend API)     ?
????????????????????????
           ?
           ? Encrypted Connection
           ?
????????????????????????
?   Azure SQL Database ?
????????????????????????
```

## ?? Mo¿liwe rozszerzenia

1. **Caching**: Redis dla sesji i danych czêsto odczytywanych
2. **Message Queue**: Azure Service Bus dla asynchronicznych operacji
3. **File Storage**: Azure Blob Storage dla za³¹czników
4. **Logging**: Serilog + Application Insights
5. **API Gateway**: Azure API Management
6. **CDN**: Azure CDN dla statycznych zasobów frontendu

## ?? Testing Strategy

- **Unit Tests**: xUnit dla logiki biznesowej
- **Integration Tests**: WebApplicationFactory dla API
- **E2E Tests**: Playwright/Selenium dla UI

---

Dokument ten przedstawia aktualn¹ architekturê projektu i mo¿e byæ aktualizowany w miarê rozwoju aplikacji.
