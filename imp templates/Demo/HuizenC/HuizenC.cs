// Dit programma tekent drie huizen van divers formaat
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

// eerst de gebruikelijke opdrachten om een plaatje te kunnen tonen
Form scherm = new Form();
scherm.Text = "HuizenC";
scherm.ClientSize = new Size(220, 120);
Bitmap plaatje = new Bitmap(220, 120);
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(220, 120);
afbeelding.BackColor = Color.White;
afbeelding.Image = plaatje;
Graphics gr = Graphics.FromImage(plaatje);

// een hulpfunctie om een enkel huis te tekenen
void TekenHuis(int x, int y, int breedte)
{
    int topx = x + breedte/2;
    int topy = y - 3*breedte/2;
    int afdak = breedte/6;
    int randy = y - breedte + afdak;

    // de muur
    Brush br = new HatchBrush(HatchStyle.HorizontalBrick, Color.Silver, Color.Red);
    gr.FillRectangle(br, x, y-breedte, breedte, breedte);
    // het dak
    Pen pen = new Pen(Color.DarkRed, 3);
    gr.DrawLine(pen, x-afdak, randy, topx, topy);
    gr.DrawLine(pen, topx, topy, x+breedte+afdak, randy);
}

// nu gaan we het eigenlijke plaatje tekenen, door de hulpfunctie driemaal aan te roepen
TekenHuis( 20, 100, 40);
TekenHuis( 80, 100, 40);
TekenHuis(140, 100, 60);

Application.Run(scherm);