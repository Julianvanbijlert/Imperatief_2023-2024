from tkinter import Frame, Button, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
from threading import Thread
import time

class Simulatie(Frame):

    def __init__(self):
        super().__init__()
        self.master.title("SimulatieP")
        self.configure(width=406, height=280)
        self.pack()

        self.beweegt = False

        self.r1   = Ruimte(self, ( 80, 150))
        self.r2   = Ruimte(self, (296, 120))
        self.r3   = Ruimte(self, (386, 100))
        self.stap = Button(self, text="stap")
        self.auto = Button(self, text="start")

        self.r1  .place(x =10,y= 10)
        self.r2  .place(x=100,y= 10)
        self.r3  .place(x= 10,y=170)
        self.stap.place(x=100,y=140)
        self.auto.place(x=200,y=140)

        self.stap.configure(command=self.stapKlik)
        self.auto.configure(command=self.autoKlik)

    def stapKlik(self):
        self.r1.DoeStap()
        self.r2.DoeStap()
        self.r3.DoeStap()

    def autoKlik(self):
        if self.beweegt:
            self.beweegt = False              # laat de animatie uitdoven
            self.auto.configure(text="Start") # sta weer klaar voor een nieuwe start
        else:
            self.beweegt=True
            self.auto.configure(text="Stop")
            animatie = Thread(target=self.filmpje)
            animatie.start()

    def filmpje(self):
        while self.beweegt:
            self.stapKlik()    # doe wat zou gebeuren bij indrukken stap-knop
            time.sleep(0.050)

class Ruimte(Label):

    def __init__(self, parent, size):
        super().__init__(parent)
        self.configure(background="lightblue")

        self.size = size
        self.d1 = Deeltje("red",    30, 40, 10,  10)
        self.d2 = Deeltje("green", 100, 80,  5, -10)
        self.d3 = Deeltje("blue",  200, 60,  8,   2)
        self.tekenRuimte()

    def DoeStap(self):
        self.d1.DoeStap(self.size)
        self.d2.DoeStap(self.size)
        self.d3.DoeStap(self.size)
        self.tekenRuimte()

    def tekenRuimte(self):
        plaatje = Image.new(mode="RGBA", size=self.size)
        draw = Draw(plaatje)
        self.d1.TekenDeeltje(draw)
        self.d2.TekenDeeltje(draw)
        self.d3.TekenDeeltje(draw)
        self.foto = PhotoImage(plaatje)
        self.configure(image=self.foto)

class Deeltje:

    def __init__(self, kleur0, x0, y0, dx0, dy0):
        self.kleur = kleur0
        self.x = x0
        self.y = y0
        self.dx = dx0
        self.dy = dy0

    def TekenDeeltje(self, draw):
        draw.ellipse(((self.x-5, self.y-5),(self.x+5, self.y+5)), self.kleur)

    def DoeStap(self, hok):
        (width,height) = hok
        self.x += self.dx
        self.y += self.dy
        if self.x < 0: 
            self.x = -self.x
            self.dx = -self.dx
        elif self.x >= width:
            self.x = 2*width - self.x
            self.dx = -self.dx
        if self.y < 0:
            self.y = -self.y
            self.dy = -self.dy
        elif self.y >= height:
            self.y = 2*height - self.y
            self.dy = -self.dy