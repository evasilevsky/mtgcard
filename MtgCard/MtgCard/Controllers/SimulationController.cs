using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MtgCard.Domain;
using MtgCard.Services;

namespace MtgCard.Controllers
{
    public class SimulationController : ApiController
    {
		[HttpGet]
	    public IEnumerable<Player> Draft(int numberOfPlayers)
	    {
		    var draft = new Draft();
		    var numberOfPacks = 3;
			draft.Players = new CircularList<Player>();
			for (int i = 0; i < numberOfPlayers; i++)
			{
				var packFactory = new PackFactory();
				var player = new Player();
				for (int j = 0; j < numberOfPacks; j++)
				{
					player.EnqueuePack(packFactory.BuildRandomPackFromSet("SOI"));
				}
				draft.Players.Add(player);
			}

		    do
		    {
			    foreach (var player in draft.Players.Where(x => !x.IsDoneDrafting))
			    {
				    player.GetNextPackFromQueue();
				    player.TakeRandomCardFromPack();
			    }
		    } while (draft.Players.Any(x => !x.IsDoneDrafting));

		    return draft.Players;
	    }

    }
}
