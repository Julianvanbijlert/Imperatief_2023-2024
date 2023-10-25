using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

public class ReversiGame : Form
{

    //met een Bitmap kun je een plaatje opslaan in het geheugen
    Bitmap plaatje;
    Graphics tekenaar;
    Label afbeelding;
    Board bord;

    //players
    Brush player1_color;
    Brush player2_color;
    Brush help_color;
    Pen grid_color;

    int bitmapGrootte = 800;
    int t;
    int lengte = 8;
    bool help = false;
    bool bot = false;

    //------------------------------------------------Scherm maken----------------------------------------------------
    public ReversiGame()
    {
        ClientSize = new Size(800, 800);
        Text = "Emma's Reversi";
        bitmapGrootte = 700;
        plaatje = new Bitmap(bitmapGrootte, bitmapGrootte);
        tekenaar = Graphics.FromImage(plaatje);

        // een Label kan ook gebruikt worden om een Bitmap te laten zien
        afbeelding = new Label();
        afbeelding.Location = new Point(10, 10);
        afbeelding.Size = new Size(bitmapGrootte, bitmapGrootte);
        afbeelding.BackColor = Color.White;
        afbeelding.Image = plaatje;
        Controls.Add(afbeelding);

        //brushes
        player1_color = new SolidBrush(Color.Red);
        player2_color = new SolidBrush(Color.Blue);
        help_color = new SolidBrush(Color.LightGray);
        grid_color = new Pen(Color.Black, 1);

        //make all buttons and labels
        MakeButLab();
        //Forms.Click += NieuweForm;

        bord = new Board(lengte);
        t = bitmapGrootte / lengte;

        TekenBord();
        afbeelding.MouseClick += BitmapClick;


    }
    //--------------------------------------------------Reversi Functies--------------------------------------------------------
    private void TekenBord()
    {
        bord.RemovePrev();
        bord.CheckZetten(bord.CurrentPlayer);
        tekenaar.Clear(Color.White);
        for (int x = 0; x < lengte; x++)
        {
            tekenaar.DrawLine(grid_color, x * t, bitmapGrootte, x * t, 0);
            tekenaar.DrawLine(grid_color, bitmapGrootte, x * t, 0, x * t);
            for (int y = 0; y < lengte; y++)
            {
                int i = bord.Grid[x, y];
                if (i == 1)
                {
                    tekenaar.FillEllipse(player1_color, x * t, y * t, t, t);
                }
                if (i == 2)
                {
                    tekenaar.FillEllipse(player2_color, x * t, y * t, t, t);
                }
                if (help && i == 3) //vieze if statement, liever weg maar weet niet hoe
                {
                    tekenaar.FillEllipse(help_color, x * t, y * t, t, t);
                    
                }

            }
            
        }
        tekenaar.DrawLine(grid_color, bitmapGrootte - 1, bitmapGrootte - 1, bitmapGrootte - 1, 0);
        tekenaar.DrawLine(grid_color, bitmapGrootte - 1, bitmapGrootte - 1, 0, bitmapGrootte - 1);
        afbeelding.Invalidate();
    }

    
    public void Reset(int i)
    {
        lengte = i;
        bord = new Board(lengte);
        t = bitmapGrootte / lengte;
        TekenBord();
    }

    

    //--------------------------------------------------EventHandlers----------------------------------------------------------

    //
    public void BitmapClick(object o, MouseEventArgs mea)
    {
        int x = mea.X / t;
        int y = mea.Y / t;

        if(bord.GetWaarde(x, y) == 3)
        {
            bord.DoMove(x, y);

            //if the bot is enabled than the second player will be skipped and the first player
            if (bot)
            {
                bord.BotFunction();
            }

            TekenBord();
        }
    }

    public void Button4(object o, EventArgs ea)
    {
        Reset(4);
    }

    public void Button6(object o, EventArgs ea)
    {
        Reset(6);
    }

    public void Button8(object o, EventArgs ea)
    {
        Reset(8);
    }
    public void Button10(object o, EventArgs ea)
    {
        Reset(10);
    }

    public void helper(object o, EventArgs ea)
    {
        switch(help)
        {
            case true: help = false; break;
                default: help = true; break;
        }
        TekenBord();
    }



    //---------------------------------------------------Maak Button Functies--------------------------------------------


    //Function that creates all the buttons on screen
    void MakeButLab()
    {
        Button size4 = MakeButton(bitmapGrootte + 15, 10, "4x4");
        size4.Click += Button4;

        Button size6 = MakeButton(bitmapGrootte + 15, 40, "6x6");
        size6.Click += Button6;

        Button size8 = MakeButton(bitmapGrootte + 15, 70, "8x8");
        size8.Click += Button8;

        Button size10 = MakeButton(bitmapGrootte + 15, 100, "10x10");
        size10.Click += Button10;

        Button help = MakeButton(bitmapGrootte + 15, bitmapGrootte - 10, "help");
        help.Click += helper;
    }
    //we zijn van plan meerdere labels te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
    Label MakeLabel(int x, int y, string s)
    {
        Label L = new Label();
        L.Size = new Size(80, 20);
        L.Location = new Point(x, y);
        L.BackColor = Color.Aquamarine;
        Controls.Add(L);
        L.Text = s;
        return L;
    }

    //we zijn van plan meerdere Textbox te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
    TextBox MakeTextBox(int x, int y, string s)
    {
        TextBox T = new TextBox();
        T.Size = new Size(80, 20);
        T.Location = new Point(x, y);
        T.BackColor = Color.White;
        Controls.Add(T);
        T.Text = s;
        return T;
    }

    //we zijn van plan meerdere buttons te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
    Button MakeButton(int x, int y, string s)
    {
        Button b = new Button();
        b.Size = new Size(80, 20);
        b.Location = new Point(x, y);
        b.BackColor = Color.AliceBlue;
        b.Text = s;

        //kleurtjes veranderen als je eroverheen gaat
        b.MouseMove += (sender, e) =>
        {
            b.BackColor = Color.LightGray;
        };
        b.MouseLeave += (sender, e) => {
            b.BackColor = Color.AliceBlue;
        };

        Controls.Add(b);
        return b;
    }

    //we zijn van plan meerdere checkboxes te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
    CheckBox MakeCheckBox(int x, int y, Color c)
    {
        CheckBox b = new CheckBox();
        b.Location = new Point(x, y);
        b.Checked = false;
        b.BackColor = c;
        // b.CheckedChanged += CheckBoxTick;
        //checkBoxes.Add(b);
        Controls.Add(b);
        return b;
    }

    //Not used but wanted to make a menu screen
    Form MakeForm(int breedte, int hoogte, string str)
    {
        Form s = new Form();
        s.Text = str;
        s.BackColor = Color.LightYellow;
        s.ClientSize = new Size(breedte, hoogte);

        return s;
    }



}
public class Program
{

    static void Main()
    {
        ReversiGame Screen = new ReversiGame();
        Application.Run(Screen);

    }



}