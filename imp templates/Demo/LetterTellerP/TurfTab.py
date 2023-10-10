class TurfTab:
    def __init__(self):
        self.tellers = [0] * 26
        self.totaal = 0

    def turf(self, ch):
        if ord('A') <= ch <= ord('Z'):
            self.tellers[ch - ord('A')]+=1
            self.totaal+=1
        if ord('a') <= ch <= ord('z'):
            self.tellers[ch - ord('a')]+=1
            self.totaal+=1

    def Turf(self, s):
        for c in s:
            self.turf(ord(c))

    def __str__(self):
        res = ""
        for t in range(0,26):
            res += chr(t+ord('A')) + ": " + str(self.tellers[t]) + " keer\n"
        res += "totaal: " + str(self.totaal) + "\n"
        res += "gemiddeld: " + str(self.Gemiddelde)
        return res

    def berekenGemiddelde(self):
        return self.totaal / len(self.tellers)

    Gemiddelde = property(fget=berekenGemiddelde)

    def getWaardes(self):
        return self.tellers.copy()

    Waardes = property(fget=getWaardes)