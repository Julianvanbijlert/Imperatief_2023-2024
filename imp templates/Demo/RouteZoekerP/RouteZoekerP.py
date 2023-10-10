from tkinter import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

from Netwerk import Netwerk


class RouteZoekerP(Frame):
    def __init__(self):
        super().__init__()

        self.netwerk = Netwerk()
        self.netwerk.Lees("Spoor.txt")

        self.master.title("RouteZoekerP")
        self.configure(background="lightblue")
        self.configure(width=660, height=680)
        self.pack()

        self.afbeelding = Label(self)
        self.afbeelding.place(x=0, y=0)
        self.afbeelding.configure(width=660, height=680, background="white")
        self.afbeelding.bind("<Button-1>", self.klik)

        self.Stad1 = None
        self.Pad = None
        self.teken()

    def klik(self, ea):
        stad = self.netwerk.VindStadPoint((ea.x, ea.y))
        if stad:
            if self.Stad1:
                self.Pad = self.netwerk.ZoekPad(self.Stad1, stad)
                self.Stad1 = None
            else:
                self.Stad1 = stad
        self.teken()

    def teken(self):
        plaatje = Image.new(mode="RGBA", size=(660,680))
        draw = Draw(plaatje)
        self.netwerk.Teken(draw)
        if self.Stad1:
            self.Stad1.Teken(draw, "blue")
        if self.Pad:
            self.Pad.Teken(draw, "red")
        self.foto = PhotoImage(plaatje)
        self.afbeelding.configure(image=self.foto)

