# InternetoveKnihkupectvi
Program Internetové knihkupectví s názvem Nežárka je nedokončená verze, aplikace nebyla zamíšlena jako ukázka a tak chybí komentáře.
Je zde použitý MVC struktura kódu. Tento program je základem e-shopu internetového knihkupectví 
Nežárka.NET - aplikace představuje implementaci logiky na straně webového serveru. Po spuštění obdrží aplikace
na standardním vstupu textový popis dat e-shopu (tedy vlastně reprezentaci dat z relační databáze) v následujícím formátu:

Vzor vstupu:
1. část

DATA-BEGIN
BOOK;1;Lord of the Rings;J. R. R. Tolkien;59
BOOK;2;Hobbit: There and Back Again;J. R. R. Tolkien;49
BOOK;3;Going Postal;Terry Pratchett;28
BOOK;4;The Colour of Magic;Terry Pratchett;159
BOOK;5;I Shall Wear Midnight;Terry Pratchett;31
CUSTOMER;1;Klara;Dembinna
CUSTOMER;2;Jan;Novak
CUSTOMER;3;Lukas;Novotny
CUSTOMER;4;Tomas;Tomas
CART-ITEM;2;1;3
CART-ITEM;2;5;1
DATA-END

Po načtení vstupních dat dostává aplikace na standardním vstupu příkazy od klientů systému (jejich webových prohlížečů), kde na každém řádku je vždy jeden příkaz. 
Příkazy se zpracovávají jeden po druhém, výsledek zpracování každého příkazu se vypíše ve formě HTML na standardní výstup. 

Vzor vstupu:
2. část

GET 1 http://www.nezarka.net/Books
GET 2 http://www.nezarka.net/Books
GET 2 http://www.nezarka.net/Books/Detail/3
GET 2 http://www.nezarka.net/ShoppingCart/Add/3
GET 1 http://www.nezarka.net/ShoppingCart
GET 1 http://www.nezarka.net/Books/Detail/4
GET 1 http://www.nezarka.net/ShoppingCart/Add/4
GET 1 http://www.nezarka.net/Books
GET 2 http://www.nezarka.net/ShoppingCart/Remove/2
GET 2 http://www.nezarka.net/ShoppingCart/Remove/1
GET 2 http://www.nezarka.net/ShoppingCart/Remove/5
