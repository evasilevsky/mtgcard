using System.Collections.Generic;
using MtgCard.Domain;

namespace MtgCard.Services
{
    public interface ICardAdapter
    {
        Card GetCardByName(string cardName);
        List<Card> GetCardsBySetAndRarity(string setName, Rarity rarity);
        List<Card> GetFilteredCards(IEnumerable<KeyValuePair<string, string>> queryStringParameters);
        List<Card> GetTypeAhead(string searchTerm);
    }
}