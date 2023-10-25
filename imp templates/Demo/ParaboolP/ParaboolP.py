from tkinter import Frame, Label, Entry
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
import math

scherm = Frame()
scherm.master.title("ParaboolP")
scherm.configure(width=470, height=320)
scherm.pack()

font=("Arial", 16)
labA = Label(scherm, font=font, text="a:");  labA.place(x=10,y= 20);
labB = Label(scherm, font=font, text="b:");  labB.place(x=10,y= 60);
labC = Label(scherm, font=font, text="c:");  labC.place(x=10,y=100);
boxA = Entry(scherm, font=font, width=6);    boxA.place(x=40,y= 20); boxA.insert(0, str(0.5))
boxB = Entry(scherm, font=font, width=6);    boxB.place(x=40,y= 60); boxB.insert(0, str(1  ))
boxC = Entry(scherm, font=font, width=6);    boxC.place(x=40,y=100); boxC.insert(0, str(-3 ))
grafiek = Label(scherm, background="khaki"); grafiek.place(x=160,y=10)
nulpunt = Label(scherm);                     nulpunt.place(x=10,y=150)

a=0; b=0; c=0   # globale toestand-variabelen
breed=300; hoog=300

def functie(x):
    return a*x*x + b*x + c

def oplossingen():
    discr  = b*b - 4*a*c
    noemer = 2*a
    if noemer == 0: return "rechte lijn!"
    if discr  < 0 : return "geen nulpunten"
    if discr  == 0: return f"een nulpunt:\n{-b/noemer}"
    wortel = math.sqrt(discr)
    return f"twee nulpunten:\n{(-b-wortel)/noemer}\nen\n{(-b+wortel)/noemer}";

def tekenGrafiek():
    plaatje = Image.new(mode="RGBA", size=(breed,hoog))
    draw = Draw(plaatje)

    xMid = breed//2
    yMid = hoog//2
    schaal = 0.04

    # assen
    draw.line(((0,yMid),(breed,yMid)), fill="red")
    draw.line(((xMid,0),(xMid,hoog)), fill="red")

    # grafiek van de parabool
    for xPixel in range(-1, breed):
        xWaarde = (xPixel-xMid)*schaal
        yWaarde = functie(xWaarde)
        yPixel = int(yMid - (yWaarde/schaal))
        if xPixel>0:
            draw.line(((xPixel-1,yVorigePixel),(xPixel,yPixel)), fill="blue", width=2)
        yVorigePixel = yPixel

    global foto
    foto = PhotoImage(plaatje)
    grafiek.configure(image=foto)

def boxVeranderd(ea):
    global a, b, c
    try:
        a = float(boxA.get()); boxA.configure(background="white")
        b = float(boxB.get()); boxB.configure(background="white")
        c = float(boxC.get()); boxC.configure(background="white")
        tekenGrafiek()
        nulpunt.configure(text=oplossingen())
    except Exception as exc:
        ea.widget.configure(background="tomato")
        nulpunt.configure(text=str(exc))

boxA.bind("<KeyRelease>", boxVeranderd)
boxB.bind("<KeyRelease>", boxVeranderd)
boxC.bind("<KeyRelease>", boxVeranderd)

boxVeranderd(None)
scherm.mainloop()