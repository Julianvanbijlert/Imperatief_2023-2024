from tkinter import Toplevel, Entry, Button, Label

class ZoekDialoog(Toplevel):

    def __init__(self, parent, ookVervangen=False):
        super().__init__(parent)
        self.geometry("220x120")

        zoekLabel      = Label(self, text="Zoek:")
        zoekLabel     .place(x=10,y=10)
        self.zoekText  = Entry(self, width=20)
        self.zoekText .place(x=70,y=10)
        vervangLabel = Label(self, text="Vervang:")
        self.vervangText = Entry(self, width=20)
        if ookVervangen:
            vervangLabel.place(x=10, y=40)
            self.vervangText.place(x=70,y=40)
        ok             = Button(self, text="OK", command=self.pressOK)
        ok            .place(x=50,y=80)
        cancel         = Button(self, text="Cancel", command=self.pressCancel)
        cancel        .place(x=140,y=80)

        for w in [parent, self.zoekText, self.vervangText, ok, cancel]:
            w.bind("<Return>", self.pressOK)
            w.bind("<Escape>", self.pressCancel)

        # Modal dialog magic
        self.wait_visibility()
        self.grab_set()
        self.transient(parent)

    def pressOK(self, ea=None):
        self.ZoekText = self.zoekText.get()
        self.VervangText = self.vervangText.get()
        self.ZoekOK = True
        self.destroy()

    def pressCancel(self, ea=None):
        self.ZoekText = None
        self.VervangText = None
        self.ZoekOK = False
        self.destroy()