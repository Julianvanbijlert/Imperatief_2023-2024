""" Dit programma tekent een Mondriaan-achtige
    "compositie met rood en blauw"
"""
from tkinter       import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

# eerst de gebruikelijke opdrachten om een plaatje te kunnen tonen
scherm = Frame()
scherm.master.title("MondriaanP")
scherm.configure(width=204, height=104)
scherm.pack()
plaatje = Image.new(mode="RGBA", size=(200,100))
afbeelding = Label(scherm)
afbeelding.place(x=0, y=0)
afbeelding.configure(background="white")
draw = Draw(plaatje)

# nu gaan we het eigenlijke plaatje tekenen
breedte = plaatje.width
hoogte = plaatje.height
x1 = 10; x2 = 50; x3 = 90; y1 = 40; y2 = 70; balk = 10

# zwarte balken
draw.rectangle( ((x1,0), (x1+balk,hoogte)),  "black" )
draw.rectangle( ((x2,0), (x2+balk,hoogte)),  "black" )
draw.rectangle( ((x3,0), (x3+balk,hoogte)),  "black" )
draw.rectangle( ((0,y1), (breedte,y1+balk)), "black" )
draw.rectangle( ((0,y2), (breedte,y2+balk)), "black" )

# gekleurde vlakken
draw.rectangle( ((0,y1+balk), (x1,y2)),      "blue" )
draw.rectangle( ((x3+balk,0), (breedte,y1)), "red"  )

omgezetPlaatje = PhotoImage(plaatje)
afbeelding.configure(image=omgezetPlaatje)
scherm.mainloop()
