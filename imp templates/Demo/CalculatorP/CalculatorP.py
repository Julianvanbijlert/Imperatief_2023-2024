from tkinter import Frame, Button, Label, Grid
from Processor import Processor

class CalculatorP(Frame):
    def __init__(self):
        super().__init__()
        self.master.title("CalculatorP")
        self.master.geometry("200x300")
        self.configure(background="lightblue")
        self.pack(fill="both", expand=True)

        for t in range(0,4):
            Grid.columnconfigure(self, index=t, weight=1)
        for t in range(0,5):
            Grid.rowconfigure(self, index=t, weight=1)

        self.resultaat = Label(self, text="0", anchor="e")
        self.resultaat.grid(row=0, column=0, columnspan=4, sticky="nsew")
        self.resultaat.bind("<Configure>", self.veranderFont)

        for n in range(0,16):
            knop = Button(self, text="789/456*123+0C=-"[n])
            knop.grid(row=1+n//4, column=n%4, sticky="nsew")
            knop.bind("<Button-1>", self.klik)
            knop.bind("<Configure>", self.veranderFont)

        self.master.bind("<Key>", self.toets)
        self.proc = Processor()

    def verwerk(self, c):
        if c=='c' or c=='C': self.proc.Schoon()
        elif c=='=': self.proc.Reken()
        elif c in "+-*/": self.proc.Operatie(c)
        elif c in "0123456789": self.proc.Cijfer(int(c))
        self.resultaat.configure(text=self.proc.scherm)

    def klik(self, ea):
        self.verwerk(ea.widget.cget("text"))

    def toets(self, ea):
        self.verwerk(ea.char)

    def veranderFont(self, ea):
        ea.widget.update()
        h = ea.widget.winfo_height() // 4
        if ea.widget==self.resultaat: h = h*3//2
        ea.widget.configure(font=("Tahoma", h))
