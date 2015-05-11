using System;
using System.Collections.Generic;
using MtgCard.Models;

namespace MtgCard.Domain
{
	public class Pack
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
