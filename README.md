# ASP.NET-CORE-LAB

Aplikacja ma za zadanie zarządzanie albumami muzycznymi, przeglądanie spisów piosenek oraz śledzenie notowań.

1. Wykorzystane Technologie :
    1.  .NET 7.0
    2.  Baza danych SQLite: Przetrzymuje dane dotyczące albumów muzycznych oraz piosenek, jakie się w nich znajdują.
    3.  xUnit: Testy jednostkowe zostały napisane w xUnit, tak jak na zajęciach.

2. Dane użytkownika do logowania:
    login: user
    hasło: user123

3. Proces Uruchomienia Aplikacji w Wersji Deweloperskiej
    1. Uruchom plik AspLab.sln w Visual Studio
    2. Wybierz lab3zadanie jako projekt startowy
    3. Usuń poprzednie migracje z AlbumData ( AlbumData/Migrations/... )
    4. Usuń plik lub pliki album.db (jeśli istnieją) z lokalizacji ( ZalogowanyUżytkownik/AppData/Local )
    5. Kliknij prawym przyciskiem myszy na AlbumData, otwórz w terminalu i wpisz po koleji podane komendy aby wykonać migrację:
       dotnet tool install --global dotnet-ef
       dotnet ef migrations add InitialCreate
       dotnet ef database update
    6. Obok wybranego lab3zadanie kliknij zielony Play |>, by uruchomić aplikację
    7. Po uruchomieniu kliknij w zakładkę Albums
    8. Zaloguj się na konto użytkownika podane powyżej
    9. By dodać album, kliknij "Add an Album", a następnie wprowadź dane i wciśnij "Create"
    10. Aplikacja pokazuje ci wszystkie zapisane Albumy w bazie danych oraz daje ci możliwość ich edycji, zobaczenia detali oraz usunięcia
    11. W widoku "Details" każdy album może dodać piosenki, które się w nim znajdują, oraz je usunąć

4. Dodałem Unit testy napisane w xUnit, które sprawdzają poprawność działania AlbumController

![image](https://github.com/Khazaxa/ASP.NET-CORE-LAB/assets/96346556/02129c54-bf7e-4f88-a922-90d8d739dd86)

![image](https://github.com/Khazaxa/ASP.NET-CORE-LAB/assets/96346556/918ebd08-16e1-41db-bbfe-2dca84a9215a)
