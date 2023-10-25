using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System;

class VervagendC : Form
{
    const int diameter = 15;
    const int straal = diameter / 2;
    const double rate = 0.99;

    private List<Point> punten = new List<Point>();
    private bool isVast = false;

    public VervagendC()
    {   Text       = "VervagendC";
        ClientSize = new Size(200, 200);
        BackColor  = Color.White;
        DoubleBuffered = true;
        Paint     += teken;
        MouseMove += beweeg;
        MouseDown += vast;
        MouseUp   += los;
    }
    private void beweeg(object sender, MouseEventArgs mea)
    {   if (isVast)
        {   punten.Add(mea.Location);
            Invalidate();
        }
    }
    private void vast(object o, MouseEventArgs ea) { isVast = true; beweeg(o, ea); }
    private void los (object o, MouseEventArgs ea) { isVast = false; }
    private void teken(object o, PaintEventArgs pea)
    {
        Graphics gr = pea.Graphics; gr.SmoothingMode = SmoothingMode.AntiAlias;
        int t = 0;
        int n = punten.Count;
        foreach (Point punt in punten)
        {
            int k = (int)(255 - 255 * Math.Pow(rate, n-t-1));
            Color kleur = Color.FromArgb(k, k, k);
            Brush brush = new SolidBrush(kleur);
            gr.FillEllipse(brush, punt.X-straal, punt.Y-straal, diameter, diameter);
            t += 1;
        }
        if (n > 0)
        {
            IEnumerable<int> xs = from punt in punten select punt.X;
            IEnumerable<int> ys = from punt in punten select punt.Y;
            int minX = xs.Min() - straal;
            int minY = ys.Min() - straal;
            int maxX = xs.Max() + straal;
            int maxY = ys.Max() + straal;
            gr.DrawRectangle(new Pen(Color.Blue, 2), minX, minY, maxX-minX, maxY-minY);
        }
    }
    public static void Main()
    {   Application.Run(new VervagendC());
    }
}