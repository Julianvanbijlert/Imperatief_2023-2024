using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
public class ListDemo : Form
{
    TextBox invoer;
    List<String> alles;

    public ListDemo()
    {
        this.alles = new List<String>();

        this.invoer = new TextBox(); Controls.Add(invoer);
        Button knop = new Button();  Controls.Add(knop);
        invoer.Location = new Point( 10,10); invoer.Size = new Size(100, 14);
        knop  .Location = new Point(130,10); knop.Text = "Toevoegen";
        knop.Click += klik;
        Paint += teken;
    }
    private void klik(object o, EventArgs ea)
    {
        alles.Add(invoer.Text);
        invoer.Text = "";
        Invalidate();
    }
    private void teken(object o, PaintEventArgs pea)
    {
        int y = 40;
        Font font = new Font("Tahoma", 12);
        for (int t = 0; t < alles.Count; t++)
        {
            pea.Graphics.DrawString(alles[t], font, Brushes.Black, new Point(10, y));
            y += 20;
        }
    }
    public static void Main()
    {
        Application.Run(new ListDemo());
    }
}