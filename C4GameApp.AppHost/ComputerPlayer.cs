using System;

public class ComputerPlayer : Player
{
    private static Random rnd = new Random();

    public ComputerPlayer(string name, char symbol) : base(name, symbol) {}

    public int GetMove()
    {
        int column = rnd.Next(0, 7); // Véletlen oszlop
        Console.WriteLine($"{Name} gép választott oszlop: {column}");
        return column;
    }
}
