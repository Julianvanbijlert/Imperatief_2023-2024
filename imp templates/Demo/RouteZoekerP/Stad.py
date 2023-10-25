from PIL.ImageDraw import Draw
from PIL.ImageFont import truetype
from PIL.ImageTk   import PhotoImage
from PIL           import Image
from Weg import Weg

font = truetype("tahoma.ttf", size=10)

def dist(p1, p2):  # standaardfunctie in math vanaf Python 6.8
    (x1,y1) = p1
    (x2,y2) = p2
    return (x1-x2)**2 + (y1-y2)**2
    # Pythagoras zegt dat we ook nog de wortel moeten trekken
    # maar dat doen we lekker niet, omdt het alleen om de ordening
    # van de afstanden gaat. Die verandert niet door het worteltrekken.


class Stad:
    def __init__(self, naam, plek):
        self.Naam = naam
        self.Plek = plek
        self.Wegen = list()

    def BouwWeg(self, doel, kosten):
        self.Wegen.append(Weg(doel, kosten))

    def Teken(self, draw, kleur):
        (x, y) = self.Plek
        draw.rectangle(((x-5,y-5),(x+5,y+5)), kleur)
        draw.text((x+6, y-15), self.Naam, fill=kleur, font=font)

    def AfstandWegdoelTotStad(self, pad):
        return dist(pad.Doel.Plek, self.Plek)
