# Changelog

Wszystkie istotne zmiany w tym projekcie bêd¹ dokumentowane w tym pliku.

Format oparty na [Keep a Changelog](https://keepachangelog.com/pl/1.0.0/),
a projekt stosuje [Semantic Versioning](https://semver.org/lang/pl/).

## [Niepublikowane]

### Dodane
- Inicjalna wersja projektu
- System uwierzytelniania i autoryzacji (JWT + ASP.NET Core Identity)
- Role u¿ytkowników (Administrator, User)
- Funkcjonalnoœæ dodawania zg³oszeñ
- Funkcjonalnoœæ przegl¹dania zg³oszeñ
- Funkcjonalnoœæ usuwania zg³oszeñ
- Panel administratora do zarz¹dzania u¿ytkownikami
- Eksport zg³oszeñ do pliku Excel (tylko dla administratorów)
- Automatyczne tworzenie domyœlnego konta administratora
- Responsywny interfejs u¿ytkownika (Bootstrap 5)

### Zabezpieczenia
- Implementacja JWT dla bezpiecznej autoryzacji
- Hashowanie hase³ przez ASP.NET Core Identity
- Wymaganie HTTPS
- Autoryzacja oparta na rolach

## [1.0.0] - 2024-12-XX

### Dodane
- Pierwsza publiczna wersja aplikacji ZgloszeniaApp

---

## Typy zmian
- **Dodane** - nowe funkcjonalnoœci
- **Zmienione** - zmiany w istniej¹cych funkcjonalnoœciach
- **Przestarza³e** - funkcjonalnoœci, które wkrótce zostan¹ usuniête
- **Usuniête** - usuniête funkcjonalnoœci
- **Naprawione** - poprawki b³êdów
- **Zabezpieczenia** - w przypadku luk w zabezpieczeniach
