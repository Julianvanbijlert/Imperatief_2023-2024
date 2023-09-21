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





            //-----------------------------------------------------Schermtekenen---------------------------------------------------

            //de form
            Form scherm = new Form();
            scherm.Text = "mandelbrot windows";
            scherm.ClientSize = new Size(breedte_scherm, hoogte_scherm);


            //bitmap voor 
            Bitmap plaatje = new Bitmap(breedte_scherm, hoogte_scherm);
            Graphics gr = Graphics.FromImage(plaatje);
            Label afbeelding = new Label();








            //-----------------------------------------------------Mandelbrot Tekenen----------------------------------------------












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

            //we zijn van plan meerdere buttons te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
            Button MakeButton(int x, int y, string s)
            {
                Button b = new Button();
                b.Size = new Size(80, 20);
                b.Location = new Point(x, y);
                b.BackColor = Color.AliceBlue;
                b.Text = s;

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

            Button b = MakeButton(120, 50,"start");
            Label label = MakeLabel( 30, 50, "Wie dit leest is gek");












            //alles aan scherm toevoegen en scherm toevoegen


            Application.Run(scherm);
        }
    }
}