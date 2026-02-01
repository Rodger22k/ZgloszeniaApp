# Polityka bezpieczeñstwa

## Obs³ugiwane wersje

Obecnie wspierane wersje projektu:

| Wersja | Wsparcie         |
| ------ | ---------------- |
| 1.0.x  | :white_check_mark: |

## Zg³aszanie luk w zabezpieczeniach

Bezpieczeñstwo jest dla nas priorytetem. Jeœli odkryjesz lukê w zabezpieczeniach, prosimy o odpowiedzialne ujawnienie.

### Jak zg³osiæ

**NIE** twórz publicznego issue dla luk w zabezpieczeniach.

Zamiast tego:
1. Wyœlij email na: [twoj-email@example.com]
2. Opisz szczegó³owo lukê
3. Do³¹cz kroki do odtworzenia (jeœli to mo¿liwe)
4. Poczekaj na odpowiedŸ (zazwyczaj w ci¹gu 48h)

### Co zg³osiæ

Zg³oœ nam, jeœli znajdziesz:
- Mo¿liwoœæ obejœcia autoryzacji
- Wstrzykiwanie SQL (SQL Injection)
- Podatnoœci XSS (Cross-Site Scripting)
- CSRF (Cross-Site Request Forgery)
- Ujawnienie wra¿liwych danych
- Niezabezpieczone API endpoints
- Problemy z walidacj¹ danych

### Czego siê spodziewaæ

1. **Potwierdzenie** - otrzymasz potwierdzenie w ci¹gu 48h
2. **Ocena** - ocenimy zg³oszenie i potwierdzimy/odrzucimy
3. **Naprawa** - opracujemy i przetestujemy poprawkê
4. **Publikacja** - opublikujemy poprawkê i informacjê o aktualizacji
5. **Uznanie** - z Twoj¹ zgod¹, zostaniesz wymieniony w podziêkowaniach

## Najlepsze praktyki bezpieczeñstwa

Dla u¿ytkowników aplikacji:

### W œrodowisku produkcyjnym

1. **Zmieñ domyœlne has³o administratora** natychmiast po instalacji
2. **Zmieñ klucz JWT** w `appsettings.json`:
   ```json
   "Jwt": {
     "Key": "Wygeneruj-d³ugi-losowy-ci¹g-znaków-min-32-znaki"
   }
   ```
3. **U¿yj silnego connection stringa** do bazy danych
4. **W³¹cz HTTPS** i u¿yj wa¿nych certyfikatów SSL
5. **Nie commituj** plików `appsettings.Production.json` do repozytorium
6. **Regularnie aktualizuj** zale¿noœci NuGet
7. **W³¹cz logowanie** i monitoruj podejrzane aktywnoœci
8. **U¿ywaj zmiennych œrodowiskowych** dla wra¿liwych danych

### Zalecenia dla hase³

- Minimum 8 znaków
- Przynajmniej jedna wielka litera
- Przynajmniej jedna ma³a litera
- Przynajmniej jedna cyfra
- Przynajmniej jeden znak specjalny

### Konfiguracja bazy danych

Nigdy nie u¿ywaj konta `sa` ani kont z nadmiernymi uprawnieniami. Utwórz dedykowane konto z minimalnymi wymaganymi uprawnieniami:

```sql
CREATE USER [ZgloszeniaAppUser] WITH PASSWORD = 'StrongPassword123!';
GRANT SELECT, INSERT, UPDATE, DELETE ON DATABASE::ZgloszeniaDb TO [ZgloszeniaAppUser];
```

## Znane ograniczenia

- Brak limitowania prób logowania (planowane w przysz³ej wersji)
- Brak dwusk³adnikowego uwierzytelniania 2FA (planowane)

## Aktualizacje bezpieczeñstwa

Subskrybuj repozytorium, aby otrzymywaæ powiadomienia o aktualizacjach bezpieczeñstwa.

---

Dziêkujemy za pomoc w utrzymaniu bezpieczeñstwa projektu! ??
