using NUnit.Framework;

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
    }
}
