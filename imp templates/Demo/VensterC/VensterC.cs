using System.Windows.Forms;
using System.Drawing;

Form scherm = new Form();
scherm.Text       = "Hallo";
scherm.BackColor  = Color.Yellow;
scherm.ClientSize = new Size(200, 100);


Application.Run(scherm);