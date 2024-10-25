using System;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.InitializeGame();
        game.StartGame();

        Console.Write("Szeretnéd elmenteni a játékot? (i/n): ");
        if (Console.ReadLine().ToLower() == "i")
        {
            game.SaveGame("game_save.txt");
        }

        Console.Write("Szeretnéd betölteni a korábbi játékot? (i/n): ");
        if (Console.ReadLine().ToLower() == "i")
        {
            game.LoadGame("game_save.txt");
        }
    }
}
