using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
namespace Emma_s_Mandelbrot
{
    internal static class Program
    {

        static void Main()
        {

            //Globale variabelen
            int algemene_grootte = 100;
            int breedte_scherm = 600;
            int hoogte_scherm = 600;

            int breedte = Convert.ToInt32(breedte_scherm * 0.7);
            int hoogte = Convert.ToInt32(hoogte_scherm * 0.7);

            int aantal = 1000;
            double middenX = 0;
            double middenY = 0;
            double schaal = 0.01;

            Queue<CheckBox> checkedCheckBoxes3 = new Queue<CheckBox>();
            //-----------------------------------------------------Schermtekenen---------------------------------------------------

            //de form
            Form scherm = new Form();
            scherm.Text = "mandelbrot windows";
            scherm.BackColor = Color.AntiqueWhite;
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

            

            
            //---------------------------------------------------------Buttons----------------------------------------------------------

            TextBox AantalTB = MakeTextBox(100, hoogte + 20, "1000");
            TextBox MiddenXTB = MakeTextBox(100, hoogte + 60, "0");
            TextBox MiddenYTB = MakeTextBox(100, hoogte + 100, "0");
            TextBox SchaalTB = MakeTextBox(100, hoogte + 140, "0,01");

            Label labelA = MakeLabel( 10, hoogte + 20, "Aantal");
            Label labelX = MakeLabel(10, hoogte + 60, "Midden X");
            Label labelY = MakeLabel(10, hoogte + 100, "Midden Y");
            Label labelS = MakeLabel(10, hoogte + 140, "Schaal");

            Button BStart = MakeButton(200 , hoogte + 20,"start");
            Button V1 = MakeButton(200, hoogte + 100, "voorbeeld");
            Button V2 = MakeButton(300, hoogte + 100, "voorbeeld");
            Button V3 = MakeButton(200, hoogte + 60, "voorbeeld");
            Button V4 = MakeButton(300, hoogte + 60, "voorbeeld");

            List<CheckBox> checkBoxes = new List<CheckBox>();
            CheckBox CBRood = MakeCheckBox(breedte + 10, 10, Color.Red);
            CheckBox CBGroen = MakeCheckBox(breedte + 10, 30, Color.Green);
            CheckBox CBBlauw = MakeCheckBox(breedte + 10, 50, Color.Blue);
            CheckBox CBRoze = MakeCheckBox(breedte + 10, 70, Color.HotPink);
            CheckBox CBPaars = MakeCheckBox(breedte + 10, 90, Color.FromArgb(255, 102, 255));
            CheckBox CBOranje = MakeCheckBox(breedte + 10, 110, Color.FromArgb(255, 133, 51));
            CheckBox CBGeel = MakeCheckBox(breedte + 10, 130, Color.FromArgb(255, 255, 77));
            CheckBox CBWit = MakeCheckBox(breedte + 10, 150, Color.FromArgb(250, 250, 250));
            CheckBox CBZwart = MakeCheckBox(breedte + 10, 170, Color.FromArgb(0, 0, 0));

            //--------------------------------------------------Specifieke buttons hard code-------------------------------------------------
            //CBRoze.Checked = true;
            //CBRood.Checked = true;

            BStart.Click += BitmapMaak;
            V1.Click += tekenvoorbeeld1;
            V2.Click += tekenvoorbeeld2;
            V3.Click += tekenvoorbeeld3;
            V4.Click += tekenvoorbeeld4;
            bitmapLabel.MouseClick += Zoom;
            Teken();

            //funtions to draw preset images
            void tekenvoorbeeld1(object o, EventArgs e)
            {
                UpdateVariabelen(1000, 0.41877441406249993, -0.20927368164062501, 1.220703125E-06);
                CBRoze.Checked = true;
                CBRood.Checked = true;

            }
            void tekenvoorbeeld2(object o, EventArgs e)
            {
                UpdateVariabelen(1000, -0.5622027284605429, -0.6428193145562545, 1.4551915228366852E-13);
                CBRood.Checked = true;
                CBBlauw.Checked = true;
            }
            void tekenvoorbeeld3(object o, EventArgs e)
            {
                UpdateVariabelen(50, 0.4259375, -0.2140625, 0.00015625);
                CBRoze.Checked = true;
                CBGroen.Checked = true;
            }
            void tekenvoorbeeld4(object o, EventArgs e)
            {
                UpdateVariabelen(100, -1.38734375, -0.015859374999999863, 3.90625E-05);
                CBRoze.Checked = true;
                CBBlauw.Checked = true;

            }

            //-----------------------------------------------------Mandelbrot Tekenen----------------------------------------------



            void Teken()
            {
                int m;
                Color c = Color.Yellow;
                Color c1 = Color.Black;
                Color c2 = Color.White;
                try
                {
                    CheckBox check1 = checkedCheckBoxes3.Dequeue();
                    c1 = check1.BackColor;
                    checkedCheckBoxes3.Enqueue(check1);
                }
                catch (Exception e)
                { }
                try
                {

                    CheckBox check2 = checkedCheckBoxes3.Dequeue();
                    c2 = check2.BackColor;
                    checkedCheckBoxes3.Enqueue(check2);
                }
                catch (Exception e)
                { }
                

                Color c3 = MixKleur(c1, c2);

                for (int x = 0; x < breedte; x++)
                {
                    for (int y = 0; y < hoogte; y++)
                    {
                        m = MandelGetal(hoekpunt(middenX, hoogte, schaal, x), hoekpunt(middenY, breedte, schaal, y), aantal);
                        //manier om m naar kleur te maken


                        if (m % 2 == 0)
                        {
                            c = c1;
                        }
                        else if (m % 3 == 0)
                        {
                            c = c2;
                        }
                        else c = c3;

                        plaatje.SetPixel(x, y, c);

                    }
                }

            }
            //int blauw = (int)((double)(m) % b);
            //int groen = (int)((double)(m) % g);
            //int rood = (int)((double)(m) % r);

            double hoekpunt(double punt, double groote, double schaal, int i)
            {
                return (punt - (0.5 *groote * schaal)) + (i * schaal);
            }

            //Formule om MandelGetal te berekenen
            int MandelGetal(double x, double y, int k)
            {
                    int t = 0;
                    double a = 0;
                    double b = 0;

                    while (((a * a + b * b) < 4) && t < k)
                    {
                        double aTemp = (a * a) - (b * b) + x;
                        b = 2 * a * b + y;
                        a = aTemp;

                        t++;
                    }

                    return t;
                
            }

            //Functie die  variabelen update en bitmap opnieuw laat tekenen
            void UpdateVariabelen(int invoerAantal, double invoerMiddenX, double invoerMiddenY, double invoerSchaal)
            {
                    aantal = invoerAantal;
                    middenX = invoerMiddenX;
                    middenY = invoerMiddenY;
                    schaal = invoerSchaal;

                    AantalTB.Text = aantal.ToString();
                    MiddenXTB.Text = middenX.ToString();
                    MiddenYTB.Text = middenY.ToString();
                    SchaalTB.Text = schaal.ToString();

                Teken();
                bitmapLabel.Invalidate();
            }

            //Functie voor mouseclick op bitmaplabel, maakt dat punt het nieuwe midden en update de schaal.
            //Daarna update het de variabelen (waarna de bitmap opnieuw getekent wordt).
            void Zoom(object o, MouseEventArgs mea)
            {
                middenX += (mea.X - breedte * 0.5) * schaal;
                middenY += (mea.Y - hoogte * 0.5) * schaal;
                if (mea.Button == MouseButtons.Left)
                {
                    schaal *= 0.5;
                }

                else 
                {
                    schaal *= 2;
                }
                
                UpdateVariabelen(aantal, middenX, middenY, schaal);
            }



            //-----------------------------------------------------Knoppen en events----------------------------------------------------------
            //we zijn van plan meerdere labels te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            Label MakeLabel(int x, int y, string s)
            {
                Label L   = new Label();
                L.Size = new Size(80, 20);
                L.Location = new Point(x, y);
                L.BackColor = Color.Aquamarine ;
                scherm.Controls.Add(L);
                L.Text = s;
                return L;
            }
            
            //we zijn van plan meerdere Textbox te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            TextBox MakeTextBox(int x, int y, string s)
            {
                TextBox T = new TextBox();
                T.Size = new Size(80, 20);
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
                b.Size = new Size(80, 20);
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

            //we zijn van plan meerdere checkboxes te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            CheckBox MakeCheckBox(int x, int y, Color c)
            {
                CheckBox b = new CheckBox();
                b.Location= new Point(x, y);
                b.Checked = false;
                b.BackColor = c;
                b.CheckedChanged += CheckBoxTick;
                checkBoxes.Add(b);
                scherm.Controls.Add(b);
                return b;
            }

            //domme functie waarschijnlijk weghalen
            void VeranderSchermGrootte(object o, EventArgs ea)
            {
                breedte_scherm = scherm.Width;
                hoogte_scherm = scherm.Height;
                scherm.Size = new Size(breedte_scherm, hoogte_scherm);
                scherm.Invalidate();
            }

            //Neem info uit textboxen en teken de bitmap
            void BitmapMaak(object o, EventArgs ea)
            {
                try
                {
                    UpdateVariabelen(int.Parse(AantalTB.Text), double.Parse(MiddenXTB.Text), double.Parse(MiddenYTB.Text), double.Parse(SchaalTB.Text));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); 
                }
            }

            //Tekent bitmap opnieuw als kleuren veranderen
            void CheckBoxTick(object o, EventArgs ea)
            {
                GetKleuren3((CheckBox)o);
                Teken();
                bitmapLabel.Invalidate();
            }

            //Functie de kleuren in een queue van max length 2 aanpast om zo de 2 kleuren te kiezen voor het tekenen
            void GetKleuren3(CheckBox c)
            {
                CheckBox b;
                if (checkedCheckBoxes3.Count() >= 2)
                {
                    checkedCheckBoxes3.Enqueue(c);
                    c.Checked = false;
                    b = checkedCheckBoxes3.Dequeue();
                    b.Checked = false;
                }
                else
                {
                    checkedCheckBoxes3.Enqueue(c);
                    c.Checked = false;
                }
            }

            Color MixKleur(Color color, Color color2)
            {
                byte r = (byte)(color.R * 0.5 + color2.R * 0.5);
                byte g = (byte)(color.G * 0.5 + color2.G * 0.5);
                byte b = (byte)(color.B * 0.5 + color2.B * 0.5);
                return Color.FromArgb(r, g, b);
            }

            //alles aan scherm toevoegen en scherm toevoegen
            
            Application.Run(scherm);
        }
        
    }
}