using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "KleurKubusC";
scherm.ClientSize = new Size(552, 600);

Label    kubus  = new Label();      scherm.Controls.Add(kubus);
TrackBar schuif = new TrackBar();   scherm.Controls.Add(schuif);
kubus .Location = new Point(20, 20);
kubus .Size     = new Size(512,512);
schuif.Location = new Point(20,542);
schuif.Size     = new Size(512, 20);
schuif.Minimum  = 0;
schuif.Maximum  = 255;
schuif.Orientation = Orientation.Horizontal;

void TekenKubus(object o, PaintEventArgs pea)
{
    int blauw = schuif.Value;
    for (int x=0; x<16; x++)
    {
        int rood = 17*x;
        for (int y=0; y<16; y++)
        {
            int groen = 17*y;
            Color kleur = Color.FromArgb(rood, groen, blauw);
            pea.Graphics.FillRectangle(new SolidBrush(kleur), 32*x, 32*y, 32, 32);
        }
    }
}

void VeranderSchuif(object o, EventArgs ea)
{
    kubus.Invalidate();
}

kubus.Paint   += TekenKubus;
schuif.Scroll += VeranderSchuif;
Application.Run(scherm);