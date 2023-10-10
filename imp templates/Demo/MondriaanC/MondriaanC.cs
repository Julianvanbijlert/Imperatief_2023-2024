/* Dit programma tekent een Mondriaan-achtige
   "compositie met rood en blauw"
*/
using System.Windows.Forms;
using System.Drawing;

// eerst de gebruikelijke opdrachten om een plaatje te kunnen tonen
Form scherm = new Form();
scherm.Text = "MondriaanC";
scherm.ClientSize = new Size(200, 100);
Bitmap plaatje = new Bitmap(200, 100);
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(200, 100);
afbeelding.BackColor = Color.White;
afbeelding.Image = plaatje;
Graphics gr = Graphics.FromImage(plaatje);

// nu gaan we het eigenlijke plaatje tekenen
int breedte = plaatje.Width;
int hoogte = plaatje.Height;
int x1 = 10, x2 = 50, x3 = 90, y1 = 40, y2 = 70, balk = 10;

// zwarte balken
gr.FillRectangle(Brushes.Black, x1, 0, balk, hoogte);
gr.FillRectangle(Brushes.Black, x2, 0, balk, hoogte);
gr.FillRectangle(Brushes.Black, x3, 0, balk, hoogte);
gr.FillRectangle(Brushes.Black, 0, y1, breedte, balk);
gr.FillRectangle(Brushes.Black, 0, y2, breedte, balk);

// gekleurde vlakken
gr.FillRectangle(Brushes.Blue, 0, y1 + balk, x1, y2 - (y1 + balk));
gr.FillRectangle(Brushes.Red, x3 + balk, 0, breedte - (x3 + balk), y1);

Application.Run(scherm);