using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoryGame
{
    class Board
    {
        public List<List<Card>> Cards;
        public Card FirstPick, LastPick; //chosen coordinates
        public int size;
        public int Points;

        public Board()
        {
            Random rng = new Random();
            Points = 0;

            //create table to randomise value
            List<string> deck = new List<string>()
            { "a", "b", "c", "d", "e", "f", "g", "h", "a", "b", "c", "d", "e", "f", "g", "h"};
            size = 4;

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

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your points: " + Points);
        }

        public bool WinningConditions()
        {
            if (Points >= (size * size)/2)
                return false;
            else
                return true;
        }

        public void PickPair()
        {
            FirstPick = PickCard();
            FirstPick.hasBeenDiscovered = true;

            LastPick = PickCard();

            if (FirstPick.Value == LastPick.Value)
            {
                LastPick.hasBeenDiscovered = true;
                Points++;
                Console.WriteLine("Brawo, trafiłeś! Kliknij jakikolwiek przycisk by grać dalej.");
                Console.ReadKey();
            }
            else
            {
                FirstPick.hasBeenDiscovered = false;
                Console.WriteLine("Niestety, nie trafiłeś! Kliknij jakikolwiek przycisk by grać dalej.");
                Console.ReadKey();
            }
        }

        private Card PickCard()
        {
            Console.Write("Podaj X karty: ");
            int X = ReadInt();
            Console.WriteLine();

            Console.Write("Podaj Y karty: ");
            int Y = ReadInt();
            Console.WriteLine();

            Card tmp = Cards[Y][X];
            if (tmp.hasBeenDiscovered == true)
            {
                Console.WriteLine("Podana karta została wcześniej odkryta");
                tmp = PickCard();
            }
            else
            {
                Console.WriteLine("Wybrana karta to " + X + ":" + Y + " - " + tmp.Value);
                Console.WriteLine();
            }
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
