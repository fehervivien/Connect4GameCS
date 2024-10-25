using System;

public class Game
{
    private GameBoard board;
    private Player player1;
    private Player player2;

    public Game()
    {
        board = new GameBoard();
    }

    public void InitializeGame()
    {
        Console.Write("Add meg az 1. játékos nevét: ");
        string player1Name = Console.ReadLine();
        player1 = new Player(player1Name, 'S');

        player2 = new ComputerPlayer("Gép", 'P');
    }

    public void StartGame()
    {
        bool isGameOver = false;
        Player currentPlayer = player1;

        while (!isGameOver)
        {
            board.DisplayBoard();
            int column = currentPlayer.GetMove();

            if (board.DropPiece(column, currentPlayer.Symbol))
            {
                if (board.CheckWinner(currentPlayer.Symbol))
                {
                    board.DisplayBoard();
                    Console.WriteLine($"{currentPlayer.Name} nyert!");
                    isGameOver = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }
            }
        }
    }

    public void SaveGame(string filePath)
    {
        board.SaveBoard(filePath);
        Console.WriteLine("A játék állapota elmentve.");
    }

    public void LoadGame(string filePath)
    {
        board.LoadBoard(filePath);
        Console.WriteLine("A játék állapota betöltve.");
    }
}
