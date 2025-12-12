using System.Reflection.Metadata.Ecma335;

namespace DeckProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Decks Deck;
            Console.WriteLine("Enter decks: \n1 - 36\n2 - 52\n3 - 54");

            string ?choice = Console.ReadLine();

            for (; ; )
            {
                if (choice == "1")
                {
                    Deck = new Decks(36);
                    break;
                }
                else if (choice == "2")
                {
                    Deck = new Decks(52);
                    break;
                }
                else if (choice == "3")
                {
                    Deck = new Decks(54);
                    break;
                    
                }
                Console.Write("Enter correct value: ");
                choice = Console.ReadLine();
            }
            Console.Clear();
            
            for(; ; )
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Deck ({Deck.CountCards()})");
                Console.WriteLine("1 - Show deck\n2 - Sort deck\n3 - Find card in deck\n4 - Shuffle\n5 - Exit");
                Console.WriteLine("-------------------------------");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    Deck.ShowCards();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Deck.Sort();
                    Console.WriteLine("Sort complete.");
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("What card do u want to find?");
                    string? card = Console.ReadLine();
                    string? cardDesc = Console.ReadLine();
                    Deck.ShowCard(card, cardDesc);
                } 
                else if (choice == "4")
                {
                    Console.Clear();
                    Deck.Shuffle();
                    Console.WriteLine("Shuffle complete");
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}
