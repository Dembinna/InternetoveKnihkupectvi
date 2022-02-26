# InternetoveKnihkupectvi
Program Internetové knihkupectví s názvem Nežárka je nedokončená verze, aplikace nebyla zamíšlena jako ukázka a tak chybí komentáře.
Je zde použitý MVC struktura kódu. Tento program je základem e-shopu internetového knihkupectví 
Nežárka.NET - aplikace představuje implementaci logiky na straně webového serveru. Po spuštění obdrží aplikace
na standardním vstupu textový popis dat e-shopu (tedy vlastně reprezentaci dat z relační databáze) v následujícím formátu:

Vzor vstupu:
1. část

DATA-BEGIN <br />
BOOK;1;Lord of the Rings;J. R. R. Tolkien;59 <br />
BOOK;2;Hobbit: There and Back Again;J. R. R. Tolkien;49 <br />
BOOK;3;Going Postal;Terry Pratchett;28 <br />
BOOK;4;The Colour of Magic;Terry Pratchett;159 <br />
BOOK;5;I Shall Wear Midnight;Terry Pratchett;31 <br />
CUSTOMER;1;Klara;Dembinna <br />
CUSTOMER;2;Jan;Novak <br />
CUSTOMER;3;Lukas;Novotny <br />
CUSTOMER;4;Tomas;Tomas <br />
CART-ITEM;2;1;3 <br />
CART-ITEM;2;5;1 <br />
DATA-END <br />

Po načtení vstupních dat dostává aplikace na standardním vstupu příkazy od klientů systému (jejich webových prohlížečů), kde na každém řádku je vždy jeden příkaz. 
Příkazy se zpracovávají jeden po druhém, výsledek zpracování každého příkazu se vypíše ve formě HTML na standardní výstup. 

Vzor vstupu:
2. část

GET 1 http://www.nezarka.net/Books <br />
GET 2 http://www.nezarka.net/Books <br />
GET 2 http://www.nezarka.net/Books/Detail/3 <br />
GET 2 http://www.nezarka.net/ShoppingCart/Add/3 <br />
GET 1 http://www.nezarka.net/ShoppingCart <br />
GET 1 http://www.nezarka.net/Books/Detail/4 <br />
GET 1 http://www.nezarka.net/ShoppingCart/Add/4 <br />
GET 1 http://www.nezarka.net/Books <br />
GET 2 http://www.nezarka.net/ShoppingCart/Remove/2 <br />
GET 2 http://www.nezarka.net/ShoppingCart/Remove/1 <br />
GET 2 http://www.nezarka.net/ShoppingCart/Remove/5 <br />
