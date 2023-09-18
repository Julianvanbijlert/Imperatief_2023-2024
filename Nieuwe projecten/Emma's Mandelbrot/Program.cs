            using System;
            using System.Data;
            using System.Data.Common;
            using System.Drawing;
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

















            //alles aan scherm toevoegen en scherm toevoegen


            Application.Run(scherm);
        }
    }
}