using System.Collections.Generic;
using MtgCard.Models;

namespace MtgCard.Domain
{
	public class Pack
	{
		public List<Card> Cards { get; set; }
		public string SetName { get; set; }

		public void RemoveCard(Card card)
		{
			Cards.Remove(card);
		}
	}

	public class LimitedPool
	{
		public LimitedPool()
		{
			AllCards = new List<Card>();
		}

		public List<Card> AllCards { get; set; }

		public void AddCardToPool(Card card)
		{
			AllCards.Add(card);
		}
	}

	public enum Rotation
	{
		Left, 
		Right
	}
}
