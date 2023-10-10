using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "CopyDemoC";
scherm.ClientSize = new Size(680, 320);

// met een Bitmap kun je een plaatje opslaan in het geheugen
Bitmap plaatje = new Bitmap(680, 320);

// maar om complexere figuren te tekenen heb je een Graphics nodig
Graphics gr = Graphics.FromImage(plaatje);


Rectangle r1, r2, r3;
Bitmap bm1, bm2, bm3;

// Maak en teken een rechthoek en een bitmap
r1 = new Rectangle(50, 40, 60, 20);
bm1 = new Bitmap("../../../Duif.jpg");

gr.FillRectangle(Brushes.Blue, r1);
gr.DrawImage(bm1, 20, 100);

// Maak twee kopieen van de rechthoek, verander ze, en teken ze
r2 = r1;
r3 = r1;
r2.Offset(220, 0); r2.Inflate(20, 10);
r3.Offset(440, 0); r3.Inflate(0, 30);
gr.FillRectangle(Brushes.Red, r2);
gr.FillRectangle(Brushes.Green, r3);

// Maak twee kopieen(?) van de bitmap, verander ze, en teken ze
bm2 = bm1;
bm3 = bm1;
bm2.RotateFlip(RotateFlipType.Rotate90FlipNone); // draai bm2 rechtsom
bm3.RotateFlip(RotateFlipType.RotateNoneFlipX);  // spiegel bm3
gr.DrawImage(bm2, 240, 100);
gr.DrawImage(bm3, 460, 100);

// een Label kan ook gebruikt worden om een Bitmap te laten zien
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(680, 320);
afbeelding.Image = plaatje;
Application.Run(scherm);