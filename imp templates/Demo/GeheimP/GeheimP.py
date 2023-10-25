from tkinter import Frame, Entry, Label
from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image

scherm = Frame()
scherm.master.title("GeheimP")
scherm.configure(width=200, height=200)
scherm.pack()

geraden = False      # globale toestand-variabele
sleutel = "geheim";

label = Label(scherm);      label.place(x=0,y=0);        label.configure(width=200,height=200)
wachtwoord = Entry(scherm); wachtwoord.place(x=65,y=15); wachtwoord.configure(show='*')

def teken():
    plaatje = Image.new(mode="RGBA", size=(300,300))
    draw = Draw(plaatje)
    if geraden :
        draw.ellipse(((100,100),(200,200)), fill="yellow")
        draw.ellipse(((131,135),(139,143)), fill="blue")
        draw.ellipse(((161,135),(169,143)), fill="blue")
        draw.arc(((125,125),(175,175)),45,135, fill="blue", width=3)
    else:
        draw.text((100,100), "please enter password", fill="black")
    global foto
    foto = PhotoImage(plaatje)
    label.configure(image=foto)

def veranderd(ea):
    if wachtwoord.get() == sleutel:
        global geraden
        geraden = True
        wachtwoord.lower(label) # maak de entry onzichtbaar door hem onder het label te zetten
                                # (met .lift ligt hij weer zichtbaar bovenop)
        teken()

wachtwoord.bind("<KeyRelease>", veranderd)
teken()
scherm.mainloop()