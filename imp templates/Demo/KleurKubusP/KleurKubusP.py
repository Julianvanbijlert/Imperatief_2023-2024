from tkinter import Frame, Label, Scale
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

scherm = Frame()
scherm.master.title("KleurKubusP")
scherm.configure(width=556, height=604)
scherm.pack()

plaatje = Image.new(mode="RGBA", size=(512,512))
draw    = Draw(plaatje)
kubus   = Label(scherm)
schuif  = Scale(scherm, from_=0, to=255, orient="horizontal", length=512)
kubus. place(x=20, y=20)
schuif.place(x=20, y=542)

def TekenKubus(blauw):
    for x in range(0,16):
        rood = 17*x
        for y in range(0,16):
            groen = 17*y
            kleur = (rood, groen, blauw)
            draw.rectangle(((32*x,32*y),(32*(x+1),32*(y+1))), kleur)
    global omgezetPlaatje
    omgezetPlaatje = PhotoImage(plaatje)
    kubus.configure(image=omgezetPlaatje)

def VeranderSchuif(waarde):
    TekenKubus(int(waarde))

schuif.configure(command=VeranderSchuif)
TekenKubus(0)
scherm.mainloop()