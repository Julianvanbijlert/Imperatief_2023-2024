using System.Drawing;

abstract class Voertuig
{
    public abstract void Teken(Graphics gr, int x, int y);
}
class PersonenAuto : Voertuig
{
    public override void Teken(Graphics gr, int x, int y)
    {
        gr.FillRectangle(Brushes.Blue, x, y-20, 40, 15);
        gr.FillRectangle(Brushes.Blue, x+10, y-30, 20, 10);
        gr.FillEllipse(Brushes.Red, x+5, y-10, 10, 10);
        gr.FillEllipse(Brushes.Red, x+25, y-10, 10, 10);
    }
}
class Vrachtwagen : Voertuig
{
    public override void Teken(Graphics gr, int x, int y)
    {
        gr.FillRectangle(Brushes.Green, x, y-45, 50, 40);
        gr.FillRectangle(Brushes.DarkGreen, x+50, y-35, 20, 30);
        gr.FillEllipse(Brushes.Red, x+5, y-10, 10, 10);
        gr.FillEllipse(Brushes.Red, x+20, y-10, 10, 10);
        gr.FillEllipse(Brushes.Red, x+55, y-10, 10, 10);
    }
}
class Combinatie : Vrachtwagen
{
    public override void Teken(Graphics gr, int x, int y)
    {   // de vrachtwagen
        base.Teken(gr, x, y);
        // de aanhanger
        gr.DrawLine(Pens.Black, x-5, y-10, x, y-10);
        gr.FillRectangle(Brushes.Green, x-45, y-45, 40, 40);
        gr.FillEllipse(Brushes.Red, x-40, y-10, 10, 10);
        gr.FillEllipse(Brushes.Red, x-20, y-10, 10, 10);
    }
}