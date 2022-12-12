NET Web Development 16 - Finalni test
Korišćenjem radnih okvira ASP.NET Core Web API (.NET 5.0), Entity Framework Core i 
Bootstrap i Fetch API-a realizovati Web aplikaciju za evidenciju zgrada i njihovih stanova koji se 
prodaju. Aplikacija treba da obezbedi rad sa sledećim entitetima:


Zgrada:
 Id - Identifikator
 Adresa - obavezna tekstualna vrednost sa manje od 120 karaktera
 Godina izgradnje - obavezna celobrojna vrednost manja od 2022, a veća ili jednaka od
1930


Stan:
 Id – Identifikator
 Broj stana - obavezna tekstualna vrednost sa najmanje 2 karaktera, a najviše 100
karaktera
 Tip stana - obavezna tekstualna vrednost sa najmanje 2 karaktera, a najviše 20 karaktera
 Broj kvadrata – obavezna celobrojna vrednost iz intervala [11, 300]
 Cena stana – obavezna celobrojna vrednost iz intervala [10 000, 300 000]
 Zgrada - veza sa instancom klase Zgrada (jedan stan može se nalaziti u samo jednoj
zgradi, dok jedna zgrada može imati više stanova)


Polazniku se ostavlja potpuna sloboda prilikom imenovanja entiteta i njihovih polja.
1) Pomoću radnih okvira ASP.NET Core Web API i Entity Framework Core implementirati sledeći 
REST API, vodeći računa da se kod rezultata odgovarajućih akcija za povezani objekat ne 
prikazuje nedostajuća vrednost (null):
a) GET api/zgrade - preuzimanje svih Zgrada sortiranih po Adresi rastuće;
b) GET api/zgrade/{id} - preuzimanje Zgrade po zadatom id-u;
c) GET api/ponuda?granica={vrednost} - preuzimanje svih Zgrada sa prosečnom cenom
svih Stanova koji pripadaju nekoj Zgradi, pri čemu je prosečna cena veća od vrednosti 
granice, a sortiranih prema Adresi Zgrade opadajuće;
d) GET api/stanje – preuzimanje svih Zgrada i broja Stanova koje poseduju, sortirano po 
broju Stanova opadajuće;
e) GET api/zgrade/nadji?adresa={vrednost} - preuzimanje svih Zgrada čija Adresa sadrži
prosleđenu vrednost adresa, sortirano prema Godini izgradnje opadajuće, a u slučaju da 
su dve Zgrade izgrađene iste godine, njih u tom slučaju sortirati po Adresi rastuće;
f) GET api/stanovi - preuzimanje svih Stanova, sortirano po Broju kvadrata rastuće;
g) GET api/stanovi/{id} - preuzimanje Stana po zadatom id-u;
h) GET api/stanovi/trazi?tip={vrednost} - preuzimanje svih Stanova čiji Tip stana je jednak
prosleđenoj vrednosti tip, sortirano prema Ceni stana rastuće;
i) POST api/stanovi - dodavanje novog Stana;
j) PUT api/stanovi/{id} - izmena postojećeg Stana;
k) DELETE api/stanovi/{id} - brisanje postojećeg Stana;
l) POST api/pretraga - preuzimanje svih Stanova sa Cenom stana između dve unete 
vrednosti [najmanje, najvise], sortirano tako da se prvo prikazuju skuplji (sortirano prema
Ceni opadajuće);
m) Registracija i prijava korisnika.
2) Jedinično testirati sledeće funkcionalnosti:
a) Funkcionalnost 1) g) sa jediničnim testom kada akcija vraća status kod 200 i objekat;
b) Funkcionalnost 1) j) sa jediničnim testom kada akcija vraća status kod 400;
c) Funkcionalnost 1) b) sa jediničnim testom kada akcija vraća status kod 404;
d) Funkcionalnost 1) l) sa jediničnim testom kada akcija vraća status kod 200 i više objekata.
3) Pomoću radnog okvira Bootstrap i Fetch API-a realizovati sledeću Single Page Application:
a) Prilikom pokretanja, stranica sadrži poruku da korisnik nije prijavljen, dugmad za prijavu i 
registraciju, kao i tabelarni prikaz Stanova na prodaju po funkcionalnosti 1) f), kao što je 
prikazano na slici 1. Za Zgradu se prikazuje njena Adresa.
Slika 1
b) Ukoliko korisnik pritisne dugme Registracija, prikazaće mu se forma za registraciju
korisnika, kao što je prikazano na slici 2. Ukoliko se korisnik uspešno registrovao, forma 
za registraciju će se očistiti, a korisniku će se prikazati forma za prijavu, čiji su izgled i 
ponašanje opisani u funkcionalnosti 3) c). Ukoliko je došlo do greške prilikom registracije, 
korisnik će biti obavešten pomoću alert-a “Greska prilikom registracije!”. Klikom na 
dugme Odustajanje korisniku se prikazuje sadržaj iz funkcionalnosti 3) a).
 
Slika 2
c) Ukoliko korisnik pritisne dugme Prijava sa početne strane aplikacije ili kada se korisnik 
uspešno registruje na sistem, prikazaće mu se forma za prijavu korisnika kao što je 
prikazano na slici 3. Ukoliko je došlo do greške prilikom prijave, potrebno je obavestiti 
korisnika pomoću alert-a “Greska prilikom prijave!”. Ukoliko se korisnik uspešno prijavi 
na sistem, forma za prijavu se čisti i prikazuje mu se sadržaj sa slike 4. Klikom na dugme 
Odustajanje korisniku se prikazuje sadržaj iz funkcionalnosti 3) a).
Slika 3
d) Nakon labele Prijavljeni korisnik se prikazuje korisničko ime prijavljenog korisnika. Klikom 
na dugme Odjava korisnik se odjavljuje sa sistema i nakon toga mu se prikazuje sadržaj 
opisan u 3) a).
e) Tabela Stanova se proširuje sa još dve kolone sa desne strane, koje za svaki Stan sadrže
Broj stana i dugme Obriši. Klikom na dugme Obriši se briše odabrani Stan i osvežava 
prikaz u tabeli. Ovu akciju može da vrši samo prijavljeni korisnik.
f) Iznad tabele se nalazi forma za pretragu Stanova koja prati funkcionalnost 1) l). Ovu akciju 
može da vrši samo prijavljeni korisnik. Stanovi koji ispunjavaju kriterijum pretrage se 
prikazuju u tabeli Stanova i moguće je njihovo brisanje kao što je opisano u funkcionalnosti 
3) e). Ukoliko je došlo do greške prilikom unosa kriterijuma za pretragu ili samog 
dobavljanja Stana sa REST API-a, korisnika obavestiti putem alert-a “Greska prilikom 
pretrage!”.
g) Ispod tabele Stanova se prikazuje forma za dodavanje novog Stana, koja prati 
funkcionalnost 1) i), kao što je prikazano na slici 4. Ovu akciju može da vrši samo 
prijavljeni korisnik. Zgrada se bira iz padajućeg menija koji se popunjava pomoću 
funkcionalnosti 1) a). U padajućem meniju se prikazuje Adresa Zgrade. Klikom na dugme 
Dodavanje vrši se dodavanje novog Stana. Ukoliko je dodavanje bilo uspešno, forma za
dodavanje će se očistiti, a u tabeli Stanova će se osvežiti prikaz. Ukoliko je došlo do greške 
prilikom unosa podataka ili prilikom komunikacije sa REST API-em, korisnik će se 
obavestiti putem alert-a “Greska prilikom dodavanja!”. Klikom na dugme Odustajanje
čiste se polja u formi za dodavanje.
Slika 4
Napomene:
 Test nosi 100 bodova, za polaganje testa je neophodno osvojiti 50 
bodova uz poštovanje uslova za pregled testa.
 Uslov za pregled testa je implementiranje funkcionalnosti 1) a), 
1) f) i 3) a).
 Zabranjena je upotreba Scaffolding-a. Sve funkcionalnosti koje su 
scaffold-ovane ili na neki način koriste scaffold-ovanu funkcionalnost 
bodovaće se sa 0 bodova.
 Ako ima potrebe, a u skladu sa dobrom programerskom praksom,
koristiti AutoMapper, Dependency Injection koncept i Repository 
šablon.
 Svaka komunikacija sa kolegama je najstrožije zabranjena!
 Projekat se predaje u zip arhivi ImePrezime.zip (obrisati foldere bin i 
obj pre kreiranja arhive).
 Koristeći Code First migracije popuniti bazu podataka sledećim 
podacima:
o Zgrade
Id Adresa Godina izgradnje
1 Ulica Marka Miljanova 14 2017
2 Bulevar cara Lazara 113 2020
3 Ulica Koste Racina 4 2017
o Stanovi na prodaju
Id Broj stana Tip stana Broj kvadrata Cena
stana Zgrada
1 001 Garsonjera 23 105 000 3
2 124 Dvosoban 51 47 000 1
3 003 Trosoban 75 180 000 2
4 311 Dupleks 114 170 000 3
5 103 Dvosoban 43 42 000 1



Bodovanje:
Funkcionalnost Bodovi
Model Zgrada 2
Model Stan 4
Code first migracije i unos podataka 2
1) a) 2
1) b) 3
1) c) 7
1) d) 5
1) e) 4
1) f) 2
1) g) 3
1) h) 4
1) i) 3
1) j) 3
1) k) 3
1) l) 5
1) m) 3
2) a) 3
2) b) 2
2) c) 2
2) d) 3
3) a) 5
3) b) 4
3) c) 5
3) d) 3
3) e) 4
3) f) 7
3) g) 7
Ukupno 10
