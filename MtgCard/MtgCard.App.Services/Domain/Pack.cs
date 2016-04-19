using System;
using System.Collections.Generic;

namespace MtgCard.Domain
{
	public class Pack : Product
	{
		private Guid _id = Guid.NewGuid();

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public List<Card> Cards { get; set; }
		public string SetName { get; set; }

		public void RemoveCard(Card card)
		{
			Cards.Remove(card);
		}

		public Card GetRandomCard()
		{
			var random = new Random();
			var index = random.Next(0, Cards.Count);
			return Cards[index];
		}

		public bool IsEmpty()
		{
			return Cards == null || Cards.Count == 0;
		}
	}

	public class Pool
	{
		public Pool()
		{
			Cards = new List<Card>();
		}

		public void AddPackToPool(Pack pack)
		{
			Cards.AddRange(pack.Cards);
		}

		public List<Card> Cards { get; set; }

		public void AddCardToPool(Card card)
		{
			Cards.Add(card);
		}
	}

	public enum Rotation
	{
		Left, 
		Right
	}
}
