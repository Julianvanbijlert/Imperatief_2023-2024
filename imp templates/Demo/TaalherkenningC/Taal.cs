using System;
using System.Drawing;
using System.Windows.Forms;

public class Taal : Form
{
    const int aantal = 10;
    TextBox   invoer;
    Label     uitvoer;
    TextBox[] taal;
    Label  [] score;
    TextBox[] url;
    TableLayoutPanel alles;

    void klik(object o, EventArgs ea)
    {
        RelTurfTab onbekend = new RelTurfTab();
        onbekend.Turf(invoer.Text);

        double kleinste = 1.0;
        string antwoord = "onbekend";
        for (int t = 0; t < aantal; t++)
        {
            string naam = url[t].Text;
            if (naam != "")
            {
                RelTurfTab voorbeeld = new RelTurfTab();
                try
                {
                    voorbeeld.Lees(naam);
                    double verschil = onbekend.Verschil(voorbeeld);
                    score[t].Text = ((int)(10000 * verschil)).ToString();

                    if (verschil < kleinste)
                    {
                        kleinste = verschil;
                        antwoord = taal[t].Text;
                    }
                }
                catch (Exception)
                {
                    this.score[t].Text = "???";
                    Console.WriteLine(ea.ToString());
                }
            }
        }
        uitvoer.Text = antwoord;
    }
    void vergroot(object o, EventArgs ea)
    {
        alles.Size = this.ClientSize;
    }

    public Taal(string[] startwaarde)
    {
        this.Text = "Taalherkenning";
        this.Size = new Size(800, 300);

        this.            alles  = new TableLayoutPanel(); this. Controls.Add(alles);
        TableLayoutPanel paneel = new TableLayoutPanel(); alles.Controls.Add(paneel); 
        TableLayoutPanel talen  = new TableLayoutPanel(); alles.Controls.Add(talen);

        invoer = new TextBox(); paneel.Controls.Add(invoer); 
        invoer.Font = new Font("Tahoma", 14); invoer.Multiline = true;
        Button knop = new Button(); paneel.Controls.Add(knop); 
        knop.Font = new Font("Tahoma", 10); knop.Text = "Herken taal";
        uitvoer = new Label(); paneel.Controls.Add(uitvoer);
        uitvoer.Text = "Hallo";
        uitvoer.Dock = DockStyle.Fill;
        uitvoer.Font = new Font("Tahoma", 14);

        taal  = new TextBox[aantal];
        url   = new TextBox[aantal];
        score = new Label  [aantal];
        for (int t = 0; t < aantal; t++)
        {
            taal[t]  = new TextBox(); talen.Controls.Add(taal[t]);  
            score[t] = new Label();   talen.Controls.Add(score[t]); 
            url[t]   = new TextBox(); talen.Controls.Add(url[t]);   
            score[t].TextAlign = ContentAlignment.MiddleRight;
            taal[t].Dock = score[t].Dock = url[t].Dock = DockStyle.Fill;
            if (t < startwaarde.Length / 2)
            {
                taal[t].Text = startwaarde[2 * t];
                url[t].Text  = startwaarde[2 * t + 1];
            }
        }
        knop.Click  += this.klik;
        this.Resize += vergroot;
        this.vergroot(null, null);  // doe alvast een keer

        // en nog wat regels om de kolombreedte van de TableLayoutPanels te zetten:
        alles .ColumnCount = 2;
        paneel.ColumnCount = 2; paneel.SetColumnSpan(invoer, 2);
        talen .ColumnCount = 3;
        invoer.Dock = DockStyle.Fill; knop  .Dock = DockStyle.Fill;
        talen .Dock = DockStyle.Fill; paneel.Dock = DockStyle.Fill;
        talen .ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        talen .ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
        talen .ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
        paneel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        paneel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
        paneel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
        paneel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
        alles .ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        alles .ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
    }
}