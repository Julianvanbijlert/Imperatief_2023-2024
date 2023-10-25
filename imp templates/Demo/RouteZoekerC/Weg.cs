using System.Drawing;

class Weg
{
    public Stad Doel;
    public int Kosten;

    public Weg(Stad doel, int kosten)
    {   Doel = doel;
        Kosten = kosten;
    }
    public void Teken(Graphics gr, Pen pen, Stad stad)
    {   gr.DrawLine(pen, stad.Plek, Doel.Plek);
    }
}