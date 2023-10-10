from tkinter import Frame, Scale, Button

scherm = Frame()
scherm.master.title("ThermoP")
scherm.configure(width=200, height=390)
scherm.pack()

minimum = Scale(scherm, from_=50, to=-50, orient="vertical", length=328, background="skyblue")
huidige = Scale(scherm, from_=50, to=-50, orient="vertical", length=328, background="white")
maximum = Scale(scherm, from_=50, to=-50, orient="vertical", length=328, background="tomato")
reset   = Button(scherm, text="Reset", width=20)

minimum.place(x= 10,y= 10)
huidige.place(x= 60,y= 10)
maximum.place(x=110,y= 10)
reset  .place(x= 10,y=350)

def veranderd(waarde):
    x = huidige.get()
    if x<minimum.get():
        minimum.set(x)
    if x>maximum.get():
        maximum.set(x)

def klik():
    minimum.set(huidige.get())
    maximum.set(huidige.get())

huidige.configure(command=veranderd)
reset  .configure(command=klik)
scherm.mainloop()