from datetime import datetime
import math

print("Wat is je naam? ", end="")
naam = input()
naamInHoofdletters = naam.upper()
print(f"{naamInHoofdletters}!!!")

print("Wat is je geboortedag? ", end="")
ingetikteDag = input()
dag = int(ingetikteDag)
print("in welke maand? ", end="")
maand = int(input())
print("in welk jaar? ", end="")
jaar = int(input())

datum = datetime(jaar, maand, dag)
print(f"Dat was de {datum.isoweekday()}e dag van de week.")
vandaag = datetime.now()
print(f"Vandaag is de {vandaag.isoweekday()}e dag van de week.")
print(f"Het jaar is {vandaag.year}")

print("Geef een lengte: ", end="")
lengte = float(input())
print("Geef een breedte: ", end="")
breedte = float(input())
diagonaal = math.sqrt(lengte**2 + breedte**2)
print(f"De diagonaal is: {diagonaal}")

print("Geef een hoek in graden: ", end="")
hoekGraden = float(input())
hoekRadialen = hoekGraden * math.pi / 180
print(f"Sinus is: {math.sin(hoekRadialen)} Cosinus is: {math.cos(hoekRadialen)}")

print("Geef een aantal dagen: ", end="")
aantal  = int(input())
weken   = aantal // 7
restant = aantal %  7
print(f"Dat is {weken} weken en {restant} dagen")

afscheid = 10 * "doei! "
print(afscheid)