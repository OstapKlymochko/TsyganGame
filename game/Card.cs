using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public enum Suits
    {
        Clubs = 1,
        Hearts= 2,
        Diamonds = 3,
        Spades = 4
    }
    public enum Values
    {
        Six = 6,Seven = 7,Eight = 8,Nine = 9,Ten = 10,Jack = 11, Queen = 12, King = 13, Ace = 14
    }
    public class Card
    {
        public Values Value { get; init; }
        public Suits Suit { get; init; }

		public override bool Equals(object obj)
		{
            Card card = obj as Card;
			return this.Value == card.Value && this.Suit == card.Suit;
		}
	}
}
