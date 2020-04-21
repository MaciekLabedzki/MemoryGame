using System;

//It is simple presentation that shows how dictionaries works

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.ShowBoard();
            Console.ReadKey();
        }
    }
}
