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
    public class DraftServiceTests
    {
        [Test]
        public void test()
        {
            var list = new List<string>()
            {
                "tom", "bob", "sue", "joe", "edith", "jack", "jacob", "don"
            };
            var draftService = new DraftService(new PackFactory(new CardAdapter()));
            draftService.InitializePlayers(list);
            Player bob = draftService.Players.First(x => x.Name == "bob");
        }
    }
}
