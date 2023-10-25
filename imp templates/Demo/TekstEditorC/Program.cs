using System;
using System.Windows.Forms;

class Program
{
    [STAThreadAttribute]
    static void Main()
    {
        Application.Run(new TekstEditor());
    }
}