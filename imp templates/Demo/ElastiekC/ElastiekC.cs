using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

Form scherm = new Form();
scherm.Text = "ElastiekC";
scherm.ClientSize = new Size(300, 300);

Point hier = new Point(0, 0);

void beweeg(object sender, MouseEventArgs mea)
{
    hier = mea.Location;
    scherm.Invalidate();
}
void teken(object sender, PaintEventArgs pea)
{
    Graphics gr = pea.Graphics;
    gr.SmoothingMode = SmoothingMode.AntiAlias;
    gr.DrawLine(Pens.Black, hier.X, hier.Y,   0,   0);
    gr.DrawLine(Pens.Black, hier.X, hier.Y, 300,   0);
    gr.DrawLine(Pens.Black, hier.X, hier.Y,   0, 300);
    gr.DrawLine(Pens.Black, hier.X, hier.Y, 300, 300);
    gr.FillEllipse(Brushes.Blue, hier.X-10, hier.Y-10, 20, 20);
}

scherm.MouseMove += beweeg;
scherm.Paint     += teken;
Application.Run(scherm);