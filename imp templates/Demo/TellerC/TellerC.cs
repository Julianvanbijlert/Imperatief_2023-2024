using System.Drawing;
using System.Windows.Forms;

Application.Run(new Teller());

public class Teller : Form
{
    Button knop;
    int hoeveel;

    public Teller()
    {
        Text       = "TellerC";
        ClientSize = new Size(120, 50);
        BackColor  = Color.LightYellow;

        hoeveel = 0;

        knop = new Button(); Controls.Add(knop);
        knop.Location  = new Point(10, 10); 
        knop.Size      = new Size(100, 30);
        knop.Text      = "klik hier!";
        knop.BackColor = Color.LightGreen;
        knop.Click    += geklikt;
    }

    private void geklikt(object sender, System.EventArgs e)
    {
        hoeveel += 1;
        knop.Text = $"{hoeveel} keer";
    }
}