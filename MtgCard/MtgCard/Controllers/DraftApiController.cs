using System.Collections.Generic;
using System.Web.Http;
using MtgCard.Domain;
using MtgCard.Models;
using MtgCard.Services;

namespace MtgCard.Controllers
{
	public class DraftApiController : ApiController
	{
		private PackFactory _packFactory = new PackFactory();

		public IEnumerable<Pack> GetPacksForPlayer(string setId)
		{
			for (int i = 0; i < 3; i++)
			{
				yield return _packFactory.BuildRandomPackFromSet(setId);
			}
		}

		public IEnumerable<Pack> GetPacksForPlayer(string setId1, string setId2, string setId3)
		{
			yield return _packFactory.BuildRandomPackFromSet(setId1);
			yield return _packFactory.BuildRandomPackFromSet(setId2);
			yield return _packFactory.BuildRandomPackFromSet(setId3);
		}

		public Draft GetDraft(int numberOfPlayers)
		{
			var draft = new Draft();
			var players = new List<Player>();
			for (int i = 0; i < numberOfPlayers; i++)
			{
				var packsForPlayer = GetPacksForPlayer("KTK");
				players.Add(new Player
				{
					StartingPacks = packsForPlayer
				});
			}
			return draft;
		}

		public Pack GetRandomPack()
		{
			var pack = _packFactory.BuildRandomPackFromSet("KTK");
			return pack;
		}
	}

	public class Draft
	{
		public IEnumerable<Player> Players { get; set; }
		public Rotation CurrentRotation { get; set; }

		public void TakeCardFromPack(Player player, Card card)
		{
			player.TakeCardFromPack(card);
		}

		private void PassPackToNextPlayer(Player player)
		{
			if (CurrentRotation == Rotation.Left)
			{
				//todo
			}
		}
	}

	public class Player
	{
		private IEnumerable<Pack> _packQueue = new List<Pack>();
		public IEnumerable<Pack> StartingPacks { get; set; }

		public Pack CurrentPack { get; set; }
		public LimitedPool LimitedPool { get; set; }

		public IEnumerable<Pack> PackQueue
		{
			get { return _packQueue; }
			set { _packQueue = value; }
		}

		public void TakeCardFromPack(Card card)
		{
			CurrentPack.RemoveCard(card);
			LimitedPool.AddCardToPool(card);
		}
	}
}
