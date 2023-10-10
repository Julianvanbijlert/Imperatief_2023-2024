using System;
using System.Windows.Forms;
using System.Drawing;

Form scherm = new Form();
scherm.Text = "OppervlakkigWinC";
scherm.ClientSize = new Size(240, 60);


Label   tekst    = new Label();   
TextBox invoer   = new TextBox(); 
Button  knop     = new Button();
Label   uitkomst = new Label();

scherm.Controls.Add(tekst);
scherm.Controls.Add(invoer);
scherm.Controls.Add(knop);
scherm.Controls.Add(uitkomst);

tekst   .Location = new Point( 60, 10); 
invoer  .Location = new Point(110,  6);
knop    .Location = new Point( 20, 32);
uitkomst.Location = new Point(110, 34); 
tekst   .Size     = new Size ( 40, 20);
invoer  .Size     = new Size ( 80, 20);
knop    .Size     = new Size ( 80, 20);
uitkomst.Size     = new Size (120, 20);

tekst.Text  = "straal:";
knop .Text  = "oppervlakte:";

double kwadraat(double x)
{   return x * x;
}
double cirkelOppervlakte(double straal)
{   return Math.PI * kwadraat(straal);
}
void bereken(object o, EventArgs e)
{   double r = double.Parse(invoer.Text);
    double a = cirkelOppervlakte(r);
    uitkomst.Text = a.ToString();
}

knop.Click += bereken;

Application.Run(scherm);