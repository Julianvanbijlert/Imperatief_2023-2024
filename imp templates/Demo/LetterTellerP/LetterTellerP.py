from tkinter import Frame, Text, Label
from TurfTab import TurfTab
from StaafDiagram import StaafDiagram

class LetterTeller(Frame):
    def __init__(self):
        super().__init__()
        self.master.title("LetterTellerP")
        self.configure(width=320, height=560)
        self.pack()

        self.invoer  = Text(self)
        self.uitvoer = Label(self)
        self.diagram = StaafDiagram(self)

        self.invoer .place(x=10, y= 10)
        self.uitvoer.place(x=10, y=120)
        self.diagram.place(x=90, y=120)

        self.uitvoer.configure(justify="left")
        self.invoer.configure(width=36, height=6)
        self.invoer.bind("<KeyRelease>", self.berekenAntwoord)

    def berekenAntwoord(self, ea):
        tabel = TurfTab()
        tabel.Turf(self.invoer.get("1.0", "end"))   # "1.0" in Text is regel 1, positie 0
        self.uitvoer.configure(text=str(tabel))
        self.diagram.Waardes = tabel.Waardes