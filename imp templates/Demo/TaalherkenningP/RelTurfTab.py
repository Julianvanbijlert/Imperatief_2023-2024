from pathlib import Path
import sys

sys.path.insert(0, str(Path(__file__).resolve().parent.parent))

from LetterTellerP.TurfTab import TurfTab
from urllib.request import urlopen

class RelTurfTab(TurfTab):
    def __init__(self):
        super().__init__()
        self.teltmee = True

    def relatief(self, i):
        return self.tellers[i] / self.totaal

    def Verschil(self, andere):
        if self.totaal>0:
            tot = 0
            for t in range(0,26):
                tot += abs(self.relatief(t) - andere.relatief(t))
            return tot/26
        else:
            return 1

    def Lees(self, naam):
        if naam.startswith("http://") or naam.startswith("https://"):
            reader = urlopen(naam)
            for regel in reader:
                self.Turf(regel.decode('utf-8'))
        else:
            reader = open(naam, "r")
            for regel in reader:
                self.Turf(regel)
        reader.close()

    def turf(self, c):
        if c==ord('<'):
            self.teltmee = False
        elif c==ord('>'):
            self.teltmee = True
        elif self.teltmee:
            super().turf(c)
