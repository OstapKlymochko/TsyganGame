using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Player
    {
        private static Random BelieveHandler = new Random();

        public string Name { get; set; }

        private List<Card> cards;

        public Card? LastGiven  { get; private set; }

        public int CardCount => cards.Count;

        public Player(string name)
        {
            Name = name;
            cards = new List<Card>();
        }

        void TakeCard(Card card) => cards.Add(card);

        public Card RemoveRandomCard()
        {
            return RemoveCard(BelieveHandler.Next(0, cards.Count));
        }

        private Card RemoveCard(int index)
        {
            if (index > cards.Count - 1 || index < 0)
                throw new ArgumentOutOfRangeException($"Index {index} is out of range");
            LastGiven = cards[index];
            cards.RemoveAt(index);
            return LastGiven;
        }

        public bool Believe()
        {
            return BelieveHandler.Next(0, 100) <= 90;
        }

        public override string ToString()
        {
            return $"Player {Name} with {cards.Count} cards.";
        }
    }
}
