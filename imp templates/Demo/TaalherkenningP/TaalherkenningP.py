from tkinter import Frame, Entry, Label, Text, Button, Grid
from RelTurfTab import RelTurfTab
import sys

startwaarden = [ "Nederlands", "https://nl.wikipedia.org" \
               , "Engels",     "https://en.wikipedia.org" \
               , "Duits",      "https://de.wikipedia.org" \
               , "Frans",      "https://fr.wikipedia.org" \
               , "Spaans",     "https://es.wikipedia.org" \
               , "Italiaans",  "https://it.wikipedia.org" ]

if len(sys.argv)>1:
    startwaarden = sys.argv[1:]

class TaalherkenningP(Frame):
    def __init__(self):
        super().__init__()
        self.master.title("TaalherkenningP")
        self.master.geometry("800x300")
        self.configure(background="lightblue")
        self.pack(fill="both", expand=True)

        Grid.columnconfigure(self, index=0, weight=100)
        Grid.columnconfigure(self, index=1, weight=20)
        Grid.columnconfigure(self, index=2, weight=15)
        Grid.columnconfigure(self, index=3, weight=60)

        self.aantal = 10
        self.url = list()
        self.taal = list()
        self.score = list()

        for t in range(0, self.aantal):
            Grid.rowconfigure(self, index=t, weight=1)
            n = Entry(self, width=1)
            n.grid(row=t, column=1, sticky="nsew")
            s = Label(self, width=1)
            s.grid(row=t, column=2, sticky="nsew")
            u = Entry(self, width=1)
            u.grid(row=t, column=3, sticky="nsew")

            if t < len(startwaarden)/2:
                n.insert(0, startwaarden[2*t])
                u.insert(0, startwaarden[2*t+1])

            self.url.append(u)
            self.taal.append(n)
            self.score.append(s)

        self.invoer = Text(self, width=1, height=1)
        self.invoer.grid(row=0, rowspan=8, column=0, sticky="nsew")
        
        knop = Button(self, text="Herken taal", command=self.klik)
        knop.grid(row=8, column=0, sticky="nsew")

        self.uitvoer = Label(self, width=1)
        self.uitvoer.grid(row=9, column=0, sticky="nsew")

    def klik(self):
        onbekend = RelTurfTab()
        onbekend.Turf(self.invoer.get("1.0", "end"))

        kleinste = 1
        antwoord = "onbekend"

        for t in range(0, self.aantal):
            naam = self.url[t].get()
            if naam!="":
                taalnaam = self.taal[t].get()
                self.uitvoer.configure(text=f"probeer {taalnaam}")
                self.master.update()
                voorbeeld = RelTurfTab()
                try:
                    voorbeeld.Lees(naam)
                    verschil = onbekend.Verschil(voorbeeld)
                    self.score[t].configure(text=str(int(10000*verschil)))

                    if verschil<kleinste:
                        kleinste = verschil
                        antwoord = f"taal is waarschijnlijk {taalnaam}"

                except Exception as exc:
                    self.score[t].configure(text="???")
                    print(str(exc))
        self.uitvoer.configure(text=antwoord)