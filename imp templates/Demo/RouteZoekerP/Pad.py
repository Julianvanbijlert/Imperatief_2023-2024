class Pad:
    def __init__(self, hier, rest, kosten):
        self.Hier = hier
        self.Rest = rest
        self.Kosten = kosten
        if rest:
            self.Kosten += rest.Kosten

    def Bevat(self, stad):
        if self.Hier==stad:
            return True
        if self.Rest==None:
            return False
        return self.Rest.Bevat(stad)

    def Teken(self, draw, kleur):
        self.Hier.Teken(draw, kleur)
        if self.Rest:
            draw.line((self.Hier.Plek, self.Rest.Hier.Plek), kleur)
            self.Rest.Teken(draw, kleur)
