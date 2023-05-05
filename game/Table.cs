using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
	public static class GameTable
	{
		private static Random random = new Random();
		private static Stack<Card> InitRandomDeck()
		{
            Stack<Card> cards = new Stack<Card>();
            Random rng = new Random();
            List<Card> deck = new List<Card>();
			foreach (Suits suit in Enum.GetValues(typeof(Suits)))
			{
				foreach (Values value in Enum.GetValues(typeof(Values)))
				{
					deck.Add(new Card(value, suit));
				}
			}
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

        private static void DistributeCards(Stack<Card> deck, List<Player> players)
		{
			int CardsToGiveOut = deck.Count / players.Count;
			for (int i = 0; i <= CardsToGiveOut; i++)
			{
				foreach (Player p in players)
					p.TakeCard(deck.Pop());
			}
		}

		private static Player FindOneDidntBeliever(List<Player> players, List<int> ThoseDidntBelieveIndexes)
		{
			return players[ThoseDidntBelieveIndexes[random.Next(0, ThoseDidntBelieveIndexes.Count - 1)]];
		}

		public static void startGame(IEnumerable<Player> PlayersParam)
		{
			Stack<Card> deck = InitRandomDeck(); 
			List<Player> players = new List<Player>(PlayersParam);
			DistributeCards(deck, players);
			//List<Player> ThoseDidntBelieve = new List<Player>();
            Stack<Card> CardsOnTable = new Stack<Card>();
			List<int> ThoseDidntBelieveIndexes = new List<int>(players.Count);
            while (players.TrueForAll(x => x.CardCount > 0))
			{
				foreach(Player p in players)
				{
					CardsOnTable.Push(p.DropRandomCard());
					for (int i = 0;i <= players.Count; i++) 
					{
						if (!players[i].Believe()) ThoseDidntBelieveIndexes.Add(i);
					}

					if (ThoseDidntBelieveIndexes.Count > 0)
					{
						Player DidntBeliever = FindOneDidntBeliever(players, ThoseDidntBelieveIndexes);
						//if (p.LastGiven)
					}
				}
			}


            
		}
	}
}
