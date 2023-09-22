using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

int grootte = 100;
int breedte = 400;
int hoogte = 400;
Form scherm = new Form();
scherm.Text = "mandelbrot windows";
scherm.BackColor = Color.LightPink;
scherm.ClientSize = new Size(breedte + 50, hoogte + 350);

Bitmap plaatje = new Bitmap(breedte, hoogte);
Graphics gr = Graphics.FromImage(plaatje);
Label afbeelding = new Label();

afbeelding.Location = new Point(25, 175);
afbeelding.Size = new Size(breedte, hoogte);
afbeelding.BackColor = Color.Transparent;
afbeelding.Image = plaatje;

Bitmap vbLinksBoven = new Bitmap(grootte, grootte);
Graphics grVbLinksBoven = Graphics.FromImage(vbLinksBoven);
Label abVbLinksBoven = new Label();
abVbLinksBoven.Location = new Point(235, 10);
abVbLinksBoven.Size = new Size(grootte, grootte);
abVbLinksBoven.BackColor = Color.Transparent;
abVbLinksBoven.Image = vbLinksBoven;


Bitmap vbRechtsBoven = new Bitmap(grootte, grootte);
Graphics grVbRechtsBoven = Graphics.FromImage(vbRechtsBoven);
Label abVbRechtsBoven = new Label();
abVbRechtsBoven.Location = new Point(315, 10);
abVbRechtsBoven.Size = new Size(grootte, grootte);
abVbRechtsBoven.BackColor = Color.Transparent;
abVbRechtsBoven.Image = vbRechtsBoven;


Bitmap vbLinksOnder = new Bitmap(grootte, grootte);
Graphics grVbLinksOnder = Graphics.FromImage(vbLinksOnder);
Label afbVbLinksOnder = new Label();
afbVbLinksOnder.Location = new Point(235, 90);
afbVbLinksOnder.Size = new Size(grootte, grootte);
afbVbLinksOnder.BackColor = Color.Transparent;
afbVbLinksOnder.Image = vbLinksOnder;


Bitmap vbRechtsOnder = new Bitmap(grootte, grootte);
Graphics grVbRechtsOnder = Graphics.FromImage(vbRechtsOnder);
Label afbVbRechtsOnder = new Label();
afbVbRechtsOnder.Location = new Point(315, 90);
afbVbRechtsOnder.Size = new Size(grootte, grootte);
afbVbRechtsOnder.BackColor = Color.Transparent;
afbVbRechtsOnder.Image = vbRechtsOnder;


TrackBar tbarRood = new TrackBar();
tbarRood.Location = new Point(25, 600);
tbarRood.Size = new Size(400, 30);
tbarRood.Maximum = 256;
tbarRood.Minimum = 1;
tbarRood.TickFrequency = 1;

TrackBar tbarGroen = new TrackBar();
tbarGroen.Location = new Point(25, 640);
tbarGroen.Size = new Size(400, 30);
tbarGroen.Maximum = 256;
tbarGroen.Minimum = 1;
tbarGroen.TickFrequency = 1;

TrackBar tbarBlauw = new TrackBar();
tbarBlauw.Location = new Point(25, 680);
tbarBlauw.Size = new Size(400, 30);
tbarBlauw.Maximum = 256;
tbarBlauw.Minimum = 1;
tbarBlauw.TickFrequency = 1;

Label lblMiddenX = new Label();
Label lblMiddenY = new Label();
Label lblSchaal = new Label();
Label lblAantal = new Label();

TextBox tbMiddenX = new TextBox();
TextBox tbMiddenY = new TextBox();
TextBox tbSchaal = new TextBox();
TextBox tbAantal = new TextBox();

TextBox error = new TextBox();
error.BackColor = Color.DarkRed;
error.Size = new Size(200, 100);
error.Location = new Point(0, 0);
error.Text = "";

Button btnStart = new Button();
Button btnRandom = new Button();

tbMiddenX.Text = "0";
tbMiddenY.Text = "0";
tbSchaal.Text = "0.1";
tbAantal.Text = "100";

// Labels en Textboksen toevoegen

scherm.Controls.Add(afbeelding);
scherm.Controls.Add(abVbLinksBoven);
scherm.Controls.Add(abVbRechtsBoven);
scherm.Controls.Add(afbVbLinksOnder);
scherm.Controls.Add(afbVbRechtsOnder);

scherm.Controls.Add(lblMiddenX);
scherm.Controls.Add(lblMiddenY);
scherm.Controls.Add(lblSchaal);
scherm.Controls.Add(lblAantal);

scherm.Controls.Add(tbMiddenX);
scherm.Controls.Add(tbMiddenY);
scherm.Controls.Add(tbSchaal);
scherm.Controls.Add(tbAantal);
scherm.Controls.Add(tbarRood);
scherm.Controls.Add(tbarGroen);
scherm.Controls.Add(tbarBlauw);

scherm.Controls.Add(btnStart);
scherm.Controls.Add(btnRandom);


lblMiddenX.Location = new Point(60, 10);
lblMiddenY.Location = new Point(60, 30);
lblSchaal.Location = new Point(60, 50);
lblAantal.Location = new Point(60, 70);

lblMiddenX.BackColor = Color.HotPink;
lblMiddenY.BackColor = Color.HotPink;
lblSchaal.BackColor = Color.HotPink;
lblAantal.BackColor = Color.HotPink;
btnStart.BackColor = Color.DeepPink;
btnRandom.BackColor = Color.White;


tbMiddenX.Location = new Point(145, 10);
tbMiddenY.Location = new Point(145, 30);
tbSchaal.Location = new Point(145, 50);
tbAantal.Location = new Point(145, 70);

btnStart.Location = new Point(60, 95);
btnRandom.Location = new Point(145, 95);

lblMiddenX.Size = new Size(80, 20);
lblMiddenY.Size = new Size(80, 20);
lblSchaal.Size = new Size(80, 20);
lblAantal.Size = new Size(80, 20);

tbMiddenX.Size = new Size(80, 20);
tbMiddenY.Size = new Size(80, 20);
tbSchaal.Size = new Size(80, 20);
tbAantal.Size = new Size(80, 20);

btnStart.Size = new Size(80, 20);
btnRandom.Size = new Size(80, 20);



lblMiddenX.Text = "Midden tbMiddenX:";
lblMiddenY.Text = "Midden tbMiddenY:";
lblSchaal.Text = "Schaal:";
lblAantal.Text = "Aantal:";
btnStart.Text = "GO!!!!";
btnRandom.Text = "Random";





int aantal;
double middenX;
double middenY;
double schaal;
int r = 20, g = 250, b = 60;
UpdateTrackbars();


void UpdateVariabelen(int invoerAantal, double invoerMiddenX, double invoerMiddenY, double invoerSchaal)
{
  
        aantal = invoerAantal;
        middenX = invoerMiddenX;
        middenY = invoerMiddenY;
        schaal = invoerSchaal;
    try 
    {
        aantal = Convert.ToInt32(aantal);
        middenX = Convert.ToInt64(middenX);
        middenY = Convert.ToInt64(middenY);
        schaal = Convert.ToInt64(invoerSchaal);
    }
     
     catch (Exception e)
     {
        error.Text = "Foutmelding: Probeer bitches te krijgen.";
     }

    tbAantal.Text = invoerAantal.ToString();
    tbMiddenX.Text = invoerMiddenX.ToString();
    tbMiddenY.Text = invoerMiddenY.ToString();
    tbSchaal.Text = invoerSchaal.ToString();

}

void UpdateKleuren()
{
    r = tbarRood.Value;
    g = tbarGroen.Value;
    b = tbarBlauw.Value;
}

void UpdateTrackbars()
{
    tbarRood.Value = r;
    tbarGroen.Value = g;
    tbarBlauw.Value = b;
}


UpdateVariabelen(100, -0.027812499999999997, -0.6943750000000001, 1.953125E-05);


void BtnStartKlik(object o, EventArgs ea)
{
    UpdateVariabelen(int.Parse(tbAantal.Text), double.Parse(tbMiddenX.Text), double.Parse(tbMiddenY.Text), double.Parse(tbSchaal.Text));
    afbeelding.Invalidate();
}

void VbLinksBovenKlik(object o, EventArgs ea)
{
    UpdateVariabelen(100, -0.027812499999999997, -0.6943750000000001, 1.953125E-05);
    (r, g, b) = (20, 250, 60);
    UpdateTrackbars();

    afbeelding.Invalidate();
}
void VbRechtsBovenKlik(object o, EventArgs ea)
{
    UpdateVariabelen(1000, -1.171058017854132, 0.1928888704065407, 1.5994037748903664E-08);
    (r, g, b) = (200, 30, 5);
    UpdateTrackbars();
    afbeelding.Invalidate();
}
void VbLinksOnderKlik(object o, EventArgs ea)
{
    UpdateVariabelen(1000, -1.4024798924987962, 0.12644983863520337, 3.998509437225916E-09);
    (r, g, b) = (100, 20, 50);
    UpdateTrackbars();
    afbeelding.Invalidate();
}
void VbRechtsOnderKlik(object o, EventArgs ea)
{
    UpdateVariabelen(100, 0.0, 0.0, 0.01);
    (r, g, b) = (100, 200, 1);
    UpdateTrackbars();
    afbeelding.Invalidate();
}

void BtnRandomKlik(object o, EventArgs ea)
{
    Random rand = new Random();
    middenX = -1.5 + rand.NextDouble() * 2;
    middenY = -1.5 + rand.NextDouble() * 2;
    schaal = rand.NextDouble() / rand.Next(100, 600);
    UpdateVariabelen(aantal, middenX, middenY, schaal);
    afbeelding.Invalidate();

}
void MuisOpBtnStart(object o, EventArgs ea)
{
    btnStart.BackColor = Color.HotPink;
}
void MuisWegBtnStart(object o, EventArgs ea)
{
    btnStart.BackColor = Color.DeepPink;
}
void MuisOpBtnRandom(object o, EventArgs ea)
{
    btnRandom.BackColor = Color.LightGray;
}
void MuisWegBtnRandom(object o, EventArgs ea)
{
    btnRandom.BackColor = Color.White;
}



void AfbeeldingMuisKlik(object o, MouseEventArgs mea)
{
    middenX += (mea.X - breedte * 0.5) * schaal;
    middenY += (mea.Y - hoogte * 0.5) * schaal;
    if (mea.Button == MouseButtons.Left)
        schaal = schaal / 2;
    else schaal = schaal * 2;
    UpdateVariabelen(aantal, middenX, middenY, schaal);
    afbeelding.Invalidate();
}

int Mandelgetal(double x, double y, int n)
{
    double a = 0;
    double b = 0;
    for (int teller = 1; teller < n; teller++)
    {
        double kwadraatB = b * b;
        b = 2 * a * b + y;
        a = a * a - kwadraatB + x;
        if ( a * a + b * b > 4) 
        {
            return teller;
        }
    }
    return n;
}


double Midden(double mPunt, double mSchaal, double mGrootte)
{
    return mPunt - mSchaal * mGrootte * 0.5;
}

void Teken(Graphics gr)
{
    UpdateKleuren();
    for (int x = 0; x < breedte; x++)
    {
        for (int y = 0; y < hoogte; y++)
        {
            int m = Mandelgetal(schaal * x + Midden(middenX, schaal, breedte), schaal * y + Midden(middenY, schaal, breedte), aantal);
            int blauw = (int)((double)(m) % b);
            int groen = (int)((double)(m) % g);
            int rood = (int)((double)(m) % r);
            gr.DrawRectangle(new Pen(Color.FromArgb((int)rood, (int)groen, (int)blauw)), (int)x, (int)y, 1, 1);

        }
    }
}

void VbTeken(Graphics gr, double vbSchaal, double vbMiddenX, double vbMiddenY, int vbAantal, int vbR, int vbG, int vbB)
{
    for (int x = 0; x < grootte; x++)
    {
        for (int y = 0; y < grootte; y++)
        {
            int m = Mandelgetal(vbSchaal * x + Midden(vbMiddenX, vbSchaal, grootte), vbSchaal * y + Midden(vbMiddenY, vbSchaal, grootte), vbAantal);
            int vbBlauw = (int)((double)(m) % vbB);
            int vbGroen = (int)((double)(m) % vbG);
            int vbRood = (int)((double)(m) % vbR);
            gr.DrawRectangle(new Pen(Color.FromArgb((int)vbRood, (int)vbGroen, (int)vbBlauw)), (int)x, (int)y, 1, 1);
        }
    }
}

scherm.Paint += Scherm_Paint;
scherm.Paint += Paintvoorbeeld1;
scherm.Paint += Paintvoorbeeld2;
scherm.Paint += Paintvoorbeeld3;
scherm.Paint += Paintvoorbeeld4;

void Scherm_Paint(object sender, PaintEventArgs e)
{
    Teken(gr);
}
void Paintvoorbeeld1(object sender, PaintEventArgs e)
{
    VbTeken(grVbLinksBoven, 1.953125E-05 * (breedte / grootte), -0.027812499999999997, -0.6943750000000001, 100, 20, 250, 7);
}
void Paintvoorbeeld2(object sender, PaintEventArgs e)
{
    VbTeken(grVbRechtsBoven, 1.5994037748903664E-08 * (breedte / grootte), -1.171058017854132, 0.1928888704065407, 1000, 200, 30, 5);
}
void Paintvoorbeeld3(object sender, PaintEventArgs e)
{
    VbTeken(grVbLinksOnder, 3.998509437225916E-09 * (breedte / grootte), -1.4024798924987962, 0.12644983863520337, 1000, 100, 20, 50);
}
void Paintvoorbeeld4(object sender, PaintEventArgs e)
{
    VbTeken(grVbRechtsOnder, 0.01 * (breedte / grootte), 0.0, 0.0, 100, 100, 200, 1);
}

afbeelding.MouseClick += AfbeeldingMuisKlik;
afbeelding.Paint += Scherm_Paint;
abVbLinksBoven.Paint += Paintvoorbeeld1;
abVbRechtsBoven.Paint += Paintvoorbeeld2;
afbVbLinksOnder.Paint += Paintvoorbeeld3;
afbVbRechtsOnder.Paint += Paintvoorbeeld4;

btnStart.Click += BtnStartKlik;
btnRandom.Click += BtnRandomKlik;
btnStart.MouseMove += MuisOpBtnStart;
btnStart.MouseLeave += MuisWegBtnStart;
btnRandom.MouseMove += MuisOpBtnRandom;
btnRandom.MouseLeave += MuisWegBtnRandom;

abVbLinksBoven.Click += VbLinksBovenKlik;
abVbRechtsBoven.Click += VbRechtsBovenKlik;
afbVbLinksOnder.Click += VbLinksOnderKlik;
afbVbRechtsOnder.Click += VbRechtsOnderKlik;
Application.Run(scherm);