using System.Drawing;

class Deeltje
{
    private int x, y, dx, dy;
    private Brush brush;

    public Deeltje(Brush b0, int x0, int y0, int dx0, int dy0)
    {
        brush = b0;
        x = x0;
        y = y0;
        dx = dx0;
        dy = dy0;
    }
    public void DoeStap(Size hok)
    {
        x += dx;
        y += dy;

        if (x < 0)
        {
            x  = -x;
            dx = -dx;
        }
        else if (x >= hok.Width)
        {
            x  = 2 * hok.Width - x;
            dx = -dx;
        }
        if (y < 0)
        {
            y  = -y;
            dy = -dy;
        }
        else if (y >= hok.Height)
        {
            y  = 2 * hok.Height - y;
            dy = -dy;
        }
    }

    public void TekenDeeltje(Graphics gr)
    {
        gr.FillEllipse(brush, x - 4, y - 4, 9, 9);
    }
}