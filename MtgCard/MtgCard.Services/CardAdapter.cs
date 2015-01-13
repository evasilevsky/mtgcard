using System.Collections.Generic;
using MtgCard.Models;
using RestSharp;

namespace MtgCard.Services
{
	public class CardAdapter
	{
		private const string apiLocation = "https://api.deckbrew.com/mtg/cards";
		private RestClient restClient = new RestClient(apiLocation);
		private JsonTranslator jsonTranslator = new JsonTranslator();

		public Card GetCardByName(string cardName)
		{
			return BuildRequestAndSend(cardName);
		}

		private Card BuildRequestAndSend(string cardName)
		{
			RestRequest restRequest = new RestRequest(cardName);
			var restResponse = restClient.Execute(restRequest);
			var card = jsonTranslator.Deserialize<Card>(restResponse.Content);
			return card;
		}

		public List<Card> GetFilteredCards(IEnumerable<KeyValuePair<string, string>> queryStringParameters)
		{
			RestRequest restRequest = new RestRequest();

			foreach (var queryStringParameter in queryStringParameters)
			{
				restRequest.AddParameter(new Parameter { Name = queryStringParameter.Key, Type = ParameterType.QueryString, Value = queryStringParameter.Value });
			}

			var restResponse = restClient.Execute(restRequest);
			var cards = jsonTranslator.Deserialize<List<Card>>(restResponse.Content);
			return cards;
		}

		public List<Card> GetCardsBySetAndRarity(string setName, Rarity rarity)
		{
			var cards = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("set", setName), 
				new KeyValuePair<string, string>("rarity", rarity.ToString().ToLower()) 
			};
			return GetFilteredCards(cards);
		} 
	}
}