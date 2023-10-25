from tkinter import Frame, Button, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

scherm = Frame()
scherm.master.title("CirkelGroeiP")
scherm.configure(width=300, height=300)
scherm.pack()

straal = 100  # globale toestands-variabele

label  = Label (scherm); label  .place(x=  0, y=0);  label  .configure(width=300, height=300)
kleiner= Button(scherm); kleiner.place(x= 30, y=20); kleiner.configure(text="Kleiner")
groter = Button(scherm); groter .place(x=200, y=20); groter .configure(text="Groter")

def teken():
    plaatje = Image.new(mode="RGBA", size=(300,300))
    draw = Draw(plaatje)
    draw.ellipse(((150-straal,150-straal),(150+straal,150+straal)), fill="green")
    global foto
    foto = PhotoImage(plaatje)
    label.configure(image=foto)

def klik(ea):
    global straal
    if ea.widget==kleiner and straal>10 :
        straal -= 10
    if ea.widget==groter and straal<150 :
        straal += 10
    teken()

kleiner.bind("<Button-1>", klik)
groter. bind("<Button-1>", klik)
teken()
scherm.mainloop()