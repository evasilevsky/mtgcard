using MtgCard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Services
{
    public class DraftService
    {
        public List<Player> Players { get; set; }
        public PackFactory PackFactory { get; set; }

        public DraftService(List<string> playerNames)
        {
            PackFactory = new PackFactory();
            InitializePlayers(playerNames);
        }

        public void InitializePlayers(List<string> playerNames)
        {
            Players = (from p in playerNames
                       select new Player { Name = p }).ToList();                      ;
            var count = playerNames.Count();
            for (var i = 0; i < count; i++)
            {
                Player left = null;
                Player right = null;
                if (i == 0)
                {
                    left = Players[count - 1];
                }
                else
                {
                    left = Players[i - 1];
                }

                if (i == count - 1)
                {
                    right = Players[0];
                }
                else
                {
                    right = Players[i + 1];
                }

                Players[i].tableList = new TableList<Player>(left, right);
                for (int j = 0; j < ApplicationStateRepository.PacksPerDraft; j++)
                {
                    Players[i].EnqueuePack(PackFactory.BuildRandomPackFromSet("SOI"));
                }
            }
        }
    }
}
