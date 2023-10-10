using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class Snelweg : Form
{
    List<Voertuig> rijbaan = new List<Voertuig>();
    public Snelweg()
    {
        this.Text = "SnelwegC";
        this.ClientSize = new Size(1800, 80);
        this.Paint += this.tekenSnelweg;
        this.maakBeginSituatie();
    }
    private void maakBeginSituatie()
    {
        for (int t = 0; t < 15; t++)
            if (t%3 != 0)
                this.rijbaan.Add(new PersonenAuto());
            else if (t%6 == 0)
                this.rijbaan.Add(new Vrachtwagen());
            else this.rijbaan.Add(new Combinatie());
    }
    public void tekenSnelweg(object o, PaintEventArgs pea)
    {
        int t = 0;
        foreach (Voertuig voertuig in this.rijbaan)
        {
            voertuig.Teken(pea.Graphics, t*120, 60);
            t++;
        }
    }
    static void Main()
    {
        Application.Run(new Snelweg());
    }
}