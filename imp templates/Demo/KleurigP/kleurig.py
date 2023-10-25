maximaal = 255

class kleur:
    def __init__(self, x=None, y=None, z=None):
        if isinstance(x, kleur):
            self.Rood = x.Rood
            self.Groen = x.Groen
            self.Blauw = x.Blauw
        elif isinstance(x, int):
            self.Rood = x
            if y==None:
                self.Groen = x
                self.Blauw = x
            else:
                self.Groen = y
                self.Blauw = z
        elif isinstance(x, str):
            velden = x.split()
            self.Rood  = int(velden[0])
            self.Groen = int(velden[1])
            self.Blauw = int(velden[2])
        elif x!=None:
            raise Exception("kleur argument moet int/str/kleur zijn")
        else:
            self.Rood = maximaal
            self.Groen = maximaal
            self.Blauw = maximaal

    def __str__(self):
        return f"{self.Rood} {self.Groen} {self.Blauw}"

    def grijswaarde(self):
        return int(0.3*self.Rood + 0.6*self.Groen + 0.1*self.Blauw)

    def maakDonkerder(self):
        self.Rood = int(self.Rood*0.9)
        self.Groen = int(self.Groen*0.9)
        self.Blauw = int(self.Blauw*0.9)

    def donkerdereVersie(self):
        res = kleur(self)
        res.maakDonkerder()
        return res

def parse(s):
    return kleur(s)

zwart = kleur(0)
geel = kleur(maximaal,maximaal,0)