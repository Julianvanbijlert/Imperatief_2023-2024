from tkinter       import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

scherm = Frame()
scherm.master.title("$projectname$")
scherm.configure(background="lightblue")
scherm.configure(width=224, height=224)
scherm.pack()

# met een Image kun je een plaatje opslaan in het geheugen
plaatje = Image.new(mode="RGBA", size=(200,200))

# je kunt de losse pixels van het plaatje manipuleren
plaatje.putpixel((10,10), (255,0,0) )

# maar om complexere figuren te tekenen heb je een Draw nodig
tekenaar = Draw(plaatje)
tekenaar.ellipse( ((30,40),(130,90)), "blue")

# het PIL-Image moet eerst nog worden omgezet naar een Tk-PhotoImage
omgezetPlaatje = PhotoImage(plaatje)

# een Label kan ook gebruikt worden om een PhotoImage te laten zien
afbeelding = Label(scherm)
afbeelding.place(x=10, y=10)
afbeelding.configure(background="white")
afbeelding.configure(image=omgezetPlaatje)

scherm.mainloop()
