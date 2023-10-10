class Bitmap():
    def __init__(self, br, h):
        self.Breedte = br
        self.Hoogte = h
        self.vakjes = [ [0 for y in range(0,h) ] for x in range(0,br) ]                 

    def veranderKleur(self, x, y, b):
        self.vakjes[x][y] = b
    
    def vraagKleur(self, x, y):
        return self.vakjes[x][y]

    def combineer(self, ander, comb):
        for x in range(0,self.Breedte):
            for y in range(0,self.Hoogte):
                self.veranderKleur(x, y, comb(self.vraagKleur(x,y), ander.vraagKleur(x,y)))

    def Kopieer(self, ander):
        self.combineer(ander, lambda a,b: b )

    def Left(self):
        for y in range(0, self.Hoogte):
            for x in range(1,self.Breedte):
                self.veranderKleur(x-1, y, self.vraagKleur(x,y))
            self.veranderKleur(self.Breedte-1, y, False)

    def Right(self):
        for y in range(0, self.Hoogte):
            for x in range(self.Breedte-1, 0, -1):
                self.veranderKleur(x, y, self.vraagKleur(x-1,y))
            self.veranderKleur(0, y, False)

    def Up(self):
        for x in range(0, self.Breedte):
            for y in range(1,self.Hoogte):
                self.veranderKleur(x, y-1, self.vraagKleur(x,y))
            self.veranderKleur(x, self.Hoogte-1, False)

    def Down(self):
        for x in range(0, self.Breedte):
            for y in range(self.Hoogte-1, 0, -1):
                self.veranderKleur(x, y, self.vraagKleur(x,y-1))
            self.veranderKleur(x, 0, False)

    def Clear(self):
        self.combineer(self, lambda a,b: False )

    def Invert(self):
        self.combineer(self, lambda a,b: not a )

    def Bold(self):
        ander = Bitmap(self.Breedte, self.Hoogte)
        ander.Kopieer(self)
        ander.Left()
        self.combineer(ander, lambda a, b: a or b)
        ander.Kopieer(self)
        ander.Down()
        self.combineer(ander, lambda a, b: a or b)

    def Outline(self):
        ander = Bitmap(self.Breedte, self.Hoogte)
        ander.Kopieer(self)
        ander.Left()
        ander.Down()
        self.combineer(ander, lambda a, b: a != b)

    def Life(self):
        old = Bitmap(self.Breedte, self.Hoogte)
        old.Kopieer(self)
        for y in range(0,self.Hoogte):
            for x in range(0,self.Breedte):
                n = old.Buren(x,y)
                self.veranderKleur(x, y, n==3 or (old.vraagKleur(x,y) and n==2))

    def Buren(self, x, y):
        x0 = x-1
        if x0<0: x0 += self.Breedte
        y0 = y-1
        if y0<0: y0 += self.Hoogte
        x1 = x+1
        if x1>=self.Breedte: x1 -= self.Breedte
        y1 = y+1
        if y1>=self.Hoogte: y1 -= self.Hoogte
        n = 0
        if self.vraagKleur(x0,y0): n+=1
        if self.vraagKleur(x ,y0): n+=1
        if self.vraagKleur(x1,y0): n+=1
        if self.vraagKleur(x0,y): n+=1
        if self.vraagKleur(x1,y): n+=1
        if self.vraagKleur(x0,y1): n+=1
        if self.vraagKleur(x ,y1): n+=1
        if self.vraagKleur(x1,y1): n+=1
        return n