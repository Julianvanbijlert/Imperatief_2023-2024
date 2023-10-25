from tkinter import Frame, Menu
from tkinter.filedialog import askopenfilename
from Tekst import Tekst

class TekstEditorP(Frame):
    def __init__(self):
        super().__init__()
        self.master.title("TekstEditorP")
        self.configure(background="lightblue")
        self.configure(width=200, height=100)
        self.pack()

        menubar = Menu(self)
        filemenu = Menu(menubar, tearoff=0)
        filemenu.add_command(label="Nieuw...", command=self.nieuw)
        filemenu.add_command(label="Open...",  command=self.open)
        filemenu.add_command(label="Exit",     command=self.master.quit)
        menubar.add_cascade(label="File", menu=filemenu)
        self.master.configure(menu=menubar)

    def nieuw(self):
        tekst = Tekst(self)

    def open(self):
        naam = askopenfilename()
        if (naam):
            tekst = Tekst(self)
            tekst.leesVanFile(naam)