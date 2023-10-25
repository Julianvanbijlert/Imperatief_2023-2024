from tkinter import Frame, Button

class Teller(Frame):

    def __init__(self):
        super().__init__()
        self.master.title("TellerP")
        self.configure(background="lightblue")
        self.configure(width=120,height=60)
        self.pack()

        self.hoeveel = 0

        self.knop = Button(self)
        self.knop.place(x=10,y=10)
        self.knop.configure(width=12,height=2)
        self.knop.configure(text="klik hier!")
        self.knop.configure(background="lightgreen")
        self.knop.configure(command=self.geklikt)

    def geklikt(self):
        self.hoeveel += 1
        self.knop.configure(text=f"{self.hoeveel} keer")

Teller().mainloop()