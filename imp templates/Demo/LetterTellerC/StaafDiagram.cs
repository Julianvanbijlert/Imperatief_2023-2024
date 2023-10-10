using System.Drawing;
using System.Windows.Forms;
using System.Linq;

public class StaafDiagram : Label
{
    private int[] waardes;

    public StaafDiagram()
    {   Paint += teken;
    }

    public int[] Waardes
    {   set
        {   waardes = value;
            Invalidate();
        }
    }

    private void teken(object o, PaintEventArgs pea)
    {
        Graphics gr = pea.Graphics;
        if (waardes != null)
        {
            int meeste = waardes.Max();
            if (meeste < 10)
                meeste = 10;
            float balkH = (float)this.Height / waardes.Length;
            float balkUnit = (float)this.Width / meeste;

            for (int t = 0; t < waardes.Length; t++)
                gr.FillRectangle(Brushes.Blue, 0, t*balkH, balkUnit*waardes[t], balkH-1);
        }
    }
}