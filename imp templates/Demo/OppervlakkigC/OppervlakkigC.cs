using System;

double vraagGetal(string vraag)
{
    Console.Write(vraag + ": ");
    string regel = Console.ReadLine();
    return double.Parse(regel);
}

double kwadraat(double x)
{
    return x * x;
}

double cirkelOppervlakte(double straal)
{
    return Math.PI * kwadraat(straal);
}

void oppervlakteInterview()
{
    double r = vraagGetal("Geef de straal van een cirkel");
    Console.WriteLine($"De oppervlakte is: {cirkelOppervlakte(r)}");
}

oppervlakteInterview();
oppervlakteInterview();