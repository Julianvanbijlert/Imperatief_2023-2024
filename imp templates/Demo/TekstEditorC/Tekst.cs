using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
public class Tekst : Form
{
    TextBox invoer;
    Label status;

    public Tekst()
    {
        MenuStrip menuStrip = new MenuStrip();
        invoer = new TextBox();
        status = new Label();

        ToolStripDropDownItem menu = new ToolStripMenuItem("File");
        menu.MergeAction = MergeAction.MatchOnly;
        menuStrip.Items.Add(menu);
        menu.DropDownItems.Add("Opslaan", null, opslaan);
        menu.DropDownItems.Add("Opslaan &als...", null, opslaanAls);
        menu.DropDownItems.Add("Sluiten", null, sluiten);
        menu = new ToolStripMenuItem("Zoek");
        menu.DropDownItems.Add("Zoek", null, zoek);
        menu.DropDownItems.Add("Vervang", null, vervang);
        menuStrip.Items.Add(menu);
        menuStrip.Visible = false;
        Controls.Add(menuStrip);

        invoer.Multiline = true;
        invoer.WordWrap = false;
        invoer.ScrollBars = ScrollBars.Both;
        invoer.Font = new Font("Courier New", 12);
        invoer.TextChanged += verander;
        Controls.Add(invoer);
        Controls.Add(status);

        ClientSize = new Size(500, 300);
        Resize += vergroot;
        vergroot(null, null);
    }
    private void vergroot(object o, EventArgs ea)
    {
        invoer.Location = new Point(10, 10);
        invoer.Size = ClientSize - new Size(20, 30);
        status.Location = new Point(10, ClientSize.Height - 15);
    }
    private void verander(object o, EventArgs ea)
    {
        status.Text = invoer.Text.Length.ToString() + " karakters";
    }
    private void sluiten(object sender, EventArgs e)
    {
        Close();
    }
    private void zoekOfVervang(bool ookVervangen)
    {
        ZoekDialoog dialoog = new ZoekDialoog(ookVervangen);
        if (dialoog.ShowDialog(this) == DialogResult.OK)
        {
            string alles = invoer.Text;
            string zoek = dialoog.ZoekText.Text;
            int pos = alles.IndexOf(zoek);
            if (pos >= 0)
            {
                if (ookVervangen)
                {
                    string vervang = dialoog.VervangText.Text;
                    invoer.Text = alles.Replace(zoek, vervang);
                    zoek = vervang;
                }
                invoer.Select(pos, zoek.Length);
            }
        }
    }
    private void zoek(object o, EventArgs ea)
    {
        zoekOfVervang(false);
    }
    private void vervang(object o, EventArgs ea)
    {
        zoekOfVervang(true);
    }
    private void opslaan(object o, EventArgs ea)
    {
        if (Text == "")
            opslaanAls(o, ea);
        else schrijfNaarFile();
    }
    private void opslaanAls(object o, EventArgs ea)
    {
        SaveFileDialog dialoog = new SaveFileDialog();
        dialoog.Filter = "Tekstfiles|*.txt|Alle files|*.*";
        dialoog.Title = "Tekst opslaan als...";
        if (dialoog.ShowDialog() == DialogResult.OK)
        {
            Text = dialoog.FileName;
            schrijfNaarFile();
        }
    }
    private void schrijfNaarFile()
    {
        StreamWriter writer = new StreamWriter(Text);
        writer.Write(invoer.Text);
        writer.Close();
    }
    public void LeesVanFile(string naam)
    {
        StreamReader reader = new StreamReader(naam);
        invoer.Text = reader.ReadToEnd();
        reader.Close();
        Text = naam;
    }
}