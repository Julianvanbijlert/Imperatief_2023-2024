from tkinter       import Frame, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

scherm = Frame()
scherm.master.title("SchilderenP")
scherm.configure(width=204, height=204)
scherm.pack()
plaatje = Image.new( mode="RGBA"
                   , size=(200,200))
draw = Draw(plaatje)
afbeelding = Label(scherm)

afbeelding.place(x=0, y=0)
afbeelding.configure(width=200, height=200)


def muisKlik(ea):
    draw.ellipse(((ea.x-5, ea.y-5)
                 ,(ea.x+5, ea.y+5)), "blue")
    global foto
    foto = PhotoImage(plaatje)
    afbeelding.configure(image=foto)


afbeelding.bind("<Button-1>", muisKlik)
scherm.mainloop()
