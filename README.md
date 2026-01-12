# 🏷️ DiscountApp – System Zarządzania Kodami Rabatowymi

## 0. Informacje Ogólne
**DiscountApp** to aplikacja webowa zbudowana w technologii **ASP.NET Core Razor Pages**. System służy do kompleksowego zarządzania cyklem życia kodów rabatowych: od ich generowania, przez monitorowanie, aż po bezpieczną weryfikację i jednorazową realizację.

Aplikacja zapewnia spójność danych dzięki wykorzystaniu bazy PostgreSQL i zapobiega wielokrotnemu użyciu tego samego kodu poprzez mechanizm zmiany stanu (**Status Pattern**).

---

## 1. Technologia (Stack)
Projekt został zrealizowany z wykorzystaniem nowoczesnych narzędzi programistycznych:

| Komponent | Technologia |
| :--- | :--- |
| **Język / Framework** | C# 13 / .NET 9 |
| **Baza Danych** | PostgreSQL |
| **ORM** | Entity Framework Core |
| **Interfejs** | HTML5 + Tailwind CSS |
| **Konteneryzacja** | Docker & Docker Desktop |
| **IDE** | JetBrains Rider |

---

## 2. Architektura i Wzorce
Mimo edukacyjnego charakteru projektu, zaimplementowano w nim wzorce klasy Enterprise:

* **Dependency Injection (DI):** Wykorzystanie wbudowanego kontenera .NET do wstrzykiwania serwisu `IDiscountService`.
* **Service Pattern:** Logika biznesowa została wyizolowana od warstwy prezentacji i zamknięta w dedykowanym serwisie.
* **Repository Pattern:** Wykorzystanie `ApplicationDbContext` do abstrakcji operacji na bazie danych.
* **Security:** Ochrona przed atakami CSRF przy użyciu **Antiforgery Tokens**.

---

## 3. Instrukcja uruchomienia

### Krok 1: Baza danych (Docker)
Uruchom instancję PostgreSQL za pomocą komendy:

```bash
docker run --name discount-db   -e POSTGRES_USER=root   -e POSTGRES_PASSWORD=root   -e POSTGRES_DB=DiscountDb   -p 5432:5432   -d postgres
 ```
### Krok 2: Konfiguracja tabeli
Połącz się z bazą i wykonaj poniższy skrypt SQL:
```SQL
CREATE TABLE "DiscountTable" (
    "Id" SERIAL PRIMARY KEY,
    "Code" TEXT NOT NULL,
    "Description" TEXT,
    "Status" TEXT NOT NULL DEFAULT 'ACTIVE'
);
```
### Krok 3: Uruchomienie aplikacji
```bash
dotnet run
```
Aplikacja dostępna pod adresem: `http://localhost:5000`

## 4. Funkcjonalności
✅ Zarządzanie: Dodawanie nowych kodów rabatowych z opisem.

✅ Lista kodów: Podgląd statusów (ACTIVE/USED) z dynamicznym kolorowaniem (Tailwind CSS).

✅ Realizacja: Moduł weryfikujący i blokujący ponowne użycie kodu.

✅ Usuwanie: Możliwość zarządzania retencją danych z poziomu UI.

## Słowa końcowe

Na co dzień programuję w języku Java. Projekt DiscountApp jest moim pierwszym kontaktem z ekosystemem .NET oraz Entity Framework Core. Wyzwanie pozwoliło mi na porównanie mechanizmów wstrzykiwania zależności oraz pracy z bazą danych (Spring Data vs EF Core) w obu tych środowiskach.

`Projekt zrealizowany w ramach przedmiotu Programowanie Obiektowe`
