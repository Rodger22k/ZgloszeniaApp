# ?? Instrukcja dodania projektu na GitHub

## Krok 1: Instalacja Git

Jeœli nie masz zainstalowanego Git:
- Pobierz z: https://git-scm.com/downloads
- Zainstaluj z domyœlnymi opcjami
- SprawdŸ instalacjê w PowerShell/CMD: `git --version`

## Krok 2: Konfiguracja Git (jednorazowa)

Otwórz PowerShell/CMD w folderze projektu i wykonaj:

```bash
git config --global user.name "Twoje Imiê Nazwisko"
git config --global user.email "twoj-email@example.com"
```

## Krok 3: Utwórz repozytorium na GitHub

1. Zaloguj siê na https://github.com
2. Kliknij "+" w prawym górnym rogu ? "New repository"
3. Wype³nij formularz:
   - **Repository name**: `ZgloszeniaApp`
   - **Description**: `System zarz¹dzania zg³oszeniami - Blazor WebAssembly + ASP.NET Core`
   - **Public** lub **Private** (wybierz wed³ug preferencji)
   - **NIE** zaznaczaj "Initialize with README" (mamy ju¿ README)
   - **NIE** dodawaj .gitignore (mamy ju¿ .gitignore)
   - **Mo¿esz** wybraæ licencjê MIT (lub u¿yæ naszego pliku LICENSE)
4. Kliknij "Create repository"

## Krok 4: Zainicjuj Git w lokalnym projekcie

W PowerShell/CMD w g³ównym folderze projektu (tam gdzie jest plik .sln):

```bash
# Zainicjuj repozytorium Git
git init

# Dodaj wszystkie pliki do staging area
git add .

# SprawdŸ status (opcjonalnie)
git status

# Utwórz pierwszy commit
git commit -m "Initial commit: ZgloszeniaApp - System zarz¹dzania zg³oszeniami"
```

## Krok 5: Po³¹cz z GitHub i wypchnij kod

GitHub poka¿e Ci komendy na stronie nowego repozytorium. U¿yj:

```bash
# Dodaj remote (ZMIEÑ 'twoja-nazwa-uzytkownika' na swoj¹ nazwê na GitHubie)
git remote add origin https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp.git

# Zmieñ nazwê g³ównego brancha na 'main' (jeœli u¿ywasz 'master')
git branch -M main

# Wypchnij kod na GitHub
git push -u origin main
```

### Jeœli pojawi siê problem z autentykacj¹:

GitHub nie wspiera ju¿ hase³. U¿yj Personal Access Token:

1. IdŸ do: https://github.com/settings/tokens
2. Kliknij "Generate new token" ? "Generate new token (classic)"
3. Nadaj nazwê: "ZgloszeniaApp"
4. Zaznacz scopes: `repo` (wszystkie opcje)
5. Kliknij "Generate token"
6. **SKOPIUJ TOKEN** (nie zobaczysz go ponownie!)
7. Przy push u¿yj tokena jako has³a

## Krok 6: Weryfikacja

1. Odœwie¿ stronê repozytorium na GitHub
2. Powinieneœ zobaczyæ wszystkie pliki
3. README.md powinno byæ automatycznie wyœwietlone

## Krok 7: Dodaj tematy (opcjonalnie)

Na stronie repozytorium:
1. Kliknij ikonê ko³a zêbatego obok "About"
2. Dodaj tematy (topics):
   - `blazor`
   - `blazor-webassembly`
   - `aspnet-core`
   - `csharp`
   - `dotnet`
   - `sql-server`
   - `entity-framework-core`
   - `jwt-authentication`
   - `bootstrap5`

## Krok 8: Ustaw GitHub Pages (opcjonalnie)

Jeœli chcesz hostowaæ dokumentacjê:
1. Settings ? Pages
2. Source: wybierz branch `main` i folder `/docs` lub `/root`
3. Save

## ?? Przydatne komendy Git na przysz³oœæ

```bash
# SprawdŸ status zmian
git status

# Dodaj nowe/zmienione pliki
git add .

# Commit zmian
git commit -m "Opis zmian"

# Wypchnij zmiany na GitHub
git push

# Pobierz zmiany z GitHub
git pull

# Zobacz historiê commitów
git log --oneline

# Utwórz nowy branch
git checkout -b nazwa-brancha

# Prze³¹cz siê na inny branch
git checkout main
```

## ?? Rozwi¹zywanie problemów

### Problem: "remote origin already exists"
```bash
git remote remove origin
git remote add origin https://github.com/twoja-nazwa-uzytkownika/ZgloszeniaApp.git
```

### Problem: Zbyt du¿e pliki
Jeœli folder bin/ lub obj/ zosta³ dodany:
```bash
# Usuñ cache
git rm -r --cached bin/ obj/
git commit -m "Remove bin and obj folders"
git push
```

### Problem: Konflikt przy push
```bash
git pull --rebase
# Rozwi¹¿ konflikty jeœli s¹
git push
```

## ? Checklist przed pierwszym push

- [ ] Sprawdzi³em czy .gitignore dzia³a poprawnie
- [ ] Usun¹³em wszystkie wra¿liwe dane (has³a, connection stringi, klucze API)
- [ ] README.md jest kompletny i aktualny
- [ ] Projekt siê kompiluje bez b³êdów
- [ ] Zaktualizowa³em informacje kontaktowe w README.md
- [ ] Doda³em odpowiedni¹ licencjê

## ?? Gotowe!

Twój projekt jest teraz na GitHubie! 

### Nastêpne kroki:
1. Dodaj opis i link do repozytorium w swoim CV/portfolio
2. Udostêpnij link znajomym/rekruterom
3. Kontynuuj development i pushuj zmiany regularnie
4. Rozwa¿ dodanie GitHub Actions dla CI/CD

---

## ?? Dodatkowe zasoby

- [Dokumentacja Git](https://git-scm.com/doc)
- [GitHub Guides](https://guides.github.com/)
- [Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)

Powodzenia! ??
