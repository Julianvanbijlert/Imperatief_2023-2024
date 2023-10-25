using System.Drawing;
using System.Windows.Forms;



Form scherm = new Form();
scherm.Text = "SchilderenC";
scherm.ClientSize = new Size(200, 200);

Bitmap plaatje = new Bitmap(200, 200);

Graphics gr = Graphics.FromImage(plaatje);
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(200, 200);
afbeelding.Image = plaatje;

void muisKlik(object o, MouseEventArgs ea)
{   gr.FillEllipse( Brushes.Blue
                  , ea.X-5, ea.Y-5, 10, 10);


    afbeelding.Invalidate();
}

afbeelding.MouseClick += muisKlik;
Application.Run(scherm);