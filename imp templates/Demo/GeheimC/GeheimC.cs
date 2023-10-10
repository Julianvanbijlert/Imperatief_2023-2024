using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "GeheimC";

bool geraden = false;   // globale toestand-variabele
const string sleutel = "geheim";

TextBox wachtwoord = new TextBox(); scherm.Controls.Add(wachtwoord);
wachtwoord.Location = new Point(65, 15); wachtwoord.Size = new Size(136, 20);
wachtwoord.PasswordChar = '*';

void teken(object o, PaintEventArgs pea)
{
    Graphics gr = pea.Graphics;
    gr.SmoothingMode = SmoothingMode.AntiAlias;
    if (geraden)
    {
        gr.FillEllipse(Brushes.Yellow, 100, 100, 100, 100);
        gr.FillEllipse(Brushes.Blue, 131, 135, 8, 8);
        gr.FillEllipse(Brushes.Blue, 161, 135, 8, 8);
        gr.DrawArc(new Pen(Color.Blue, 3), 125, 125, 50, 50, 45, 90);
    }
    else gr.DrawString("please enter password", new Font("Arial", 14), Brushes.Black, 50, 50);
}

void veranderd(object o, EventArgs e)
{
    if (wachtwoord.Text == sleutel)
    {
        geraden = true;
        wachtwoord.Visible = false;   // maak de TextBox onzichtbaar
        scherm.Invalidate();
    }
}

wachtwoord.TextChanged += veranderd;
scherm.Paint += teken;
Application.Run(scherm);