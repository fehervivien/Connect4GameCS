using System;
using System.IO;

public class GameBoard
{
    private const int Rows = 6;
    private const int Columns = 7;
    private char[,] board = new char[Rows, Columns];

    public GameBoard()
    {
        InitializeBoard();
    }

    public void InitializeBoard()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                board[i, j] = '.';
            }
        }
    }

    public void DisplayBoard()
    {
        Console.WriteLine("A B C D E F G");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public bool DropPiece(int column, char player)
    {
        if (column < 0 || column >= Columns)
        {
            Console.WriteLine("Érvénytelen oszlop!");
            return false;
        }

        for (int row = Rows - 1; row >= 0; row--)
        {
            if (board[row, column] == '.')
            {
                board[row, column] = player;
                return true;
            }
        }

        Console.WriteLine("Ez az oszlop tele van!");
        return false;
    }

    public bool CheckWinner(char player)
    {
        // Ellenőrzés vízszintesen
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns - 3; col++)
            {
                if (board[row, col] == player && board[row, col + 1] == player && 
                    board[row, col + 2] == player && board[row, col + 3] == player)
                    return true;
            }
        }

        // Ellenőrzés függőlegesen
        for (int row = 0; row < Rows - 3; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                if (board[row, col] == player && board[row + 1, col] == player &&
                    board[row + 2, col] == player && board[row + 3, col] == player)
                    return true;
            }
        }

        // Ellenőrzés átlósan (balról jobbra)
        for (int row = 0; row < Rows - 3; row++)
        {
            for (int col = 0; col < Columns - 3; col++)
            {
                if (board[row, col] == player && board[row + 1, col + 1] == player &&
                    board[row + 2, col + 2] == player && board[row + 3, col + 3] == player)
                    return true;
            }
        }

        // Ellenőrzés átlósan (jobbról balra)
        for (int row = 0; row < Rows - 3; row++)
        {
            for (int col = 3; col < Columns; col++)
            {
                if (board[row, col] == player && board[row + 1, col - 1] == player &&
                    board[row + 2, col - 2] == player && board[row + 3, col - 3] == player)
                    return true;
            }
        }

        return false;
    }

    public void SaveBoard(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    sw.Write(board[row, col]);
                }
                sw.WriteLine();
            }
        }
    }

    public void LoadBoard(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            for (int row = 0; row < Rows; row++)
            {
                string line = sr.ReadLine();
                for (int col = 0; col < Columns; col++)
                {
                    board[row, col] = line[col];
                }
            }
        }
    }
}
