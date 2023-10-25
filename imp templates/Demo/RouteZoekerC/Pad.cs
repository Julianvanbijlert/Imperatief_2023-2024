using System.Drawing;

class Pad
{
    public Stad Hier;
    public Pad Rest;
    public int Kosten;

    public Pad(Stad hier, Pad rest, int k)
    {   Hier = hier;
        Rest = rest;
        Kosten = k;
        if (rest != null) 
            Kosten += rest.Kosten;
    }
    public bool Bevat(Stad s)
    {   if (Hier == s) return true;
        if (Rest == null) return false;
        return Rest.Bevat(s);
    }
    public void Teken(Graphics gr, Brush brush, Pen pen)
    {   Hier.Teken(gr,brush);
        if (Rest != null)
        {   gr.DrawLine(pen, Hier.Plek, Rest.Hier.Plek);
            Rest.Teken(gr, brush, pen);
        }
    }
}