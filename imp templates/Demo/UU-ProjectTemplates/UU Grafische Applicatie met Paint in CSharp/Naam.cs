using System.Drawing;
using System.Windows.Forms;

class $projectname$ : Form
{
    public $projectname$()
    {
        this.Text = "$projectname$";
        this.BackColor = Color.LightYellow;
        this.ClientSize = new Size(200, 100);
        this.Paint += this.Teken;
    }
    public void Teken(object o, PaintEventArgs pea)
    {
        Graphics gr = pea.Graphics;
        gr.FillEllipse(Brushes.Blue, 20, 20, 50, 50);
    }
    public static void Main()
    {
        Application.Run(new $projectname$());
    }
}
