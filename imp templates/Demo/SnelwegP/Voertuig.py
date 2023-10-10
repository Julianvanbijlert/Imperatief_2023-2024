from PIL.ImageDraw import Draw

class Voertuig:
    pass

class PersonenAuto(Voertuig):
    def Teken(self,draw, x, y):
        draw.rectangle(((x,y-20),(x+40,y-5)), fill="blue")
        draw.rectangle(((x+10,y-30),(x+30,y-20)), fill="blue")
        draw.ellipse(((x+5,y-10),(x+15,y)), fill="red")
        draw.ellipse(((x+25,y-10),(x+35,y)), fill="red")

class Vrachtwagen(Voertuig):
    def Teken(self,draw,x,y):
        draw.rectangle(((x,y-45),(x+50,y-5)), fill="green")
        draw.rectangle(((x+50,y-35),(x+70,y-5)), fill="darkgreen")
        draw.ellipse(((x+5,y-10),(x+15,y)), fill="red")
        draw.ellipse(((x+20,y-10),(x+30,y)), fill="red")
        draw.ellipse(((x+55,y-10),(x+65,y)), fill="red")

class Combinatie(Vrachtwagen):
    def Teken(self,draw,x,y):
        super().Teken(draw,x,y)
        draw.line(((x-5,y-10),(x,y-10)),fill="black")
        draw.rectangle(((x-45,y-45),(x-5,y-5)), fill="green")
        draw.ellipse(((x-40,y-10),(x-30,y)), fill="red")
        draw.ellipse(((x-20,y-10),(x-30,y)), fill="red")