from kleurig import kleur
import kleurig

wit = kleur()
paars=kleur(255,0,255)
oranje=kleur(255,128,0)
lichtgrijs = kleur(180)
donkergrijs=kleur(60)

x = oranje.grijswaarde()
oranjeInZwartwit = kleur(x)

oranje.maakDonkerder()
s = str(oranje)
teruggelezen = kleur(s)

donkerpaars = paars.donkerdereVersie()
donkergeel = kleurig.geel.donkerdereVersie()

print(f"Wit: {wit}");
print(f"Lichtgrijs: {lichtgrijs}");
print(f"DonkerOranje: {oranje}");
print(f"TerugGelezen: {teruggelezen}");
print(f"Paars: {paars}");
print(f"DonkerPaars: {donkerpaars}");
print(f"DonkerGeel: {donkergeel}");