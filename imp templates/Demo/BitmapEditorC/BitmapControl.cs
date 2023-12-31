﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

public class BitmapControl : UserControl
{
    private Bitmap model;

    public BitmapControl()
    {
        model = new Bitmap(20, 20);
        Paint += teken;
        Resize += vergroot;
        MouseClick += klik;
        MouseMove += beweeg;
    }
    public int Diameter
    {
        get
        {
            Size s = ClientSize;
            return Math.Min(s.Width / model.Breedte, s.Height / model.Hoogte);
        }
    }
    private void teken(object sender, PaintEventArgs e)
    {
        int w = model.Breedte;
        int h = model.Hoogte;
        int d = Diameter;
        for (int y = 0; y <= h; y++)
            e.Graphics.DrawLine(Pens.Blue, 0, y * d, w * d, y * d);
        for (int x = 0; x <= w; x++)
            e.Graphics.DrawLine(Pens.Blue, x * d, 0, x * d, h * d);
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                Brush b;
                if (model.vraagKleur(x, y))
                    b = Brushes.Red;
                else b = Brushes.White;
                e.Graphics.FillRectangle(b, x * d + 1, y * d + 1, d - 1, d - 1);
            }
        }
        int rx = w * d + 1;
        int ry = h * d + 1;

        Brush bg = new SolidBrush(BackColor);
        e.Graphics.FillRectangle(bg, rx, 0, Width - rx, Height);
        e.Graphics.FillRectangle(bg, 0, ry, Width, Height - ry);
    }
    override protected void OnPaintBackground(PaintEventArgs e)
    {
    }
    private void vergroot(object sender, EventArgs e)
    {
        Invalidate();
    }
    private void klik(object sender, MouseEventArgs mea)
    {
        int d = Diameter;
        int x = mea.X / d;
        int y = mea.Y / d;
        if (x >= 0 && x < model.Breedte && y >= 0 && y < model.Hoogte)
            model.veranderKleur(x, y, mea.Button == MouseButtons.Left);
        Invalidate();
    }
    private void beweeg(object sender, MouseEventArgs mea)
    {
        if (mea.Button == MouseButtons.Left || mea.Button == MouseButtons.Right)
            klik(sender, mea);
    }
    public void uitvoeren(object sender, EventArgs e)
    {
        switch (sender.ToString())
        {
            case "Clear": model.Clear(); break;
            case "Invert": model.Invert(); break;
            case "Bold": model.Bold(); break;
            case "Outline": model.Outline(); break;
            case "Left": model.Left(); break;
            case "Right": model.Right(); break;
            case "Up": model.Up(); break;
            case "Down": model.Down(); break;
            case "Step": model.Life(); break;
        }
        Invalidate();
    }

    private Thread animatie;

    public void starten(object sender, EventArgs e)
    {
        animatie = new Thread(animatieFunctie);
        animatie.Start();
    }
    public void stoppen(object sender, EventArgs e)
    {
        animatie = null;
    }
    private void animatieFunctie()
    {
        while (animatie != null)
        {
            model.Life();
            Invalidate();
            Thread.Sleep(50);
        }
    }
}