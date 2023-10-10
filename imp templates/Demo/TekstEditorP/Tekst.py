from tkinter import Toplevel, Menu, Text, Label
from tkinter.filedialog import asksaveasfilename
from ZoekDialoog import ZoekDialoog

class Tekst(Toplevel):
    def __init__(self,parent):
        super().__init__(parent)
        self.geometry("500x300")

        menubar = Menu(self)
        filemenu = Menu(menubar, tearoff=0)
        filemenu.add_command(label="Opslaan",        command=self.opslaan)
        filemenu.add_command(label="Opslaan als...", command=self.opslaanAls)
        filemenu.add_command(label="Sluiten",        command=self.destroy)
        menubar.add_cascade(label="File", menu=filemenu)
        filemenu = Menu(menubar, tearoff=0)
        filemenu.add_command(label="Zoek",    command=self.zoek)
        filemenu.add_command(label="Vervang", command=self.vervang)
        menubar.add_cascade(label="Zoek", menu=filemenu)
        self.configure(menu=menubar)

        self.invoer = Text(self, width=1, height=1)
        self.invoer.pack(fill="both", expand=True)
        self.invoer.bind("<KeyRelease>", self.verander)

        self.status = Label(self)
        self.status.pack()

    def opslaan(self):
        if self.title():
            self.schrijfNaarFile()
        else:
            self.opslaanAls()
        
    def opslaanAls(self):
        naam = asksaveasfilename()
        if naam:
            self.title(naam)
            self.schrijfNaarFile()

    def schrijfNaarFile(self):
        naam = self.title()
        schrijver = open(naam, "w")
        schrijver.write(self.invoer.get("1.0", "end"))
        schrijver.close()
        pass
    
    def leesVanFile(self, naam):
        lezer = open(naam, "r")
        self.invoer.insert("1.0", lezer.read())
        lezer.close()
        self.title(naam)
        self.verander(None)

    def verander(self, ea):
        self.status.configure(text=str(len(self.invoer.get("1.0", "end")))+" karakters")

    def zoekOfVervang(self, ookVervangen):
        dialoog = ZoekDialoog(self, ookVervangen)
        self.wait_window(dialoog)
        if dialoog.ZoekOK:
            zoek = dialoog.ZoekText
            beginpos = self.invoer.search(zoek, "1.0")
            if beginpos:
                eindpos = f"{beginpos}+{len(zoek)}c"
                if ookVervangen:
                    vervang = dialoog.VervangText
                    self.invoer.delete(beginpos, eindpos)
                    self.invoer.insert(beginpos, vervang)
                    eindpos = f"{beginpos}+{len(vervang)}c"
                    self.verander(None)

                self.invoer.tag_add("sel", beginpos, eindpos)
                self.invoer.mark_set("insert", eindpos)

    def zoek(self):
        self.zoekOfVervang(False)

    def vervang(self):
        self.zoekOfVervang(True)