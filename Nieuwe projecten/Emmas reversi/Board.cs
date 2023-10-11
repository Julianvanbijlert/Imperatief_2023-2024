public class Board
{
    //Membervariabele of the board
    public int Lengte = 8;
    public int[,] Grid;

    private int Count_P1 = 2;
    private int Count_P2 = 2;


    //constructor Board 
    public Board(int lengte)
    {
        Lengte = lengte;

        //remember a board is from 0 to lengte - 1
        Grid = new int[lengte, lengte];
        FillGrid(/*Grid, lengte*/);
    }

    //make startposition of the grid
    private void FillGrid(/*int[,] grid, int l*/)
    {
        //Player one is 1 and Player 2 is 2
        Grid[Lengte / 2, Lengte / 2] = 1;
        Grid[Lengte / 2, Lengte / 2 - 1] = 2;
        Grid[Lengte / 2 - 1, Lengte / 2] = 2;
        Grid[Lengte / 2 - 1, Lengte / 2 - 1] = 1;

        Grid[Lengte-1, Lengte-1] = 1;
    }

    //function that colors in a place on the grid
    public void FillPlace(int x, int y, int p)
    {
        Grid[x, y] = p;
    }

    //function that checks if legal move
        //Must incapsulate other color and only other color
        //Must be in board
        //Must be empty square

    //function that checks all the squares next to it


    //function that finds all legal moves


    //Function that switches player turn


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



}



