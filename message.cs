using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


    public class Scherm : Form
    {
        //hier wordt de tekst aangemaakt
        public Label kiesRooster = new Label();
        public Label wieAanZet = new Label();
        public Label doeEenZet = new Label();

        //hier worden alle knoppen aanggemaakt
        public Button knop4 = new Button();
        public Button knop6 = new Button();
        public Button knop8 = new Button();
        public Button knop10 = new Button();
        public Button nieuwSpel = new Button();
        public Button help = new Button();

        //bitmap, graphics en de rest
        public Bitmap plaatje;
        public Graphics Gr;
        Label afbeelding = new Label();
        int grootteSpelbord = 480;
        int lengtesb = 6;
        Point [,] spelbordPunten;
        int[,] spelbord;


        //brushes
        Brush bluebrush = new SolidBrush(Color.Blue);
        Brush redbrush = new SolidBrush(Color.Red);
        Brush kwast = new SolidBrush(Color.Green);
        Brush graybrush = new SolidBrush(Color.LightGray);

        //teller
        int teller = 0;
        public Scherm()
        {
            //bitmap aanmaken
            plaatje = new Bitmap(grootteSpelbord, grootteSpelbord);

            //graphics
            Gr = Graphics.FromImage(plaatje);

            spelbordPunten = new Point [lengtesb, lengtesb];
            spelbord = new int[lengtesb, lengtesb];

            //label aanmaken om Bitmap te laten zien
            this.Controls.Add(afbeelding);
            afbeelding.Location = new Point(60, 250);
            afbeelding.Size = new Size(grootteSpelbord, grootteSpelbord);
            afbeelding.BackColor = Color.WhiteSmoke;
            afbeelding.Image = plaatje;

            //wat er gebeurt als een roosterknop wordt aangeklikt
            knop4.Click += tekenbord4;
            knop6.Click += tekenbord6;
            knop8.Click += tekenbord8;
            knop10.Click += tekenbord10;

            //dit gebeurt er als je op nieuw spel knop klikt
            nieuwSpel.Click += nieuwspel;

            //dit gebeurt er als er op het scherm wordt geklikt
            afbeelding.MouseClick += klik;

            //beginsituatie spelbord
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();

            //eigenschappen scherm
            this.Text = "Project 2";
            this.BackColor = Color.LightGray;
            this.ClientSize = new Size(600, 1000);

            //hier worden alle knoppen en wordt alle tekst toegevoegd aan het scherm
            this.Controls.Add(knop4);
            this.Controls.Add(knop6);
            this.Controls.Add(knop8);
            this.Controls.Add(knop10);
            this.Controls.Add(nieuwSpel);
            this.Controls.Add(help);
            this.Controls.Add(kiesRooster);
            this.Controls.Add(wieAanZet);
            this.Controls.Add(doeEenZet);

            //hier worden de eigenschappen van de knoppen vastgelegd
            int lengteknopr = 100;
            int hoogteknopr = 50;
            knop4.Size = new Size(lengteknopr, hoogteknopr);
            knop6.Size = new Size(lengteknopr, hoogteknopr);
            knop8.Size = new Size(lengteknopr, hoogteknopr);
            knop10.Size = new Size(lengteknopr, hoogteknopr);
            int lengteknopt = 100;
            int hoogteknopt = 25;
            nieuwSpel.Size = new Size(lengteknopt, hoogteknopt);
            help.Size = new Size(lengteknopt, hoogteknopt);

            knop4.Location = new Point(60, 175);
            knop6.Location = new Point(186, 175);
            knop8.Location = new Point(314, 175);
            knop10.Location = new Point(440, 175);
            nieuwSpel.Location = new Point(186, 10);
            help.Location = new Point(314, 10);

            knop4.Text = "4×4";
            knop6.Text = "6×6";
            knop8.Text = "8×8";
            knop10.Text = "10×10";
            nieuwSpel.Text = "Nieuw spel";
            help.Text = "Help";

            knop4.BackColor = Color.WhiteSmoke;
            knop6.BackColor = Color.WhiteSmoke;
            knop8.BackColor = Color.WhiteSmoke;
            knop10.BackColor = Color.WhiteSmoke;
            nieuwSpel.BackColor = Color.WhiteSmoke;
            help.BackColor = Color.WhiteSmoke;

            //hier worden de eigenschappen van de tekst vastgelegd
            kiesRooster.Location = new Point(60, 155);
            kiesRooster.Text = "Kies je spelbord:";
            wieAanZet.Location = new Point(60, 40);
            wieAanZet.Text = "Blauw is aan zet!";
            doeEenZet.Location = new Point(60, 60);
            doeEenZet.Text = "Doe een zet!";
        }

        //deze functie maakt de juiste array
        public Point[,] arraymakerPunten()
        {
            Point[,] spelbordpunten = new Point[lengtesb, lengtesb];
            int lengtevakje = grootteSpelbord / lengtesb;
            for (int i = 0; i < lengtesb; i++)
            {
                for (int j = 0; j < lengtesb; j++)
                {
                    int xcoor = lengtevakje * i;
                    int ycoor = lengtevakje * j;
                    spelbordpunten[i, j] = new Point(xcoor, ycoor);
                }
            }
            return spelbordpunten;
        }
        public int[,] arraymaker()
        {
            int[,] spelbord = new int[lengtesb, lengtesb];
            int lengtevakje = grootteSpelbord / lengtesb;
            for (int i = 0; i < lengtesb; i++)
            {
                for (int j = 0; j < lengtesb; j++)
                {
                    if (i==3 && j==3)
                    {
                        spelbord[i, j] = 0;
                    }
                    else if (i == 3 && j == 4)
                    {
                        spelbord[i, j] = 1;
                    }
                    else if (i == 4 && j == 3)
                    {
                        spelbord[i, j] = 1;
                    }
                    else if (i == 4 && j == 4)
                    {
                        spelbord[i, j] = 0;
                    }
                    else
                    {
                        spelbord[i, j] = 2;
                    }
                }
            }
        
            return spelbord;
        }
        //deze functie tekent het rooster
        private void tekenrooster()
        {
            Pen pen = new Pen(Color.Black, 1);
            for (int i = 0; i <= lengtesb; i++)
            {
                for (int j = 0; j <= lengtesb; j++)
                {
                    //laatste lijn
                    int ihoogx = grootteSpelbord - 1;
                    int ihoogy = 0;
                    int ilaagx = grootteSpelbord - 1;
                    int ilaagy = grootteSpelbord - 1;
                    Gr.DrawLine(pen, ihoogx, ihoogy, ilaagx, ilaagy);

                    //rest van de lijnen
                    int iHoogx = grootteSpelbord / lengtesb * i;
                    int iHoogy = 0;
                    int iLaagx = grootteSpelbord / lengtesb * i;
                    int iLaagy = grootteSpelbord;
                    Gr.DrawLine(pen, iHoogx, iHoogy, iLaagx, iLaagy);

                    //laatste lijn
                    int jlaagy = grootteSpelbord - 1;
                    int jlaagx = 0;
                    int jhoogy = grootteSpelbord - 1;
                    int jhoogx = grootteSpelbord - 1;
                    Gr.DrawLine(pen, jhoogx, jhoogy, jlaagx, jlaagy);

                    //rest van de lijnen
                    int jLaagy = grootteSpelbord / lengtesb * j;
                    int jLaagx = 0;
                    int jHoogy = grootteSpelbord / lengtesb * j;
                    int jHoogx = grootteSpelbord;
                    Gr.DrawLine(pen, jHoogx, jHoogy, jLaagx, jLaagy);

                }

                afbeelding.Invalidate();
            }

        }
        //deze functie tekent een rode of blauwe cirkel
        public void tekencirkels(object sender, MouseEventArgs mea)
        {
            Brush kwast = kwastje(teller);
            int lengtevakje = grootteSpelbord / lengtesb;
            int x = mea.X / lengtevakje;
            int y = mea.Y / lengtevakje;
            int xcoor = spelbordPunten[x,y].X;
            int ycoor = spelbordPunten[x,y].Y;
            if (teller % 2 == 0)
            {
                spelbord[x, y] = 0;
            }
            else
            {
                spelbord[x, y] = 1;
            }
            Gr.FillEllipse(kwast, xcoor, ycoor, lengtevakje, lengtevakje);
            afbeelding.Invalidate();
            teller += 1;
        }
        //deze functie maakt de kwast de juiste kleur voor het tekenen van de zet
        public Brush kwastje(int a)
        {
            if (a % 2 == 0)
            {
                kwast = bluebrush;
            }
            else
            {
                kwast = redbrush;
            }
            return kwast;
        }
        //deze functie tekent een rode of blauwe cirkel als je klikt
        
        public void klik(object sender, MouseEventArgs mea)
        {
            spelbord = checkfunctie();
            int lengtevakje = grootteSpelbord / lengtesb;
            int x = mea.X / lengtevakje;
            int y = mea.Y / lengtevakje;
            if (spelbord[x,y] == 3)
            {
                tekencirkels(sender, mea);
                doeEenZet.Text = "Doe een zet!";
            }
            else
            {
                doeEenZet.Text = "Geen legale zet. Probeer een andere zet!";
            }
            
            wieIsAanZet();
        }
        //deze functie laat zien wie aan zet is
        public void wieIsAanZet()
        {
            if (teller % 2 == 0)
            {
                wieAanZet.Text = "Blauw is aan zet!";
            }
            else
            {
                wieAanZet.Text = "Rood is aan zet!";
            }

        }

        //deze functie tekent de middelste vier cirkels
        private void tekenstartcirkels()
        {
            int lengtevakje = grootteSpelbord / lengtesb;

            int x1 = lengtevakje * ((lengtesb / 2) - 1);
            int y1 = lengtevakje * ((lengtesb / 2) - 1);
            Gr.FillEllipse(bluebrush, x1, y1, lengtevakje, lengtevakje);

            int x2 = lengtevakje * ((lengtesb / 2));
            int y2 = lengtevakje * ((lengtesb / 2) - 1);
            Gr.FillEllipse(redbrush, x2, y2, lengtevakje, lengtevakje);

            int x3 = lengtevakje * ((lengtesb / 2) - 1);
            int y3 = lengtevakje * ((lengtesb / 2));
            Gr.FillEllipse(redbrush, x3, y3, lengtevakje, lengtevakje);

            int x4 = lengtevakje * ((lengtesb / 2));
            int y4 = lengtevakje * ((lengtesb / 2));
            Gr.FillEllipse(bluebrush, x4, y4, lengtevakje, lengtevakje);
            afbeelding.Invalidate();
        }
        //functies bij roosterknoppen
        private void tekenbord10(object o, EventArgs e)
        {
            teller = 0;
            doeEenZet.Text = "Doe een zet!";
            lengtesb = 10;
            Gr.Clear(Color.White);
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();
        }
        private void tekenbord8(object o, EventArgs e)
        {
            teller = 0;
            doeEenZet.Text = "Doe een zet!";
            lengtesb = 8;
            Gr.Clear(Color.White);
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();
        }
        private void tekenbord6(object o, EventArgs e)
        {
            teller = 0;
            doeEenZet.Text = "Doe een zet!";
            lengtesb = 6;
            Gr.Clear(Color.White);
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();
        }
        private void tekenbord4(object o, EventArgs e)
        {
            teller = 0;
            doeEenZet.Text = "Doe een zet!";
            lengtesb = 4;
            Gr.Clear(Color.White);
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();
        }
        //functie bij nieuw spel knop
        private void nieuwspel(object o, EventArgs e)
        {
            teller = 0;
            doeEenZet.Text = "Doe een zet!";
            lengtesb = 6;
            Gr.Clear(Color.White);
            tekenrooster();
            tekenstartcirkels();
            spelbordPunten = arraymakerPunten();
            spelbord = arraymaker();
        }

        public int [,] checkfunctie()
        {
            if (teller % 2 == 0)
            {
                for (int i = 0; i < lengtesb; i++)
                {
                    for (int j = 0; j < lengtesb; j++)
                    {
                        if (spelbord[i, j] == 2)
                        {
                            if (i + 1 < lengtesb && spelbord[i+1, j] == 1)
                            {
                                for (int m = i + 2; i + 1 < m && m < lengtesb; m++)
                                {
                                    if (spelbord[m,j] == 0)
                                    {
                                        spelbord[i,j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, j] == 2 || spelbord[m, j] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i - 1 >= 0 && spelbord[i - 1, j] == 1)
                            {
                                for (int m = i - 2; i - 1 > m && m >= 0; m--)
                                {
                                    if (spelbord[m, j] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, j] == 2 || spelbord[m,j] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (j + 1 < lengtesb && spelbord[i, j+1] == 1)
                            {
                                for (int n = j + 2; j + 1 < n && n < lengtesb; n++)
                                {
                                    if (spelbord[i, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[i, n] == 2 || spelbord[i, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (j-1 >= 0 && spelbord[i, j-1] == 1)
                            {
                                for (int n = j - 2; j - 1 > n && n >= 0; j--)
                                {
                                    if (spelbord[i, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[i, n] == 2)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i+1<lengtesb && j+1< lengtesb && spelbord[i+1, j+1] == 1)
                            {
                                int m;
                                int n;
                                for (m = i + 2, n = j + 2; i + 1 < m && m < lengtesb && j + 1 < n && n < lengtesb; i++, j++)
                                {
                                    if (spelbord[m, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i+1<lengtesb && j-1>= 0 && spelbord[i+1, j-1] == 1)
                            {
                                int m;
                                int n;
                                for (m = i + 2, n = j - 2; i + 1 < m && m < lengtesb && j - 1 > n && n >= 0; i++, j--)
                                {
                                    if (spelbord[m, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i-1 >= 0 && j+1 < lengtesb && spelbord[i-1, j+1] == 1)
                            {
                                int m;
                                int n;
                                for (m = i - 2, n = j + 2; i - 1 > m && m >= 0 && j + 1 < n && n < lengtesb; i--, j++)
                                {
                                    if (spelbord[m, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i-1 >= 0 && j-1 >= 0 && spelbord[i-1, j-1] == 1)
                            {
                                int m;
                                int n;
                                for (m = i - 2, n = j - 2; i - 1 > m && m >= 0 && j - 1 > n && n >= 0; i--, j--)
                                {
                                    if (spelbord[m, n] == 0)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < lengtesb; i++)
                {
                    for (int j = 0; j < lengtesb; j++)
                    {
                        if (spelbord[i, j] == 2)
                        {
                            if (i + 1 < lengtesb && spelbord[i + 1, j] == 0)
                            {
                                for (int m = i + 2; i + 1 < m && m < lengtesb; m++)
                                {
                                    if (spelbord[m, j] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, j] == 2 || spelbord[m, j] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i - 1 >= 0 && spelbord[i - 1, j] == 0)
                            {
                                for (int m = i - 2; i - 1 > m && m >= 0; m--)
                                {
                                    if (spelbord[m, j] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, j] == 2 || spelbord[m, j] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (j + 1 < lengtesb && spelbord[i, j + 1] == 0)
                            {
                                for (int n = j + 2; j + 1 < n && n < lengtesb; n++)
                                {
                                    if (spelbord[i, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[i, n] == 2 || spelbord[i, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (j - 1 >= 0 && spelbord[i, j - 1] == 0)
                            {
                                for (int n = j - 2; j - 1 > n && n >= 0; j--)
                                {
                                    if (spelbord[i, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[i, j] == 2 || spelbord[i, j] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i + 1 < lengtesb && j + 1 < lengtesb && spelbord[i + 1, j + 1] == 0)
                            {
                                int m;
                                int n;
                                for (m = i + 2, n = j + 2; i + 1 < m && m < lengtesb && j + 1 < n && n < lengtesb; i++, j++)
                                {
                                    if (spelbord[m, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i + 1 < lengtesb && j - 1 >= 0 && spelbord[i + 1, j - 1] == 0)
                            {
                                int m;
                                int n;
                                for (m = i + 2, n = j - 2; i + 1 < m && m < lengtesb && j - 1 > n && n >= 0; i++, j--)
                                {
                                    if (spelbord[m, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i - 1 >= 0 && j + 1 < lengtesb && spelbord[i - 1, j + 1] == 0)
                            {
                                int m;
                                int n;
                                for (m = i - 2, n = j + 2; i - 1 > m && m >= 0 && j + 1 < n && n < lengtesb; i--, j++)
                                {
                                    if (spelbord[m, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            if (i - 1 >= 0 && j - 1 >= 0 && spelbord[i - 1, j - 1] == 0)
                            {
                                int m;
                                int n;
                                for (m = i - 2, n = j - 2; i - 1 > m && m >= 0 && j - 1 > n && n >= 0; i--, j--)
                                {
                                    if (spelbord[m, n] == 1)
                                    {
                                        spelbord[i, j] = 3;
                                        break;
                                    }
                                    else if (spelbord[m, n] == 2 || spelbord[m, n] == 3)
                                    {
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return spelbord;
        }
        
    /*
        public int kleurenomdraaien(int a)
        {
            for (int i = 0; i < lengtesb; i++)
            {
                for (int j = 0; j < lengtesb; j++)
                {
                    if (spelbord[i, j] == 2)
                    {

                    }
                }
            }
            return a;
        }
    */
        static void Main()
        {
            Application.Run(new Scherm());
        }

        //hier tekenen we een cirkel in het vakje waarop wordt geklikt
        //void tekeneenzet()
    }
    public class Program
    {

        static void Main()
        {
            Scherm Screen = new Scherm();
            Application.Run(Screen);

        }



    }
//Application.Run(scherm);

