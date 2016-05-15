using MtgCard.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Services.Tests
{
    [TestFixture]
    public class PackFactoryTests
    {
        [TestCase("KTK")]
        public void BuildRandomPackFromSet(string setName)
        {
            var packFactory = new PackFactory(new CardAdapter());

            var result = packFactory.BuildRandomPackFromSet(setName);

            var commonCount = result.Cards.Count(x => x.editions.First().rarity == Rarity.Common.ToString().ToLower());
            var uncommonCount = result.Cards.Count(x => x.editions.First().rarity == Rarity.Uncommon.ToString().ToLower());
            var rareCount = result.Cards.Count(x => x.editions.First().rarity == Rarity.Rare.ToString().ToLower());
            var mythicCount = result.Cards.Count(x => x.editions.First().rarity == Rarity.Mythic.ToString().ToLower());

            Assert.AreEqual(commonCount, ApplicationStateRepository.CommonsPerPack);

            Assert.AreEqual(uncommonCount, ApplicationStateRepository.UncommonsPerPack);

            Assert.AreEqual(rareCount, 1);
            Assert.AreEqual(mythicCount, 0);
        }
    }
}
