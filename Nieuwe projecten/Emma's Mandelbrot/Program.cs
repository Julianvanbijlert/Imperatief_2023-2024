using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace Emma_s_Mandelbrot
{
    internal static class Program
    {

        static void Main()
        {


            //Globale variabelen

            int algemene_grootte = 100;
            int breedte_scherm = 400;
            int hoogte_scherm = 400;

            int breedte = Convert.ToInt32(breedte_scherm * 0.9);
            int hoogte = Convert.ToInt32(hoogte_scherm * 0.9);

            int aantal = 100;
            double middenX = -0.027812499999999997;
            double middenY = -0.694375000000000;
            double schaal = 1.953125E-05;



            //-----------------------------------------------------Schermtekenen---------------------------------------------------

            //de form
            Form scherm = new Form();
            scherm.Text = "mandelbrot windows";
            scherm.ClientSize = new Size(breedte_scherm, hoogte_scherm);

            //bitmap voor mandelbrot, met graphics en label
            Bitmap plaatje = new Bitmap(breedte, hoogte);
            Graphics gr = Graphics.FromImage(plaatje);
            Label bitmapLabel = new Label();
            //attributen
            bitmapLabel.Location = new Point(10, 10);
            bitmapLabel.Size = new Size(breedte, hoogte);
            bitmapLabel.BackColor = Color.Transparent;
            bitmapLabel.Image = plaatje;
            //toevoegen
            scherm.Controls.Add(bitmapLabel);

            

            




            //-----------------------------------------------------Mandelbrot Tekenen----------------------------------------------

            //Functie die voor elk punt mandelgetal laat uitrekenen en dan tekent
            void Teken(Graphics gr)
            {
                int m;
                double rood;
                double groen;
                double blauw;
                for(int x = 0; x < breedte; x++) 
                { 
                    for(int y = 0; y < hoogte; y++)
                    {
                            m = MandelGetal(x, y, aantal);
                        //manier om m naar kleur te maken
                            if(m % 2 == 0)
                        {
                            rood = 255;
                            groen = 255;
                            blauw = 255;
                        }
                        else
                        {
                            rood = 0;
                            groen = 0;
                            blauw = 255;
                        }
                            gr.DrawRectangle(new Pen(Color.FromArgb((int)rood, (int)groen, (int)blauw)), x, y, 1, 1);
                    }
                } 
            }

            double Midden(double mPunt, double mSchaal, double mGrootte)
            {
                return mPunt - mSchaal * mGrootte * 0.5;
            }

            //Formule om MandelGetal te berekenen
            int MandelGetal(double x, double y, int n)
            {
                double a = 0;
                double b = 0;
                for (int teller = 1; teller < n; teller++)
                {
                    double kwadraatB = b * b;
                    b = 2 * a * b + y;
                    a = a * a - kwadraatB + x;
                    if (a * a + b * b > 4)
                    {
                        return teller;
                    }
                }
                return n;
            }








            //-----------------------------------------------------Knoppen en events----------------------------------------------------------
            //we zijn van plan meerdere labels te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            Label MakeLabel(int x, int y, string s)
            {
                Label L   = new Label();
                L.Size = new Size(Convert.ToInt32(0.2 * breedte_scherm), Convert.ToInt32(0.05 * hoogte_scherm));
                L.Location = new Point(x, y);
                L.BackColor = Color.Aquamarine ;
                scherm.Controls.Add(L);
                L.Text = s;
                return L;
            }

            TextBox MakeTextBox(int x, int y, string s)
            {
                TextBox T = new TextBox();
                T.Size = new Size(Convert.ToInt32(0.2 * breedte_scherm), Convert.ToInt32(0.05 * hoogte_scherm));
                T.Location = new Point(x, y);
                T.BackColor = Color.White;
                scherm.Controls.Add(T);
                T.Text = s;
                return T;
            }

            //we zijn van plan meerdere buttons te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            Button MakeButton(int x, int y, string s)
            {
                Button b = new Button();
                b.Size = new Size(Convert.ToInt32(0.2*breedte_scherm), Convert.ToInt32(0.05 * hoogte_scherm));
                b.Location = new Point(x, y);
                b.BackColor = Color.AliceBlue;
                b.Text = s;

                //kleurtjes veranderen als je eroverheen gaat
                b.MouseMove += (sender, e) =>
                {
                    b.BackColor = Color.LightGray;
                };
                b.MouseLeave += (sender, e) => {
                    b.BackColor= Color.AliceBlue;
                };

                scherm.Controls.Add(b);
                return b;
            }

            //domme functie waarschijnlijk weghalen
            void VeranderSchermGrootte(object o, EventArgs ea)
            {
                breedte_scherm += 50;
                hoogte_scherm += 50;
                scherm.Size = new Size(breedte_scherm, hoogte_scherm);
                scherm.Invalidate();
            }
            
            void Scherm_Paint(object sender, PaintEventArgs e)
            {
                Teken(gr);
            }

            Label label = MakeLabel( 10, hoogte + 20, "Startknop");
            Button b = MakeButton(100 , hoogte + 20,"start");
            TextBox textBox = MakeTextBox(190, hoogte + 20, "StartText");
            b.Click += VeranderSchermGrootte;

            //alles aan scherm toevoegen en scherm toevoegen
            bitmapLabel.Paint += Scherm_Paint;
            Application.Run(scherm);
        }
    }
}