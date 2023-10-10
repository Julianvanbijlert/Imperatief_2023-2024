class Processor():

    def __init__(self):
        self.Schoon()

    def Schoon(self):
        self.waarde = 0
        self.vorige = 0
        self.oper = '+'
        self.scherm = "0"

    def Reken(self):
        if (self.oper=='+'): self.vorige += self.waarde
        if (self.oper=='-'): self.vorige -= self.waarde
        if (self.oper=='*'): self.vorige *= self.waarde
        if (self.oper=='/'): self.vorige /= self.waarde
        self.scherm = str(self.vorige)
        self.waarde = 0

    def Cijfer(self, n):
        self.waarde = 10 * self.waarde + n
        self.scherm = str(self.waarde)

    def Operatie(self, c):
        self.Reken()
        self.oper = c
