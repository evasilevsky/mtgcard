using NUnit.Framework;
using System.Linq;

namespace MtgCard.Services.Tests
{
    public class CardAdapterTests
    {
        [TestFixture]
        public class GetCardByName : CardAdapterTests
        {
            [Test]
            public void ReturnsId()
            {
                var cardId = "force-of-will";
                var classUnderTest = new CardAdapter();
                var result = classUnderTest.GetCardByName(cardId);
                Assert.That(result.id == cardId);
            }
        }
		[TestFixture]
		public class GetTypeAhead : CardAdapterTests
		{
			[TestCase("f")]
			[TestCase("fo")]
			[TestCase("for")]
			[TestCase("forc")]
			[TestCase("force")]
			public void CardDoesNotShowUpInFirstTenResults(string searchTerm)
			{
				var classUnderTest = new CardAdapter();
				var result = classUnderTest.GetTypeAhead(searchTerm);
				Assert.That(!result.Any(x => x.name == "Force of Will"));
			}

			[TestCase("force ")]
			[TestCase("force o")]
			[TestCase("force of")]
			[TestCase("force of ")]
			[TestCase("force of w")]
			[TestCase("force of wi")]
			[TestCase("force of wil")]
			[TestCase("force of will")]
			public void CardShowsUpInFirstTenResults(string searchTerm)
			{
				var classUnderTest = new CardAdapter();
				var result = classUnderTest.GetTypeAhead(searchTerm);
				Assert.That(result.Any(x => x.name == "Force of Will"));
			}
		}
	}
}
