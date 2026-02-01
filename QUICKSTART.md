# ?? Quick Start Guide

Szybki start dla developerów, którzy chc¹ jak najszybciej zacz¹æ pracowaæ z projektem.

## ? 5-minutowy start

### 1. Wymagania
```bash
# SprawdŸ .NET
dotnet --version  # Potrzebujesz 8.x

# SprawdŸ Git
git --version
```

### 2. Pobierz projekt
```bash
git clone https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp.git
cd ZgloszeniaApp
```

### 3. Automatyczna instalacja
**Windows:**
```powershell
.\setup.ps1
```

**Linux/Mac:**
```bash
chmod +x setup.sh
./setup.sh
```

### 4. Uruchom aplikacjê
```bash
# Terminal 1 - Backend
cd ZgloszeniaApp.Backend
dotnet run

# Terminal 2 - Frontend
cd ZgloszeniaApp.Frontend
dotnet run
```

### 5. Zaloguj siê
- Otwórz przegl¹darkê: `https://localhost:7XXX`
- Email: `admin@example.com`
- Has³o: `AdminHaslo123!`

**Gotowe!** ??

---

## ?? Manualna instalacja (jeœli setup siê nie uda³)

### Krok 1: Restore pakietów
```bash
dotnet restore
```

### Krok 2: Skonfiguruj bazê danych

Skopiuj przyk³adowy plik konfiguracji:
```bash
cp ZgloszeniaApp.Backend/appsettings.example.json ZgloszeniaApp.Backend/appsettings.json
```

Edytuj connection string w `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ZgloszeniaDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### Krok 3: Utwórz bazê danych
```bash
cd ZgloszeniaApp.Backend
dotnet ef database update
cd ..
```

### Krok 4: Build
```bash
dotnet build
```

---

## ?? Przydatne komendy

### Backend
```bash
# Uruchom Backend
cd ZgloszeniaApp.Backend
dotnet run

# Build Release
dotnet build --configuration Release

# Dodaj now¹ migracjê
dotnet ef migrations add NazwaMigracji

# Zastosuj migracje
dotnet ef database update

# Cofnij ostatni¹ migracjê
dotnet ef migrations remove

# Zobacz wszystkie migracje
dotnet ef migrations list
```

### Frontend
```bash
# Uruchom Frontend
cd ZgloszeniaApp.Frontend
dotnet run

# Build na produkcjê
dotnet publish -c Release

# Watch mode (auto-refresh)
dotnet watch run
```

### Git
```bash
# Status
git status

# Commit
git add .
git commit -m "Opis zmian"

# Push
git push origin main

# Utwórz nowy branch
git checkout -b feature/nazwa-funkcji

# Prze³¹cz branch
git checkout main

# Merge branch
git merge feature/nazwa-funkcji
```

---

## ?? Struktura projektu (szybki przegl¹d)

```
ZgloszeniaApp/
??? ZgloszeniaApp.Frontend/     # Blazor WebAssembly
?   ??? Pages/                  # Strony (.razor)
?   ??? Services/               # HTTP services
?   ??? wwwroot/                # Statyczne pliki
?
??? ZgloszeniaApp.Backend/      # ASP.NET Core API
?   ??? Controllers/            # API endpoints
?   ??? Data/                   # DbContext
?   ??? Models/                 # Modele danych
?
??? ZgloszeniaApp.Shared/       # Wspólne modele
    ??? Models/                 # DTOs
```

---

## ?? Pierwsze zadania dla nowych developerów

### Zadanie 1: Dodaj pole do zg³oszenia (30 min)
1. Dodaj `Priorytet` do `Zgloszenie.cs`
2. Utwórz migracjê
3. Dodaj pole w formularzu
4. Wyœwietl w liœcie

### Zadanie 2: Zmieñ wygl¹d (15 min)
1. Edytuj `wwwroot/css/app.css`
2. Zmieñ kolory Bootstrap
3. Dodaj w³asne style

### Zadanie 3: Dodaj nowy endpoint API (45 min)
1. Utwórz `StatsController.cs`
2. Dodaj metodê `GetStatistics()`
3. Wywo³aj z Frontend

---

## ?? Szybkie rozwi¹zania problemów

### Problem: "Port already in use"
```bash
# Windows - znajdŸ i zabij proces
netstat -ano | findstr :7000
taskkill /PID <PID> /F

# Linux/Mac
lsof -ti:7000 | xargs kill
```

### Problem: "Database does not exist"
```bash
cd ZgloszeniaApp.Backend
dotnet ef database update
```

### Problem: "401 Unauthorized"
- Wyloguj siê i zaloguj ponownie
- SprawdŸ czy token jest w LocalStorage (F12 ? Application)

### Problem: Build fails
```bash
# Wyczyœæ i przebuduj
dotnet clean
dotnet restore
dotnet build
```

---

## ?? Gdzie szukaæ pomocy

1. **README.md** - podstawy projektu
2. **FAQ.md** - najczêstsze problemy
3. **ARCHITECTURE.md** - jak dzia³a aplikacja
4. **Issues na GitHub** - zg³oszone problemy
5. **Stack Overflow** - ogólne problemy .NET/Blazor

---

## ?? Polecane zasoby do nauki

### Blazor
- [Dokumentacja Microsoft](https://learn.microsoft.com/pl-pl/aspnet/core/blazor/)
- [Blazor University](https://blazor-university.com/)

### ASP.NET Core
- [ASP.NET Core Fundamentals](https://learn.microsoft.com/pl-pl/aspnet/core/fundamentals/)
- [EF Core Documentation](https://learn.microsoft.com/pl-pl/ef/core/)

### JWT & Security
- [JWT.io](https://jwt.io/)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)

---

## ? Checklist przed pierwszym Pull Requestem

- [ ] Kod kompiluje siê bez b³êdów
- [ ] Przetestowa³em zmiany lokalnie
- [ ] Doda³em komentarze do skomplikowanego kodu
- [ ] Commit messages s¹ jasne
- [ ] Nie commitowa³em wra¿liwych danych
- [ ] Sprawdzi³em czy nie ma konfliktów z main
- [ ] Przeczyta³em CONTRIBUTING.md

---

## ?? Next Steps

Po opanowaniu podstaw:
1. Dodaj testy jednostkowe (xUnit)
2. Skonfiguruj CI/CD (GitHub Actions)
3. Deploy na Azure
4. Dodaj Docker support
5. Implementuj SignalR dla real-time updates

---

**Powodzenia w developmencie!** ??

Masz pytania? Utwórz issue lub napisz do nas!
