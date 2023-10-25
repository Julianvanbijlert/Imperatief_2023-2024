import math

def vraagGetal(vraag):
    print(vraag + ": ", end="")
    regel = input()
    return float(regel)

def kwadraat(x):
    return x * x

def cirkelOppervlakte(straal):
    return math.pi * kwadraat(straal)

def oppervlakteInterview():
    r = vraagGetal("Geef de straal van een cirkel")
    print(f"De oppervlakte is: {cirkelOppervlakte(r)}")

oppervlakteInterview()
oppervlakteInterview()