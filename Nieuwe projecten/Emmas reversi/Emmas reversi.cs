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




//------------------------------------------------Scherm maken----------------------------------------------------

//
Form scherm = MakeForm(220, 220, "Emma's Reversi");
// met een Bitmap kun je een plaatje opslaan in het geheugen
Bitmap plaatje = new Bitmap(200, 200);

// je kunt de losse pixels van het plaatje manipuleren
plaatje.SetPixel(10, 10, Color.Red);

// maar om complexere figuren te tekenen heb je een Graphics nodig
Graphics tekenaar = Graphics.FromImage(plaatje);
tekenaar.FillEllipse(Brushes.Blue, 30, 40, 100, 50);

// een Label kan ook gebruikt worden om een Bitmap te laten zien
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(10, 10);
afbeelding.Size = new Size(200, 200);
afbeelding.BackColor = Color.White;
afbeelding.Image = plaatje;

Button Forms = MakeButton(300, 300, "MaakForm");
Forms.Click += NieuweForm;




//---------------------------------------------------Maak Button Functies--------------------------------------------

//we zijn van plan meerdere labels te maken met veel dezelfde attributen dus dan hebben wij een functie gemaakt om deze aan te maken.
Label MakeLabel(int x, int y, string s)
{
    Label L = new Label();
    L.Size = new Size(80, 20);
    L.Location = new Point(x, y);
    L.BackColor = Color.Aquamarine;
    scherm.Controls.Add(L);
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
    scherm.Controls.Add(T);
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

    scherm.Controls.Add(b);
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
    scherm.Controls.Add(b);
    return b;
}

Form MakeForm(int breedte, int hoogte, string str)
{
    Form s = new Form();
    s.Text = str;
    s.BackColor = Color.LightYellow;
    s.ClientSize = new Size(breedte, hoogte);

    return s;
}

//--------------------------------------------------EventHandlers----------------------------------------------------------

void NieuweForm(object o, EventArgs ea)
{
    Form scherm2 = MakeForm(350, 350, "kfjlasd");
    
}









Application.Run(scherm);