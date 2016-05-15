using System;
using System.Collections.Generic;
using System.Linq;

namespace MtgCard.Domain
{
	public class Player
	{
		private Guid _id = Guid.NewGuid();
        private Queue<Pack> _packQueue = new Queue<Pack>();
		private bool _isDoneDrafting;
		private Queue<Pack> _startingPackQueue = new Queue<Pack>();
		private Pack _currentPack;
		private Pool _limitedPool = new Pool();
        public TableList<Player> tableList { get; set; }
        public string Name { get; set; }

        public Queue<Pack> StartingPackQueue
		{
			get { return _startingPackQueue; }
			set { _startingPackQueue = value; }
		}

		public Pack CurrentPack
		{
			get
			{
				return _currentPack;
			}
			set { _currentPack = value; }
		}

		public Pool LimitedPool
		{
			get { return _limitedPool; }
			set { _limitedPool = value; }
		}

		public void EnqueuePack(Pack pack)
		{
			StartingPackQueue.Enqueue(pack);
		}

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

			TakeCardFromPack(card);
		}

		public bool IsDoneDrafting
		{
			get { return _isDoneDrafting; }
			set { _isDoneDrafting = value; }
		}

		public void TakeCardFromPack(Card card)
		{
			CurrentPack.RemoveCard(card);
			LimitedPool.AddCardToPool(card);

			if (CurrentPack.IsEmpty())
			{
				if (StartingPackQueue.Count == 0)
				{
					IsDoneDrafting = true;
				}
				else
				{
					CurrentPack = StartingPackQueue.Dequeue();
				}
			}
		}

		public void TakeRandomCardFromPack()
		{
			var randomCard = CurrentPack.GetRandomCard();
			TakeCardFromPack(randomCard);
		}

		private Card GetCardByIdInCurrentPack(Guid cardId)
		{
			return CurrentPack.Cards.First(x => x.CardId == cardId);
		}

		public void GetNextPackFromQueue()
		{
			if (CurrentPack == null || (CurrentPack.IsEmpty() && PackQueue.Count == 0 && StartingPackQueue.Count > 0))
			{
				CurrentPack = StartingPackQueue.Dequeue();
			}
			else
			{
				CurrentPack = _packQueue.Dequeue();
			}
		}

		public void AddPackToQueue(Pack pack)
		{
			PackQueue.Enqueue(pack);
		}

        public void PassPackLeft(Pack pack)
        {
            tableList.Left.AddPackToQueue(pack);
        }

        public void PassPackRight(Pack pack)
        {
            tableList.Right.AddPackToQueue(pack);
        }
    }
}