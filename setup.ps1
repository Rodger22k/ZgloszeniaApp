# ZgloszeniaApp - Skrypt instalacyjny
# Automatyzuje proces setup'u projektu

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  ZgloszeniaApp - Instalator projektu  " -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Funkcja do sprawdzania czy komenda istnieje
function Test-CommandExists {
    param($command)
    $null = Get-Command $command -ErrorAction SilentlyContinue
    return $?
}

# 1. SprawdŸ .NET SDK
Write-Host "[1/6] Sprawdzanie .NET SDK..." -ForegroundColor Yellow
if (Test-CommandExists dotnet) {
    $dotnetVersion = dotnet --version
    Write-Host "? .NET SDK znaleziono: $dotnetVersion" -ForegroundColor Green
    
    # SprawdŸ czy to .NET 8
    if ($dotnetVersion -notlike "8.*") {
        Write-Host "? UWAGA: Projekt wymaga .NET 8. Obecna wersja: $dotnetVersion" -ForegroundColor Yellow
        Write-Host "Pobierz .NET 8 z: https://dotnet.microsoft.com/download/dotnet/8.0" -ForegroundColor Yellow
        $continue = Read-Host "Kontynuowaæ mimo to? (t/n)"
        if ($continue -ne "t") {
            exit
        }
    }
} else {
    Write-Host "? .NET SDK nie znaleziono!" -ForegroundColor Red
    Write-Host "Pobierz i zainstaluj z: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit
}

# 2. SprawdŸ Git
Write-Host "`n[2/6] Sprawdzanie Git..." -ForegroundColor Yellow
if (Test-CommandExists git) {
    $gitVersion = git --version
    Write-Host "? Git znaleziono: $gitVersion" -ForegroundColor Green
} else {
    Write-Host "? Git nie znaleziono!" -ForegroundColor Red
    Write-Host "Pobierz i zainstaluj z: https://git-scm.com/downloads" -ForegroundColor Yellow
    Write-Host "Git jest opcjonalny, ale zalecany dla kontroli wersji." -ForegroundColor Yellow
}

# 3. Restore pakietów NuGet
Write-Host "`n[3/6] Przywracanie pakietów NuGet..." -ForegroundColor Yellow
try {
    dotnet restore
    Write-Host "? Pakiety przywrócone pomyœlnie" -ForegroundColor Green
} catch {
    Write-Host "? B³¹d podczas przywracania pakietów" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    exit
}

# 4. Konfiguracja bazy danych
Write-Host "`n[4/6] Konfiguracja bazy danych..." -ForegroundColor Yellow

# SprawdŸ czy istnieje appsettings.json
if (!(Test-Path "ZgloszeniaApp.Backend\appsettings.json")) {
    Write-Host "Tworzenie pliku appsettings.json z szablonu..." -ForegroundColor Yellow
    Copy-Item "ZgloszeniaApp.Backend\appsettings.example.json" "ZgloszeniaApp.Backend\appsettings.json"
}

$createDb = Read-Host "Czy chcesz utworzyæ bazê danych? (t/n)"
if ($createDb -eq "t") {
    Write-Host "Tworzenie migracji bazy danych..." -ForegroundColor Yellow
    Set-Location "ZgloszeniaApp.Backend"
    
    try {
        dotnet ef database update
        Write-Host "? Baza danych utworzona pomyœlnie" -ForegroundColor Green
    } catch {
        Write-Host "? B³¹d podczas tworzenia bazy danych" -ForegroundColor Red
        Write-Host $_.Exception.Message -ForegroundColor Red
        Write-Host "`nUpewnij siê, ¿e:" -ForegroundColor Yellow
        Write-Host "1. SQL Server jest zainstalowany i uruchomiony" -ForegroundColor Yellow
        Write-Host "2. Connection string w appsettings.json jest poprawny" -ForegroundColor Yellow
        Write-Host "3. Masz zainstalowane narzêdzie: dotnet tool install --global dotnet-ef" -ForegroundColor Yellow
    }
    
    Set-Location ..
} else {
    Write-Host "Pominiêto tworzenie bazy danych." -ForegroundColor Yellow
    Write-Host "Uruchom póŸniej: cd ZgloszeniaApp.Backend && dotnet ef database update" -ForegroundColor Cyan
}

# 5. Kompilacja projektu
Write-Host "`n[5/6] Kompilacja projektu..." -ForegroundColor Yellow
try {
    dotnet build --configuration Release
    Write-Host "? Projekt skompilowany pomyœlnie" -ForegroundColor Green
} catch {
    Write-Host "? B³¹d podczas kompilacji" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    exit
}

# 6. Konfiguracja Git (jeœli Git jest dostêpny)
if (Test-CommandExists git) {
    Write-Host "`n[6/6] Konfiguracja Git..." -ForegroundColor Yellow
    
    if (!(Test-Path ".git")) {
        $initGit = Read-Host "Czy chcesz zainicjowaæ repozytorium Git? (t/n)"
        if ($initGit -eq "t") {
            git init
            Write-Host "? Repozytorium Git zainicjowane" -ForegroundColor Green
            
            # Konfiguracja u¿ytkownika
            $userName = Read-Host "Podaj swoje imiê i nazwisko dla Git"
            $userEmail = Read-Host "Podaj swój email dla Git"
            
            git config user.name "$userName"
            git config user.email "$userEmail"
            
            # Pierwszy commit
            $firstCommit = Read-Host "Czy chcesz utworzyæ pierwszy commit? (t/n)"
            if ($firstCommit -eq "t") {
                git add .
                git commit -m "Initial commit: ZgloszeniaApp - System zarz¹dzania zg³oszeniami"
                Write-Host "? Pierwszy commit utworzony" -ForegroundColor Green
            }
        }
    } else {
        Write-Host "? Repozytorium Git ju¿ istnieje" -ForegroundColor Green
    }
} else {
    Write-Host "`n[6/6] Git nie jest dostêpny - pominiêto" -ForegroundColor Yellow
}

# Podsumowanie
Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "           INSTALACJA ZAKOÑCZONA        " -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "?? Domyœlne konto administratora:" -ForegroundColor Yellow
Write-Host "   Email: admin@example.com" -ForegroundColor White
Write-Host "   Has³o: AdminHaslo123!" -ForegroundColor White
Write-Host ""
Write-Host "?? Aby uruchomiæ aplikacjê:" -ForegroundColor Yellow
Write-Host "   1. Backend:  cd ZgloszeniaApp.Backend && dotnet run" -ForegroundColor White
Write-Host "   2. Frontend: cd ZgloszeniaApp.Frontend && dotnet run" -ForegroundColor White
Write-Host ""
Write-Host "   LUB uruchom projekt w Visual Studio (F5)" -ForegroundColor White
Write-Host ""
Write-Host "?? Wiêcej informacji znajdziesz w:" -ForegroundColor Yellow
Write-Host "   - README.md - ogólny opis projektu" -ForegroundColor White
Write-Host "   - GITHUB_SETUP.md - jak dodaæ na GitHub" -ForegroundColor White
Write-Host "   - ARCHITECTURE.md - architektura projektu" -ForegroundColor White
Write-Host ""
Write-Host "? WA¯NE: Zmieñ has³o administratora po pierwszym logowaniu!" -ForegroundColor Red
Write-Host ""
Write-Host "Powodzenia! ??" -ForegroundColor Green
