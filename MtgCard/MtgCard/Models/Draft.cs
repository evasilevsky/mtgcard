using System;
using System.Linq;
using MtgCard.Domain;

namespace MtgCard.Models
{
	public class Draft
	{
		public CircularList<Player> Players { get; set; }
		public Rotation CurrentRotation { get; set; }

		public void TakeCardFromPack(Player player, Card card)
		{
			player.TakeCardFromPack(card);
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
}