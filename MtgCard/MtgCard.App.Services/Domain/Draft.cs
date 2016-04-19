using System;
using System.Collections.Generic;
using System.Linq;

namespace MtgCard.Domain
{

	public class Draft
	{
		private Draft instance = null;
		public CircularList<Player> Players { get; set; }
		public Rotation CurrentRotation { get; set; }

		public void TakeCardFromPack(Guid playerId, Guid cardId)
		{
			var player = GetPlayerById(playerId);
			player.TakeCardFromPack(cardId);
		}

		private void PassPackToNextPlayer(Player player)
		{
			var increment = 1;
			
			if (CurrentRotation == Rotation.Right)
			{
				increment = -1;
			}

			var currentPack = player.CurrentPack;

			for (int i = 0; i < Players.Count; i++)
			{
				if (player == Players[i])
				{
					Players[i + increment].AddPackToQueue(currentPack);
					Players[i].GetNextPackFromQueue();
					break;
				}
			}
		}

		public Player GetPlayerById(Guid playerId)
		{
			return Players.First(x => x.Id == playerId);
		}
	}

	public static class DraftFactory
	{
		private static Draft _draft;
		//public static Draft GetInstance()
		//{
		//	if (_draft == null)
		//	{
		//		_draft = GetNewDraft(3);
		//	}
		//	return _draft;
		//}

		//private static Draft GetNewDraft(int numberOfPlayers)
		//{
		//	var draft = new Draft();
		//	var players = new List<Player>();
		//	for (int i = 0; i < numberOfPlayers; i++)
		//	{
		//		var packsForPlayer = GetPacksForPlayer("KTK");

		//		var player = new Player();
		//		foreach (var pack in packsForPlayer)
		//		{
		//			player.EnqueuePack(pack);
		//		}
		//		players.Add(player);
		//	}
		//	return draft;
		//}oju


		//private static IEnumerable<Pack> GetPacksForPlayer(string setId)
		//{
		//	var packFactory = new PackFactory();
		//	for (int i = 0; i < 3; i++)
		//	{
		//		yield return packFactory.BuildRandomPackFromSet(setId);
		//	}
		//}
	}
}