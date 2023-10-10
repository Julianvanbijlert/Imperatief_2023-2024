from tkinter import Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
from threading import Thread
import time
from Bitmap import Bitmap

class BitmapControl(Label):
    def __init__(self, parent):
        super().__init__(parent)
        self.model = Bitmap(20,20)
        self.bind("<Button-1>", self.klik)
        self.bind("<B1-Motion>", self.klik)
        self.bind("<Button-3>", self.klik)
        self.bind("<B3-Motion>", self.klik)
        self.bind("<Configure>", self.vergroot)

    def vergroot(self, ea):
        self.Teken()

    def Diameter(self):
        return min( (self.winfo_width()-1)  // self.model.Breedte, 
                    (self.winfo_height()-1) // self.model.Hoogte)

    def Teken(self):   
        w = self.model.Breedte
        h = self.model.Hoogte
        d = self.Diameter()

        plaatje = Image.new(mode="RGBA", size=(self.winfo_width(),self.winfo_height()))
        draw    = Draw(plaatje)
        
        for y in range(0,h+1):
            draw.line(((0,y*d),(w*d,y*d)), (0,0,255))
        for x in range(0,w+1):
            draw.line(((x*d,0),(x*d,h*d)), (0,0,255))

        for y in range(0,h):
            for x in range(0,w):
                if self.model.vraagKleur(x, y):
                    draw.rectangle(((x*d+1),(y*d+1),(x*d+d-1,y*d+d-1)), (255,0,0))

        self.foto = PhotoImage(plaatje)
        self.configure(image=self.foto)

    def klik(self, mea):
        d = self.Diameter()
        x = mea.x // d
        y = mea.y // d
        if 0<=x<self.model.Breedte and 0<=y<self.model.Hoogte:
            self.model.veranderKleur(x, y, mea.num==1 or (mea.state&256))
        self.Teken()

    def Left(self):
        self.model.Left()
        self.Teken()
    def Right(self):
        self.model.Right()
        self.Teken()
    def Up(self):
        self.model.Up()
        self.Teken()
    def Down(self):
        self.model.Down()
        self.Teken()
    def Clear(self):
        self.model.Clear()
        self.Teken()
    def Invert(self):
        self.model.Invert()
        self.Teken()
    def Bold(self):
        self.model.Bold()
        self.Teken()
    def Outline(self):
        self.model.Outline()
        self.Teken()
    def Life(self):
        self.model.Life()
        self.Teken()

    def Filmpje(self):
        while self.beweegt:
            self.Life()
            time.sleep(0.030)

    def Starten(self):
        self.beweegt = True
        Thread(target=self.Filmpje).start()

    def Stoppen(self):
        self.beweegt = False