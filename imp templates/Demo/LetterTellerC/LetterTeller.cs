using System;
using System.Drawing;
using System.Windows.Forms;

public class LetterTeller : Form
{
    private TextBox invoer;
    private Label uitvoer;
    private StaafDiagram diagram;

    public LetterTeller()
    {
        Text = "LetterTellerC";
        ClientSize = new Size(320, 576);
        invoer  = new TextBox();      Controls.Add(invoer); invoer.Multiline = true;
        uitvoer = new Label();        Controls.Add(uitvoer);
        diagram = new StaafDiagram(); Controls.Add(diagram);
        invoer. Location = new Point(10,  10); invoer .Size = new Size(300, 100);
        uitvoer.Location = new Point(10, 120); uitvoer.Size = new Size( 70, 448);
        diagram.Location = new Point(90, 120); diagram.Size = new Size(210, 416);
        invoer.TextChanged += berekenAntwoord;
    }

    void berekenAntwoord(object o, EventArgs ea)
    {
        TurfTab tabel = new TurfTab();
        tabel.Turf(invoer.Text);
        uitvoer.Text = tabel.ToString();
        diagram.Waardes = tabel.Waardes;
    }
}