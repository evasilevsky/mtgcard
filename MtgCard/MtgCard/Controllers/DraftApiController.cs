using System;
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
		private Draft _draft;

		public DraftApiController()
		{
			_draft = GetDraft(3);
		}

		public void TakeCardFromPack(Player player, Card card)
		{
			//var player = _draft.GetPlayerById(playerId);
			_draft.TakeCardFromPack(player, card);
		}

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
}
