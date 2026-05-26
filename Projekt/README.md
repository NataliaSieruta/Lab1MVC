Nazwa projektu: RecipeApp
Tytuł: Kolekcja ulubionych przepisów kulinarnych

--Spis treści:
1. Opis projektu
2. Funkcjonalności
3. Technologie
4. Struktura projektu MVC
5. Instrukcja uruchomienia
6. Baza danych
7. Dodatkowe funkcjonalności

--Opis projektu

RecipeApp to aplikacja internetowa stworzona w ASP.NET Core MVC, która umożliwia zarządzanie kolekcją ulubionych przepisów kulinarnych.

Użytkownik może:
- dodawać przepisy,
- przeglądać przepisy,
- usuwać przepisy,
- wyszukiwać przepisy po nazwie,
- przypisywać kategorię do przepisu,
- dodawać składniki wraz z ilością.

--Funkcjonalności

Zarządzanie przepisami
-dodawanie przepisów,
-wyświetlanie listy przepisów,
-usuwanie przepisów

Kategorie przepisów
-do każdego przepisu przypisuje się kategorie dania

Składniki
-dodawanie składników do przepisu
-możliwość określenia ich ilości

Wyszukiwanie
-wyszukiwanie przepisów po nazwie

Walidacja danych
-sprawdzanie wymaganych pól za pomocą '[Required]'

--Technologie

Aplikacja została wykonana za pomocą:
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- C#

--Struktura MVC projektu

Model: Recipe, Category, Ingredient, RecipeIngredient
View: Index, Create
Controller: RecipesController

--Instrukcja uruchomienia

1. Wymagania:
- Visual Studio 
- .NET 10
- SQL Server

2. Zainstalowanie paczek NuGet
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design

3. Konfiguracja bazy danych

W pliku `appsettings.json` należy ustawić connection string do SQL Server.

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=RecipeDb;Trusted_Connection=True;"
}

4. Migracje bazy danych

W konsoli Package Manager Console:
Add-Migration InitialCreate
Update-Database

5. Uruchomienie aplikacji przyciskiem https lub klawiszem F5

--Baza danych

Projekt wykorzystuje relacje pomiędzy tabelami:

- Recipe → Category
- Recipe ↔ Ingredient

Relacja wiele-do-wielu została zrealizowana przy pomocy tabeli pośredniej:

- RecipeIngredient

Tabela ta przechowuje dodatkowo ilość składnika w przepisie.

