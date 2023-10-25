using System;
using System.Drawing;
using System.Windows.Forms;
public class ZoekDialoog : Form
{
    public TextBox ZoekText, VervangText;
    Button ok, cancel;
    Label zoekLabel, vervangLabel;

    public ZoekDialoog(bool ookVervang)
    {
        ClientSize = new Size(220, 120);
        zoekLabel  = new Label();   Controls.Add(zoekLabel);
        ZoekText   = new TextBox(); Controls.Add(ZoekText);
        ok         = new Button();  Controls.Add(ok);
        cancel     = new Button();  Controls.Add(cancel);
        zoekLabel.Location = new Point(10, 10); zoekLabel.AutoSize = true; 
        ZoekText. Location = new Point(70, 10); ZoekText.Size = new Size(130, 20);
        ok.Location        = new Point(50, 80); ok.Text = "OK";
        cancel.Location    = new Point(140, 80); cancel.Text = "Cancel";
        zoekLabel.Text = "Zoek:";
        if (ookVervang)
        {
            vervangLabel = new Label(); Controls.Add(vervangLabel);
            VervangText  = new TextBox(); Controls.Add(VervangText);
            VervangText.Location  = new Point(70, 40); VervangText.Size = new Size(130, 20);
            vervangLabel.Location = new Point(10, 40); vervangLabel.AutoSize = true;
            vervangLabel.Text = "Vervang:";
        }
        AcceptButton = ok;
        CancelButton = cancel;
        ok.Click += ok_Click;
    }
    void ok_Click(object o, EventArgs ea)
    {
        DialogResult = DialogResult.OK;
        Close();
    }
}