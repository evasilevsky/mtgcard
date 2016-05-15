using System;
using System.Collections.Generic;
using System.Linq;
using MtgCard.Domain;

namespace MtgCard.Services
{
	public class PackFactory : IPackFactory
    {
		private ICardAdapter _cardAdapter = new CardAdapter();
		private Random _random = new Random();

        public PackFactory(ICardAdapter cardAdapter)
        {
            _cardAdapter = cardAdapter;
        }
		
		public Pack Build(List<Card> cards)
		{
			return new Pack
			{
				Cards = cards
			};
		}

		public Pack Build(List<string> cardNames)
		{
			var cardAdapter = new CardAdapter();
			var cards = cardNames.Select(x => cardAdapter.GetCardByName(x)).ToList();
			return new Pack {Cards = cards};
		}

		public Pack BuildRandomPackFromSet(string setName, bool packShouldContainFoil = false, bool packShouldContainMythic = false)
		{
			var pack = new List<Card>();
			var allCards = _cardAdapter.GetCardsBySetAndRarity(setName, Rarity.Common);

			var allCommons = _cardAdapter.GetCardsBySetAndRarity(setName, Rarity.Common);
			var allUncommons = _cardAdapter.GetCardsBySetAndRarity(setName, Rarity.Uncommon);
			var allRares = _cardAdapter.GetCardsBySetAndRarity(setName, Rarity.Rare);
			var allMythics = _cardAdapter.GetCardsBySetAndRarity(setName, Rarity.Mythic);
			var numberOfCommons = ApplicationStateRepository.CommonsPerPack;
			var numberOfUncommons = ApplicationStateRepository.UncommonsPerPack;

			if (packShouldContainFoil)
			{
				var foil = allCards.OrderBy(x => Guid.NewGuid()).First();
				var foilIsCommon = foil.editions.Select(x => x.rarity == Rarity.Common.ToString() && x.set_Id == setName).First();
				if (foilIsCommon)
				{
					numberOfCommons--;
				}
				else
				{
					numberOfUncommons--;
				}
				pack.Add(foil);
			}

			var commons = allCommons.OrderBy(x => Guid.NewGuid()).Take(numberOfCommons);
			var uncommons = allUncommons.OrderBy(x => Guid.NewGuid()).Take(numberOfUncommons);
			pack.AddRange(commons);
			pack.AddRange(uncommons);

			if (packShouldContainMythic)
			{
				var mythic = allMythics.OrderBy(x => Guid.NewGuid()).First();
				pack.Add(mythic);
			}
			else
			{
				var rare = allRares.OrderBy(x => Guid.NewGuid()).First();
				pack.Add(rare);
			}


			return new Pack
			{
				Cards = pack
			};
		}
	}
}
