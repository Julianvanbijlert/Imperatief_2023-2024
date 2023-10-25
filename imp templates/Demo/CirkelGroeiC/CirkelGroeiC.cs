using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "CirkelGroeiC";
scherm.ClientSize = new Size(300, 300);

int straal = 100;  // globale toestands-variabele

Button kleiner = new Button();         scherm.Controls.Add(kleiner);
Button groter  = new Button();         scherm.Controls.Add(groter);
kleiner.Location = new Point(30, 20);  kleiner.Text = "Kleiner";
groter .Location = new Point(200, 20); groter .Text = "Groter";

void teken(object sender, PaintEventArgs pea)
{
    pea.Graphics.FillEllipse( Brushes.Green, 150-straal, 150-straal, 2*straal, 2*straal);
}

void klik(object sender, EventArgs e)
{
    if (sender == kleiner && straal > 10)
        straal -= 10;
    if (sender == groter && straal < 150)
        straal += 10;
    scherm.Invalidate();
}

kleiner.Click += klik;
groter .Click += klik;
scherm .Paint += teken;
Application.Run(scherm);