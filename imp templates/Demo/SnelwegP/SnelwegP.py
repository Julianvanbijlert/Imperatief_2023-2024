from tkinter import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
from Voertuig import Voertuig, PersonenAuto, Vrachtwagen, Combinatie

class Snelweg(Frame):

    def __init__(self):
        super().__init__()
        self.master.title("SnelwegP")
        self.configure(width=1800, height=84, background="yellow")
        self.pack()
        self.afbeelding = Label(self)
        self.afbeelding.place(x=0, y=0)
        self.afbeelding.configure(width=1800, height=80, background="lightgrey")

        # initialisatie membervariabele
        self.rijbaan = list()
        self.maakBeginSituatie()          
        self.tekenSnelweg()

    def maakBeginSituatie(self):
        for t in range(0,15):
            if t%3 != 0:
                self.rijbaan.append(PersonenAuto())
            elif t%6 == 0:
                self.rijbaan.append(Vrachtwagen())
            else:
                self.rijbaan.append(Combinatie())

    def tekenSnelweg(self):
        plaatje = Image.new(mode="RGBA", size=(1800,80))
        draw = Draw(plaatje)
        t = 0
        for voertuig in self.rijbaan:
            voertuig.Teken(draw, t*120, 60)
            t += 1
        self.foto = PhotoImage(plaatje)
        self.afbeelding.configure(image=self.foto)

Snelweg().mainloop()