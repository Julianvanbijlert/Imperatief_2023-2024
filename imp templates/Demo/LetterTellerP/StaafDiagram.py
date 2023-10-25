from tkinter import Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

class StaafDiagram(Label):
    def __init__(self, parent):
        super().__init__(parent)
        self.waardes = None

    def setWaardes(self, v):
        self.waardes = v
        self.teken()

    Waardes = property(fset=setWaardes)

    def teken(self):
        plaatje = Image.new(mode="RGBA", size=(210,390))
        draw    = Draw(plaatje)
        meeste = max(self.waardes)
        if meeste<10:
            meeste = 10
        balkH = 390 / 26
        balkUnit = 210 / meeste
        for t in range(0,26):
            draw.rectangle(((0, t*balkH),(balkUnit*self.waardes[t],(t+1)*balkH-2))
                           , fill="blue")
        self.foto = PhotoImage(plaatje)
        self.configure(image=self.foto)