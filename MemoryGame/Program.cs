using System;

//It is simple presentation that shows how dictionaries works

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            
            Console.WriteLine("By zagrać naciśnij dowolny klawisz...");
            Console.ReadKey(false);
            while (board.WinningConditions())
            {
                board.ShowBoard();
                board.PickPair();
            }
            Console.WriteLine("Gratulacje, wygrałeś!");
            Console.ReadKey(false);
        }
    }
}
