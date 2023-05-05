using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
	public static class GameTable
	{
		
		private static Stack<Card> initRandomDeck()
		{
			List<Card> deck = new List<Card>();
			foreach (Suits suit in Enum.GetValues(typeof(Suits)))
			{
				foreach (Values value in Enum.GetValues(typeof(Values)))
				{
					deck.Add(new Card(value, suit));
				}
			}
			foreach (Card c in deck)
			{
				Console.WriteLine(c);
			}
			Stack<Card> cards = new Stack<Card>();
			Random rng = new Random();
			int n = deck.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				Card value = deck[k];
				deck[k] = deck[n];
				deck[n] = value;
			}
			foreach (Card c in deck)
			{
				cards.Push(c);
			}
			return cards;
		}
		private static void giveAllCards(Player _player, Stack<Card> _cards)
		{
			while (_cards.Count > 0)
			{
				_player.TakeCard(_cards.Pop());
			}
		}
		public static void startGame(IEnumerable<Player> _players)
		{
			Stack<Card> deck = initRandomDeck();
			Stack<Card> CardsOnTable = new Stack<Card>();
			List<Player> players;
            Console.WriteLine("\n\n\n\n\n");
            foreach (Card c in deck)
			{
                Console.WriteLine(c);
            }
		}
	}
}
