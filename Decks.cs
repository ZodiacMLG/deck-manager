using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckProject
{
    internal class Decks
    {
        struct Deck
        {
            public string Name_card;
            public string Description;
        }

        Deck[] decks;
        int sizeDeck;
        private Random random = new Random();

        enum Suits { Spades, Hearts, Diamonds, Clubs}
        public Decks() { 
            decks = new Deck[0];
            sizeDeck = 0;
        }
        
        public Decks (int n)
        {
            sizeDeck = n;
            decks = new Deck[n];
            int startDeck = 0;

            if (n == 54 || n == 52)
            {
                startDeck = 2;
            } else if (n == 36)
            {
                startDeck = 6;
            }

            int suits = n / 4;
            var countSuits = Suits.Spades;
            int count_cards = 0;
            int temp = startDeck;

            for (int i = 0; i <= (int)Suits.Clubs; i++) 
            {
                for (int j = 0; j < n / 4; j++)
                {
                    decks[count_cards].Name_card = startDeck.ToString();
                    decks[count_cards].Description = countSuits.ToString();
                    
                    switch (startDeck)
                    {
                        case 11: decks[count_cards].Name_card = "Валет"; break;
                        case 12: decks[count_cards].Name_card = "Дама"; break;
                        case 13: decks[count_cards].Name_card = "Король"; break;
                        case 14: decks[count_cards].Name_card = "Туз"; break;
                    }

                    count_cards++;
                    startDeck++;
                }
                countSuits++;
                startDeck = temp;
            }

            if (n == 54)
            {
                decks[52].Name_card = "Джокер";
                decks[52].Description = "Joker";
                decks[53].Name_card = "Джокер";
                decks[53].Description = "Joker";
            }

        }

        public void ShowCards()
        {
            foreach (var deck in decks)
            {
                Console.WriteLine($"{deck.Name_card} - {deck.Description}");
            }
        }

        public void ShowCard(string name, string description)
        {
            bool find = false;
            foreach (var deck in decks)
            {
                if (deck.Name_card == name && deck.Description == description)
                {
                    Console.WriteLine($"{deck.Name_card} - {deck.Description}");
                    find = true;
                }
            }
            if (!find)
            {
                Console.WriteLine($"Card - {name}:{description} - dont find");
            }
        }

        public void Sort()
        {
            bool sorted = true;
            Deck tempDeck;
            do
            {
                sorted = true;
                for (int j = 0; j < sizeDeck - 1; j++)
                {
                    if (GetCardWeight(decks[j].Name_card) < GetCardWeight(decks[j + 1].Name_card))
                    {
                        tempDeck = decks[j];
                        decks[j] = decks[j + 1];
                        decks[j + 1] = tempDeck;
                        sorted = false;
                    }
                }
            } while (!sorted);
        }

        public void Shuffle()
        {
            
            Deck temp;
            for (int i = decks.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                temp = decks[i];
                decks[i] = decks[j];
                decks[j] = temp;
            }
        }

        public int CountCards() { return decks.Length; }

        private int GetCardWeight(string name)
        {

            if (int.TryParse(name, out int number)){
                return number;
            }
            else {
                switch (name)
                {
                    case "Валет": return 11;
                    case "Дама": return 12;
                    case "Король": return 13;
                    case "Туз": return 14;
                    case "Джокер": return 15;
                }
            }
            return 0;
        }        
    }
}
