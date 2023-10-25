using System;
using System.Drawing;
using System.Windows.Forms;
public class TekstEditor : Form
{
    public TekstEditor()
    {
        MenuStrip menuStrip;
        menuStrip = new MenuStrip();
        ToolStripDropDownItem menu;
        menu = new ToolStripMenuItem("File");
        menu.DropDownItems.Add("Nieuw", null, nieuw);
        menu.DropDownItems.Add("Open...", null, open);
        menu.DropDownItems.Add("Exit", null, afsluiten);
        menuStrip.Items.Add(menu);
        Controls.Add(menuStrip);

        Text = "Tekst Editor";
        ClientSize = new Size(600, 400);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip;
    }

    private void nieuw(object sender, EventArgs e)
    {
        Tekst t = new Tekst();
        t.MdiParent = this;
        t.Show();
    }
    private void open(object sender, EventArgs e)
    {
        OpenFileDialog dialoog = new OpenFileDialog();
        dialoog.Filter = "Tekstfiles|*.txt|Alle files|*.*";
        dialoog.Title = "Tekst openen...";
        if (dialoog.ShowDialog() == DialogResult.OK)
        {
            Tekst t = new Tekst();
            t.MdiParent = this;
            t.LeesVanFile(dialoog.FileName);
            t.Show();
        }
    }
    private void afsluiten(object sender, EventArgs e)
    {
        Close();
    }
}