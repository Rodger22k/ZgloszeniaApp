# Wytyczne dla wspó³twórców

Dziêkujemy za zainteresowanie wniesieniem wk³adu w projekt ZgloszeniaApp! ??

## ?? Jak zg³osiæ b³¹d (Bug Report)

Jeœli znalaz³eœ b³¹d, utwórz nowy issue z nastêpuj¹cymi informacjami:

- **Tytu³**: Krótki, opisowy tytu³ b³êdu
- **Opis**: Szczegó³owy opis problemu
- **Kroki do odtworzenia**: Jak odtworzyæ b³¹d
- **Oczekiwane zachowanie**: Co powinno siê wydarzyæ
- **Obecne zachowanie**: Co siê dzieje
- **Œrodowisko**: 
  - Wersja .NET
  - System operacyjny
  - Przegl¹darka (jeœli dotyczy frontendu)

## ?? Jak zaproponowaæ now¹ funkcjonalnoœæ (Feature Request)

1. SprawdŸ czy dana funkcjonalnoœæ nie by³a ju¿ zaproponowana
2. Utwórz nowy issue z tagiem "enhancement"
3. Opisz:
   - Jaki problem rozwi¹zuje ta funkcjonalnoœæ
   - Jak powinna dzia³aæ
   - Dlaczego jest potrzebna

## ?? Jak wnieœæ kod

### 1. Fork & Clone

```bash
# Zforkuj repozytorium na GitHubie, a nastêpnie:
git clone https://github.com/TWOJA-NAZWA/ZgloszeniaApp.git
cd ZgloszeniaApp
```

### 2. Utwórz nowy branch

```bash
git checkout -b feature/nazwa-funkcjonalnosci
# lub
git checkout -b fix/nazwa-poprawki
```

### 3. WprowadŸ zmiany

- Pisz czysty, czytelny kod
- Dodaj komentarze tam, gdzie to konieczne
- Przestrzegaj konwencji nazewnictwa C#
- Testuj swoje zmiany

### 4. Commit

```bash
git add .
git commit -m "Add: krótki opis zmian"
```

Typy commitów:
- `Add:` - dodanie nowej funkcjonalnoœci
- `Fix:` - naprawa b³êdu
- `Update:` - aktualizacja istniej¹cej funkcjonalnoœci
- `Refactor:` - refaktoryzacja kodu
- `Docs:` - zmiany w dokumentacji

### 5. Push & Pull Request

```bash
git push origin feature/nazwa-funkcjonalnosci
```

Nastêpnie utwórz Pull Request na GitHubie z opisem:
- Co zosta³o zmienione
- Dlaczego zosta³o zmienione
- Jak to przetestowaæ

## ? Checklist przed Pull Requestem

- [ ] Kod kompiluje siê bez b³êdów
- [ ] Wszystkie testy przechodz¹
- [ ] Dodano/zaktualizowano dokumentacjê
- [ ] Kod jest sformatowany zgodnie z konwencjami
- [ ] Nie ma zbêdnych plików (usuñ debug, logi, etc.)
- [ ] Commit message s¹ jasne i opisowe

## ?? Standardy kodowania

### C# / .NET
- U¿ywaj PascalCase dla nazw klas, metod, w³aœciwoœci
- U¿ywaj camelCase dla zmiennych lokalnych i parametrów
- U¿ywaj `var` gdy typ jest oczywisty
- Zawsze u¿ywaj nawiasów klamrowych `{}` nawet dla jednolinijkowych bloków
- Maksymalna d³ugoœæ linii: 120 znaków

### Blazor
- Komponenty w PascalCase
- Pliki `.razor` dla komponentów
- Oddzielaj logikê (`@code`) od widoku

### Baza danych
- U¿ywaj migracji Entity Framework
- Nazwy tabel w liczbie mnogiej (np. `Zgloszenia`)
- Klucze obce z sufiksem `Id` (np. `UserId`)

## ?? Testowanie

Przed wys³aniem Pull Requesta:

1. Uruchom aplikacjê lokalnie
2. Przetestuj dodan¹ funkcjonalnoœæ
3. Upewnij siê, ¿e nie popsu³o to istniej¹cych funkcji

## ? Pytania?

Jeœli masz pytania, mo¿esz:
- Otworzyæ issue z pytaniem
- Skontaktowaæ siê przez email
- Do³¹czyæ do dyskusji w sekcji Discussions

## ?? Kod postêpowania

- B¹dŸ uprzejmy i szanuj innych
- Akceptuj konstruktywn¹ krytykê
- Skup siê na tym, co najlepsze dla projektu
- Wykazuj empatiê wobec innych cz³onków spo³ecznoœci

Dziêkujemy za Twój wk³ad! ??
