using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoryGame
{
    class Board
    {
        public List<List<Card>> Cards;
        public int X1, Y1, X2, Y2; //chosen coordinates
        public Dictionary<ValueTuple<int, int>, ValueTuple<int, int>> solution;
        public int size;

        public Board()
        {
            Random rng = new Random();

            //create table to randomise value
            List<string> deck = new List<string>()
            { "a", "b", "c", "d", "e", "f", "g", "h", "a", "b", "c", "d", "e", "f", "g", "h"};
            size = 4;

            //create solution
            solution = new Dictionary<ValueTuple<int, int>, ValueTuple<int, int>>();

            Cards = new List<List<Card>>();

            for (int y = 0; y < size; y++) //row
            {
                Cards.Add(new List<Card>());

                for (int x = 0; x < size; x++) //value in col
                {
                    int tmp = rng.Next(0, deck.Count-1); //losuje wartość id z istniejących w decku
                    Cards[y].Add(new Card(deck[tmp], x, y)); //add card with this value
                    deck.RemoveAt(tmp); //remove used symbol
                }
            }

            //fill solution
            for (int y = 0; y < size; y++) //row
            {
                for (int x = 0; x < size; x++) //value in col
                {
                    
                }
            }

        }

        public void ShowBoard()
        {
            Console.Clear();
            for (int y = 0; y < size; y++) //row
            {
                for (int x = 0; x < size; x++) //value in col
                {
                    Card tmp = Cards[y][x];
                    if (tmp.hasBeenDiscovered)
                        Console.Write(tmp.Value);
                    else
                        Console.Write("?");
                }
                Console.WriteLine();
            }
        }

        public Card PickCard()
        {
            Console.Write("Podaj X karty: ");
            int X = ReadInt();
            Console.WriteLine();

            Console.Write("Podaj Y karty: ");
            int Y = ReadInt();
            Console.WriteLine();

            Card tmp = Cards[Y][X];

            Console.WriteLine("Pierwsza karta to " + X + ":" + Y + " - " + tmp.Value);
            Console.WriteLine();

            return tmp;
        }

        public int ReadInt()
        {
            string tmp = Console.ReadLine();
            int ret;
            if (Regex.IsMatch(tmp, @"^\d+$"))
                ret = Int32.Parse(tmp);
            else
            {
                Console.WriteLine("Proszę podaj wartość liczbową");
                ret = ReadInt();
            }
            return ret;
        }
    }
}
