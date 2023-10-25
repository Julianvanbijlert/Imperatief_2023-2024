using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "ParaboolC";
scherm.ClientSize = new Size(470, 320);

Font font = new Font("Arial", 16);
Label   labA  = new Label();   scherm.Controls.Add(labA); labA.Font = font;
Label   labB  = new Label();   scherm.Controls.Add(labB); labB.Font = font;
Label   labC  = new Label();   scherm.Controls.Add(labC); labC.Font = font;
TextBox boxA  = new TextBox(); scherm.Controls.Add(boxA); boxA.Font = font;
TextBox boxB  = new TextBox(); scherm.Controls.Add(boxB); boxB.Font = font;
TextBox boxC  = new TextBox(); scherm.Controls.Add(boxC); boxC.Font = font;
Label grafiek = new Label();   scherm.Controls.Add(grafiek);
Label nulpunt = new Label();   scherm.Controls.Add(nulpunt);
labA.Location = new Point(10, 24); labA.Size = new Size(30, 30); labA.Text = "a:";
labB.Location = new Point(10, 64); labB.Size = new Size(30, 30); labB.Text = "b:";
labC.Location = new Point(10,104); labC.Size = new Size(30, 30); labC.Text = "c:";
boxA.Location = new Point(40, 20); boxA.Size = new Size(80, 30); boxA.Text = 0.5 .ToString();
boxB.Location = new Point(40, 60); boxB.Size = new Size(80, 30); boxB.Text = 1   .ToString();
boxC.Location = new Point(40,100); boxC.Size = new Size(80, 30); boxC.Text = (-3).ToString();
grafiek.Location = new Point(160, 10); grafiek.Size = new Size(300, 300);
nulpunt.Location = new Point(10, 150); nulpunt.Size = new Size(140, 80);
grafiek.BackColor = Color.Khaki;

double a=0, b=0, c=0;  // globale toestand-variabelen

double functie(double x)
{
    return a * x * x + b * x + c;
}

string oplossingen()
{
    double discr  = b*b - 4*a*c;
    double noemer = 2*a;
    if (noemer == 0) return "rechte lijn!";
    if (discr  < 0 ) return "geen nulpunten";
    if (discr == 0)  return $"een nulpunt:\n{-b/noemer}";
    double wortel = Math.Sqrt(discr);
    return $"twee nulpunten:\n{(-b-wortel)/noemer}\nen\n{(-b+wortel)/noemer}";
}

void tekenGrafiek(object o, PaintEventArgs pea)
{
    int xMid = grafiek.Width / 2;
    int yMid = grafiek.Height / 2;
    double schaal = 0.04;
    Graphics gr = pea.Graphics;
    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

    // assen
    gr.DrawLine(Pens.Red, 0, yMid, grafiek.Width, yMid);
    gr.DrawLine(Pens.Red, xMid, 0, xMid, grafiek.Height);

    // grafiek van de parabool
    Pen pen = new Pen(Color.Blue, 3);
    int yVorigePixel = 0;
    for (int xPixel = -1; xPixel < grafiek.Width; xPixel++)
    {
        double xWaarde = (xPixel - xMid) * schaal;
        double yWaarde = functie(xWaarde);
        int yPixel = (int)(yMid - (yWaarde / schaal));
        if (xPixel > 0)
            gr.DrawLine(pen, xPixel - 1, yVorigePixel, xPixel, yPixel);
        yVorigePixel = yPixel;
    }
}

void boxVeranderd(object sender, EventArgs ea)
{
    try
    {
        a = double.Parse(boxA.Text); boxA.BackColor = Color.White;
        b = double.Parse(boxB.Text); boxB.BackColor = Color.White;
        c = double.Parse(boxC.Text); boxC.BackColor = Color.White;
        grafiek.Invalidate();
        nulpunt.Text = oplossingen();
    }
    catch (Exception exc)
    {
        ((TextBox)sender).BackColor = Color.Tomato;
        nulpunt.Text = exc.Message;
    }
}

grafiek.Paint += tekenGrafiek;
boxA.TextChanged += boxVeranderd;
boxB.TextChanged += boxVeranderd;
boxC.TextChanged += boxVeranderd;
boxVeranderd(null, null);
Application.Run(scherm);