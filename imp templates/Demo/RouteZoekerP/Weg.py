from PIL.ImageFont import truetype
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage

class Weg:
    def __init__(self, doel, kosten):
        self.Doel = doel
        self.Kosten = kosten

    def Teken(self, draw, kleur, stad):
        draw.line((stad.Plek, self.Doel.Plek), fill=kleur)
