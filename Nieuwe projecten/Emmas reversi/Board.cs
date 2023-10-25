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
using System.Collections.Generic;

public class Board
{
    //Membervariabele of the board
    public int Lengte = 8;
    public int[,] Grid;

    public int CurrentPlayer = 1;

    private int Count_P1 = 2;
    private int Count_P2 = 2;

    public List<(int, int)> LegalMoves;


    //constructor Board 
    public Board(int lengte)
    {
        Lengte = lengte;

        //remember a board is from 0 to lengte - 1
        Grid = new int[lengte, lengte];
        FillGrid();
    }

    //make startposition of the grid
    private void FillGrid()
    {
        //Player one is 1 and Player 2 is 2
        Grid[Lengte / 2 - 1, Lengte / 2 - 1] = 1;
        Grid[Lengte / 2 - 1, Lengte / 2] = 2;
        Grid[Lengte / 2, Lengte / 2 - 1] = 2;
        Grid[Lengte / 2, Lengte / 2] = 1;
    }

    public void DoMove(int x, int y) 
    {
        FillPlace(x, y, CurrentPlayer);
        Flip(x, y, CurrentPlayer);
        UpdateScore();
        /*
        if(LegalMoves.Count == 0)
        {
            p = SwitchCurrentPlayer(currentPlayer); // wrong
            CheckZetten(currentPlayer);
            if (LegalMoves.Count == 0)
            {

            }
        }
        */
        SwitchCurrentPlayer();
    }

    //
    public void UpdateScore()
    {
        Count_P1 = 0;
        Count_P2 = 0;
        for (int i = 0; i < Lengte; i++)
        {
            for (int j = 0; j < Lengte; j++)
            {
                if (Grid[i, j] == 1)
                {
                    Count_P1 += 1;
                }
                if (Grid[i, j] == 2)
                {
                    Count_P2 += 1;
                }
            }
        }
    }
    //function that colors in a place on the grid
    public void FillPlace(int x, int y, int p)
    {
        try
        {
            Grid[x, y] = p;
        }
        catch (Exception e)
        {
            //we did not do the smaller than because we do not see a situation where that is relevant. As nothing should happen then
            if (x >= Lengte && y >= Lengte)
            {
                Grid[Lengte - 1, Lengte - 1] = p;
            }
            else if (x >= Lengte)
            {
                Grid[Lengte - 1, y] = p;
            }
            else if (y >= Lengte)
            {
                Grid[x, Lengte - 1] = p;
            }
        }

    }

    //function that checks if legal move
    //Must incapsulate other color and only other color
    //Must be in board
    //Must be empty square

    //function that checks all the squares next to it
  

    //function that finds all legal moves
    public void CheckZetten(int p)
    {
        LegalMoves = new List<(int, int)>();
        for (int i = 0; i < Lengte; i++)
        {
            for (int j = 0; j < Lengte; j++)
            {
                if (Grid[i, j] == 0 || Grid[i, j] == 3)
                {
                    Zet(i, j, p);
                }
            }
        }
    }

    public void Zet(int x, int y, int p)
    {
        //all directions 
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int newX = x + i;
                int newY = y + j;
                if (CheckInBoard(newX, newY) && !(i == 0 && j == 0))
                {
                    if (CheckLegal(newX, newY, i, j, p))
                    {
                        Grid[x, y] = 3;
                        LegalMoves.Add((newX, newY));
                    }
                }
            }
        }
    }
    

    public bool CheckInBoard(int x, int y)
    {
        if (x < Lengte && y < Lengte && x >= 0 && y >= 0)
        {
            return true;
        }
        else return false;
    }

    public bool CheckSquareEmpty(int x, int y, int p)
    {
        if (Grid[x, y] == 0 || Grid[x, y] == 3)
        {
            return true;
        }
        else return false;
    }

    public bool CheckLegal(int x, int y, int dx, int dy, int p)
    {
        //dit is al de nieuwe x 
        int x1 = x;
        int y1 = y;
        int otherPlayer;
        if(p == 1) { otherPlayer = 2; } else { otherPlayer = 1; }

        while (Grid[x1, y1] == otherPlayer)
        {
                x1 += dx;
                y1 += dy;

            if(!CheckInBoard(x1, y1))
            {
                return false;
            } 
            
        }
        if (Grid[x1, y1] == p && Grid[x, y] != p)
        {
            return true;
        }
        else return false;
    }

    //a get function 
    public int GetWaarde(int x, int y)
    {
        return Grid[x, y];
    }

    //Function that removes all previous moves
    public void RemovePrev()
        {
            for (int x = 0; x < Lengte; x++)
            {
                for (int y = 0; y < Lengte; y++)
                {

                    if (Grid[x, y] == 3)
                    {
                        Grid[x, y] = 0;
                    }
                }
            }
        }

        // Function that flips the colors
    public void Flip(int x, int y, int CurrentPlayer)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if (CheckInBoard(newX, newY) && !(i == 0 && j == 0))
                    {
                        if (CheckLegal(newX, newY, i, j, CurrentPlayer))
                        {
                            Flipcolor(x, y, i, j, CurrentPlayer);
                        }
                    }
                }
            }
        }

        public void Flipcolor(int x, int y, int dx, int dy, int p)
        {
            int x1 = x + dx;
            int y1 = y + dy;
            int otherPlayer;
            if (p == 1) { otherPlayer = 2; } else { otherPlayer = 1; }

            while (Grid[x1, y1] == otherPlayer)
            {
                Grid[x1, y1] = p;
                x1 += dx;
                y1 += dy;

            }
        }
        //Botfunction
        public void BotFunction()
    {
        (int, int) location = BestMove();
        FillPlace(location.Item1, location.Item2, 2);
    }

    public (int,int) BestMove()
    {
        minmax(5, 1);
        return (0, 0);
    }

    public void minmax(/*Node node,*/ int depth, int player) 
    { 
        if(depth == 0 /*|| node == leaf*/)
        {
           // return value;
        }
        //if(player == 1) { maxplayer(node, depth - 1, 2); }
        //else { minplayer(node, depth - 1, 1);  }
    }
    public void BuildTree()
        {

        }

    public int GoodnessOffMove(int x, int y)
    {
        return 1;
    }

    //Function that skips player if there are no possible moves left for only that player


    //Function that stops game if there are no possible moves left for BOTH players


    //Function that tells who won and if one won 
    int TellWinner()
    {
        if (Count_P1 > Count_P2)
        {
            return 1;
        }
        else if (Count_P1 < Count_P2)
        {
            return 2;
        }
        else return 0;
    }

    //Switches current Player to the other player
    public void SwitchCurrentPlayer()
    {
        switch (CurrentPlayer)
        {
            case 1: CurrentPlayer = 2; break;
            default: CurrentPlayer = 1; break;
        }
    }

}

