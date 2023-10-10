using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "ThermoC";
scherm.ClientSize = new Size(200, 390);

TrackBar minimum = new TrackBar(); scherm.Controls.Add(minimum);
TrackBar huidige = new TrackBar(); scherm.Controls.Add(huidige);
TrackBar maximum = new TrackBar(); scherm.Controls.Add(maximum);
Button   reset   = new Button();   scherm.Controls.Add(reset);   reset.Text = "Reset";

minimum.Orientation = Orientation.Vertical; minimum.BackColor = Color.SkyBlue;
huidige.Orientation = Orientation.Vertical; huidige.BackColor = Color.White;
maximum.Orientation = Orientation.Vertical; maximum.BackColor = Color.Tomato;
minimum.Minimum = -50; minimum.Maximum = 50;
huidige.Minimum = -50; huidige.Maximum = 50;
maximum.Minimum = -50; maximum.Maximum = 50;
minimum.Location = new Point( 10,  10); minimum.Size = new Size(40, 328);
huidige.Location = new Point( 60,  10); huidige.Size = new Size(40, 328);
maximum.Location = new Point(110,  10); maximum.Size = new Size(40, 328);
reset  .Location = new Point( 10, 350); reset  .Size = new Size(150, 30);

void veranderd(object o, EventArgs ea)
{
    int x = huidige.Value;
    if (x < minimum.Value)
        minimum.Value = x;
    if (x > maximum.Value)
        maximum.Value = x;
}
void klik(object o, EventArgs ea)
{
    minimum.Value = huidige.Value;
    maximum.Value = huidige.Value;
}

huidige.Scroll += veranderd;
reset  .Click  += klik;
Application.Run(scherm);