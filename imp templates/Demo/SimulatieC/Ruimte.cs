using System.Drawing;
using System.Windows.Forms;

class Ruimte : Label
{
    Deeltje d1, d2, d3;

    public Ruimte(Size size)
    {
        this.Size = size;
        this.BackColor = Color.LightYellow;
        d1 = new Deeltje(Brushes.Red,    30, 40, 10,  10);
        d2 = new Deeltje(Brushes.Green, 100, 80,  5, -10);
        d3 = new Deeltje(Brushes.Blue,  200, 60,  8,   2);
        this.Paint += this.tekenRuimte;
    }

    public void DoeStap()
    {
        d1.DoeStap(Size);
        d2.DoeStap(Size);
        d3.DoeStap(Size);
        Invalidate();
    }

    private void tekenRuimte(object o, PaintEventArgs pea)
    {
        Graphics gr = pea.Graphics;
        d1.TekenDeeltje(gr);
        d2.TekenDeeltje(gr);
        d3.TekenDeeltje(gr);
    }
}