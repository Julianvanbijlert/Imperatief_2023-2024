# Dit programma tekent drie huizen van divers formaat
from tkinter       import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

# eerst de gebruikelijke opdrachten om een plaatje te kunnen tonen
scherm = Frame()
scherm.master.title("HuizenP")
scherm.configure(width=224, height=124)
scherm.pack()
plaatje = Image.new(mode="RGBA", size=(220,120))
afbeelding = Label(scherm)
afbeelding.place(x=0, y=0)
afbeelding.configure(background="white")
draw = Draw(plaatje)

# een hulpfunctie om een enkel huis te tekenen
def TekenHuis(x, y, breedte):
    topx = x + breedte/2
    topy = y - 3*breedte/2
    afdak = breedte/6
    randy = y - breedte + afdak

    # de muur
    draw.rectangle( ((x,y-breedte),(x+breedte,y)), fill="lightgreen", outline="green")
    # het dak
    draw.line( ((x-afdak, randy), (topx, topy)), fill="red", width=3)
    draw.line( ((topx, topy), (x+breedte+afdak, randy)), fill="red", width=3)

# nu gaan we het eigenlijke plaatje tekenen, door de hulpfunctie driemaal aan te roepen
TekenHuis( 20, 100, 40)
TekenHuis( 80, 100, 40)
TekenHuis(140, 100, 60)

omgezetPlaatje = PhotoImage(plaatje)
afbeelding.configure(image=omgezetPlaatje)
scherm.mainloop()
