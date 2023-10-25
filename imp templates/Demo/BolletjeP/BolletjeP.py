




def Test():
    b = Bol(3, 5)
    b.Groei(2)
    k = KleurBol(7, "red")
    k.Groei(5); k.Blackout()
    print(f"{k.diam} {k.kleur}")

class Bol:

    def __init__(self, x0, y0):
        self.x = x0
        self.y = y0
        self.diam = 10

    def Groei(self, p):
        self.diam += p


class KleurBol(Bol):

    def __init__(self, x0, k0):
        super().__init__(x0, 20)
        self.kleur = k0

    def Blackout(self):
        self.kleur = "black"

Test()