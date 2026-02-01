#!/bin/bash

# ZgloszeniaApp - Skrypt instalacyjny (Linux/Mac)
# Automatyzuje proces setup'u projektu

echo "========================================"
echo "  ZgloszeniaApp - Instalator projektu  "
echo "========================================"
echo ""

# Kolory
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
CYAN='\033[0;36m'
NC='\033[0m' # No Color

# Funkcja do sprawdzania czy komenda istnieje
command_exists() {
    command -v "$1" >/dev/null 2>&1
}

# 1. SprawdŸ .NET SDK
echo -e "${YELLOW}[1/6] Sprawdzanie .NET SDK...${NC}"
if command_exists dotnet; then
    DOTNET_VERSION=$(dotnet --version)
    echo -e "${GREEN}? .NET SDK znaleziono: $DOTNET_VERSION${NC}"
    
    # SprawdŸ czy to .NET 8
    if [[ ! $DOTNET_VERSION == 8.* ]]; then
        echo -e "${YELLOW}? UWAGA: Projekt wymaga .NET 8. Obecna wersja: $DOTNET_VERSION${NC}"
        echo -e "${YELLOW}Pobierz .NET 8 z: https://dotnet.microsoft.com/download/dotnet/8.0${NC}"
        read -p "Kontynuowaæ mimo to? (t/n) " -n 1 -r
        echo
        if [[ ! $REPLY =~ ^[Tt]$ ]]; then
            exit 1
        fi
    fi
else
    echo -e "${RED}? .NET SDK nie znaleziono!${NC}"
    echo -e "${YELLOW}Pobierz i zainstaluj z: https://dotnet.microsoft.com/download${NC}"
    exit 1
fi

# 2. SprawdŸ Git
echo -e "\n${YELLOW}[2/6] Sprawdzanie Git...${NC}"
if command_exists git; then
    GIT_VERSION=$(git --version)
    echo -e "${GREEN}? Git znaleziono: $GIT_VERSION${NC}"
else
    echo -e "${RED}? Git nie znaleziono!${NC}"
    echo -e "${YELLOW}Pobierz i zainstaluj z: https://git-scm.com/downloads${NC}"
    echo -e "${YELLOW}Git jest opcjonalny, ale zalecany dla kontroli wersji.${NC}"
fi

# 3. Restore pakietów NuGet
echo -e "\n${YELLOW}[3/6] Przywracanie pakietów NuGet...${NC}"
if dotnet restore; then
    echo -e "${GREEN}? Pakiety przywrócone pomyœlnie${NC}"
else
    echo -e "${RED}? B³¹d podczas przywracania pakietów${NC}"
    exit 1
fi

# 4. Konfiguracja bazy danych
echo -e "\n${YELLOW}[4/6] Konfiguracja bazy danych...${NC}"

# SprawdŸ czy istnieje appsettings.json
if [ ! -f "ZgloszeniaApp.Backend/appsettings.json" ]; then
    echo -e "${YELLOW}Tworzenie pliku appsettings.json z szablonu...${NC}"
    cp "ZgloszeniaApp.Backend/appsettings.example.json" "ZgloszeniaApp.Backend/appsettings.json"
fi

read -p "Czy chcesz utworzyæ bazê danych? (t/n) " -n 1 -r
echo
if [[ $REPLY =~ ^[Tt]$ ]]; then
    echo -e "${YELLOW}Tworzenie migracji bazy danych...${NC}"
    cd "ZgloszeniaApp.Backend" || exit
    
    if dotnet ef database update; then
        echo -e "${GREEN}? Baza danych utworzona pomyœlnie${NC}"
    else
        echo -e "${RED}? B³¹d podczas tworzenia bazy danych${NC}"
        echo -e "\n${YELLOW}Upewnij siê, ¿e:${NC}"
        echo -e "${YELLOW}1. SQL Server jest zainstalowany i uruchomiony${NC}"
        echo -e "${YELLOW}2. Connection string w appsettings.json jest poprawny${NC}"
        echo -e "${YELLOW}3. Masz zainstalowane narzêdzie: dotnet tool install --global dotnet-ef${NC}"
    fi
    
    cd ..
else
    echo -e "${YELLOW}Pominiêto tworzenie bazy danych.${NC}"
    echo -e "${CYAN}Uruchom póŸniej: cd ZgloszeniaApp.Backend && dotnet ef database update${NC}"
fi

# 5. Kompilacja projektu
echo -e "\n${YELLOW}[5/6] Kompilacja projektu...${NC}"
if dotnet build --configuration Release; then
    echo -e "${GREEN}? Projekt skompilowany pomyœlnie${NC}"
else
    echo -e "${RED}? B³¹d podczas kompilacji${NC}"
    exit 1
fi

# 6. Konfiguracja Git (jeœli Git jest dostêpny)
if command_exists git; then
    echo -e "\n${YELLOW}[6/6] Konfiguracja Git...${NC}"
    
    if [ ! -d ".git" ]; then
        read -p "Czy chcesz zainicjowaæ repozytorium Git? (t/n) " -n 1 -r
        echo
        if [[ $REPLY =~ ^[Tt]$ ]]; then
            git init
            echo -e "${GREEN}? Repozytorium Git zainicjowane${NC}"
            
            # Konfiguracja u¿ytkownika
            read -p "Podaj swoje imiê i nazwisko dla Git: " USER_NAME
            read -p "Podaj swój email dla Git: " USER_EMAIL
            
            git config user.name "$USER_NAME"
            git config user.email "$USER_EMAIL"
            
            # Pierwszy commit
            read -p "Czy chcesz utworzyæ pierwszy commit? (t/n) " -n 1 -r
            echo
            if [[ $REPLY =~ ^[Tt]$ ]]; then
                git add .
                git commit -m "Initial commit: ZgloszeniaApp - System zarz¹dzania zg³oszeniami"
                echo -e "${GREEN}? Pierwszy commit utworzony${NC}"
            fi
        fi
    else
        echo -e "${GREEN}? Repozytorium Git ju¿ istnieje${NC}"
    fi
else
    echo -e "\n${YELLOW}[6/6] Git nie jest dostêpny - pominiêto${NC}"
fi

# Podsumowanie
echo -e "\n${CYAN}========================================${NC}"
echo -e "${CYAN}           INSTALACJA ZAKOÑCZONA        ${NC}"
echo -e "${CYAN}========================================${NC}"
echo ""
echo -e "${YELLOW}?? Domyœlne konto administratora:${NC}"
echo -e "   Email: admin@example.com"
echo -e "   Has³o: AdminHaslo123!"
echo ""
echo -e "${YELLOW}?? Aby uruchomiæ aplikacjê:${NC}"
echo -e "   1. Backend:  cd ZgloszeniaApp.Backend && dotnet run"
echo -e "   2. Frontend: cd ZgloszeniaApp.Frontend && dotnet run"
echo ""
echo -e "${YELLOW}?? Wiêcej informacji znajdziesz w:${NC}"
echo -e "   - README.md - ogólny opis projektu"
echo -e "   - GITHUB_SETUP.md - jak dodaæ na GitHub"
echo -e "   - ARCHITECTURE.md - architektura projektu"
echo ""
echo -e "${RED}? WA¯NE: Zmieñ has³o administratora po pierwszym logowaniu!${NC}"
echo ""
echo -e "${GREEN}Powodzenia! ??${NC}"
