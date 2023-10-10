from tkinter       import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
import math

diameter = 15
straal = diameter//2
rate = 0.99

class VervagendP(Frame):

    def __init__(self):
        super().__init__()
        self.master.title("VervagendP")
        self.configure(width=206, height=206)
        self.pack()

        self.afbeelding = Label(self)
        self.afbeelding.place(x=0, y=0)
        self.afbeelding.configure(width=200, height=200, background="white")
        self.afbeelding.bind("<B1-Motion>", self.beweeg)
        
        # initialisatie membervariabele
        self.punten = list()

    def beweeg(self, ea):
        self.punten.append((ea.x, ea.y))
        self.teken()

    def teken(self):
        plaatje = Image.new(mode="RGBA", size=(200,200))
        draw = Draw(plaatje)
        n = len(self.punten)
        t = 0
        for punt in self.punten:
            (x,y) = punt
            k = int(255 - 255 * math.pow(rate, n-t-1))
            kleur = (k,k,k)
            draw.ellipse(((x-straal,y-straal),(x+straal,y+straal)), fill=kleur)
            t += 1
        if n>0:
            xs = [x for (x,y) in self.punten]
            ys = [y for (x,y) in self.punten]
            minX = min(xs) - straal
            minY = min(ys) - straal
            maxX = max(xs) + straal
            maxY = max(ys) + straal
            draw.rectangle(((minX,minY),(maxX,maxY)), width=2, outline="blue")
        self.foto = PhotoImage(plaatje)
        self.afbeelding.configure(image=self.foto)

VervagendP().mainloop()