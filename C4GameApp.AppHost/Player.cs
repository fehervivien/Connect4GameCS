using System;

public class Player
{
    public string Name { get; private set; }
    public char Symbol { get; private set; }

    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public int GetMove()
    {
        Console.Write($"{Name}, válassz egy oszlopot (0-6): ");
        int column;
        while (!int.TryParse(Console.ReadLine(), out column) || column < 0 || column > 6)
        {
            Console.WriteLine("Érvénytelen oszlop, próbáld újra!");
        }
        return column;
    }
}
