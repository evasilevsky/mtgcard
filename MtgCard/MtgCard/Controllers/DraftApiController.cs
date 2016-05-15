using System;
using System.Collections.Generic;
using System.Web.Http;
using MtgCard.Domain;
using MtgCard.Services;

namespace MtgCard.Controllers
{
	public class DraftApiController : ApiController
	{
		private IPackFactory _packFactory = new PackFactory(new CardAdapter());
		private Draft _currentDraft;

		public DraftApiController()
		{
			//_currentDraft = DraftFactory.GetInstance();
		}

		public void TakeCardFromPack(Guid playerId, Guid cardId)
		{
			_currentDraft.TakeCardFromPack(playerId, cardId);
		}

		public Draft GetDraft()
		{
			return _currentDraft;
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


		public Pack GetRandomPack()
		{
			var pack = _packFactory.BuildRandomPackFromSet("SOI");
			return pack;
		}
	}
}
