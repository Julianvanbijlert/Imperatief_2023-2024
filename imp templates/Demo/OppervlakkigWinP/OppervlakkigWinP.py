import math
from tkinter import Frame
from tkinter import Label, Button, Entry

scherm = Frame()
scherm.master.title("OppervlakkigWinP")
scherm.configure(width=240, height=60)
scherm.pack()

tekst    = Label (scherm)
invoer   = Entry (scherm)
knop     = Button(scherm)
uitkomst = Label (scherm)






tekst   .place(x= 60, y= 6)
invoer  .place(x=110, y= 6)
knop    .place(x= 20, y=32)
uitkomst.place(x=110, y=34)

invoer.configure(width=10)



tekst.configure(text="straal:")
knop .configure(text="oppervlakte:")

def kwadraat(x):
    return x * x

def cirkelOppervlakte(straal):
    return math.pi * kwadraat(straal)

def bereken():
    r = float(invoer.get())
    a = cirkelOppervlakte(r)
    uitkomst.configure(text=str(a))


knop.configure(command=bereken)

scherm.mainloop()