using System;

Kleur wit = new Kleur();
Kleur paars = new Kleur(Kleur.Maximaal, 0, Kleur.Maximaal);
Kleur oranje = new Kleur(255, 128, 0);
Kleur lichtgrijs = new Kleur(180);
Kleur donkergrijs = new Kleur(60);

byte x = oranje.Grijswaarde();
Kleur oranjeInZwartwit = new Kleur(x);

oranje.MaakDonkerder();
string s = oranje.ToString();
Kleur terugGelezen = new Kleur(s);

Kleur donkerPaars = paars.DonkerdereVersie();
Kleur donkerGeel = Kleur.Geel.DonkerdereVersie();

Console.WriteLine($"Wit: {wit}");
Console.WriteLine($"Lichtgrijs: {lichtgrijs}");
Console.WriteLine($"DonkerOranje: {oranje}");
Console.WriteLine($"TerugGelezen: {terugGelezen}");
Console.WriteLine($"Paars: {paars}");
Console.WriteLine($"DonkerPaars: {donkerPaars}");
Console.WriteLine($"DonkerGeel: {donkerGeel}");