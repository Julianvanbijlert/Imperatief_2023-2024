from PIL.ImageDraw import Draw
from PIL.ImageTk   import PhotoImage
from PIL           import Image
from Stad import Stad
from Pad import Pad

class Netwerk:
    def __init__(self):
        self.Steden = list()

    def Teken(self, draw):
        for stad in self.Steden:
            stad.Teken(draw, "black")
            for weg in stad.Wegen:
                weg.Teken(draw, "black", stad)

    def bouwStad(self, naam, plek):
        self.Steden.append(Stad(naam,plek))

    def bouwWeg(self, naam1, naam2, kosten):
        stad1 = self.vindStad(naam1)
        stad2 = self.vindStad(naam2)
        stad1.BouwWeg(stad2, kosten)
        stad2.BouwWeg(stad1, kosten)

    def vindStad(self, naam):
        for stad in self.Steden:
            if stad.Naam==naam:
                return stad
        return None

    def VindStadPoint(self, p):
        (x1, y1) = p
        for stad in self.Steden:
            (x2, y2) = stad.Plek
            if abs(x1-x2)<5 and abs(y1-y2)<5:
                return stad
        return None

    def Lees(self, filenaam):
        lezer = open(filenaam, "r")
        for regel in lezer:
            woorden = regel.split()
            if len(woorden)==4:
                if woorden[0]=="stad":
                    self.bouwStad(woorden[1], (int(woorden[2]), int(woorden[3])))
                elif woorden[0]=="weg":
                    self.bouwWeg(woorden[1], woorden[2], int(woorden[3]))
        lezer.close()

    def ZoekPad(self, van, naar, slim=True):
        paden = None  # lege stack
        beste = None
        paden = ( Pad(van,None,0), paden )  # Push een startpad op de stack
        
        while paden:
            (pad, paden) = paden  # Pop een pad van de stack
            if pad.Hier==naar:
                if beste==None or pad.Kosten < beste.Kosten:
                    beste = pad

            if slim:
                wegen = pad.Hier.Wegen.copy()
                wegen.sort(key=naar.AfstandWegdoelTotStad, reverse=True)
            else:
                wegen = pad.Hier.Wegen

            for weg in wegen:
                if not pad.Bevat(weg.Doel) and (beste==None or pad.Kosten+weg.Kosten<=beste.Kosten):
                    paden = ( Pad(weg.Doel, pad, weg.Kosten), paden )  # Push een uitgebried pad op de stack

        return beste
