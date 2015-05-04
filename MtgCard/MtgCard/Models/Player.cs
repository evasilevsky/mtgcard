using System;
using System.Collections.Generic;
using System.Linq;
using MtgCard.Domain;

namespace MtgCard.Models
{
	public class Player
	{
		private Guid _id = Guid.NewGuid();
		private Queue<Pack> _packQueue = new Queue<Pack>();
		public IEnumerable<Pack> StartingPacks { get; set; }

		public Pack CurrentPack { get; set; }
		public LimitedPool LimitedPool { get; set; }

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public Queue<Pack> PackQueue
		{
			get { return _packQueue; }
			set { _packQueue = value; }
		}

		public void TakeCardFromPack(Guid cardId)
		{
			var card = GetCardByIdInCurrentPack(cardId);

			CurrentPack.RemoveCard(card);
			LimitedPool.AddCardToPool(card);
		}

		private Card GetCardByIdInCurrentPack(Guid cardId)
		{
			return CurrentPack.Cards.First(x => x.CardId == cardId);
		}

		public void GetNextPackFromQueue()
		{
			CurrentPack = _packQueue.Dequeue();
		}

		public void AddPackToQueue(Pack pack)
		{
			PackQueue.Enqueue(pack);
		}
	}
}