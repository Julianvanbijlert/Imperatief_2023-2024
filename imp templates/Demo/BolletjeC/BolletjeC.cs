using System;
using System.Drawing;

Test();

void Test()
{   Bol b = new Bol(3, 5);
    b.Groei(2);
    KleurBol k = new KleurBol(7, Color.Red);
    k.Groei(5); k.Blackout();
    Console.WriteLine($"{k.diam} {k.kleur}");
}
class Bol
{   public int x, y, diam;
    public Bol(int x0, int y0)
    {   x = x0;
        y = y0;
        diam = 10;
    }
    public void Groei(int p)
    {   diam += p;
    }
}
class KleurBol : Bol
{   public Color kleur;
    public KleurBol(int x0, Color k0)
         : base(x0, 20)   
    {   kleur = k0;
    }
    public void Blackout()
    {   kleur = Color.Black;
    }
}