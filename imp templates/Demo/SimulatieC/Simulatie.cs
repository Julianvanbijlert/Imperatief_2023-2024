using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

class Simulatie : Form
{
    private Ruimte r1, r2, r3;
    private Button stap, auto;
    private bool beweegt = false;

    public Simulatie()
    { 
        ClientSize = new Size(406, 280);  Text = "SimulatieC";
        r1   = new Ruimte(new Size( 80, 150)); Controls.Add(r1);
        r2   = new Ruimte(new Size(296, 120)); Controls.Add(r2);
        r3   = new Ruimte(new Size(386, 100)); Controls.Add(r3);
        stap = new Button(); Controls.Add(stap);
        auto = new Button(); Controls.Add(auto);
        r1.Location   = new Point( 10, 10);
        r2.Location   = new Point(100, 10);
        r3.Location   = new Point( 10,170);
        stap.Location = new Point(100,140); stap.Text = "Stap";
        auto.Location = new Point(200,140); auto.Text = "Start";
        
        stap.Click += stapKlik;
        auto.Click += autoKlik;
    }
    private void stapKlik(object o, EventArgs ea)
    {
        r1.DoeStap();
        r2.DoeStap();
        r3.DoeStap();
    }
    private void autoKlik(object o, EventArgs ea)
    {
        if (beweegt)
        {
            beweegt = false;     // laat de animatie uitdoven
            auto.Text = "Start"; // sta weer klaar voor een nieuwe start
        }
        else
        {
            beweegt = true;
            auto.Text = "Stop";
            Thread animatie = new Thread(filmpje);
            animatie.Start();
        }
    }
    private void filmpje()
    {
        while (beweegt)
        {
            stapKlik(this, null);  // doe wat zou gebeuren bij indrukken stap-knop
            Thread.Sleep(50);
        }
    }
}