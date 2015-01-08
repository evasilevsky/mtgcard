using MtgCard.Models;
using RestSharp;

namespace MtgCard.Services
{
	public class CardAdapter
	{
		private string apiLocation = "https://api.deckbrew.com/mtg/cards/";

		public Card GetCardByName(string cardName)
		{
			RestClient restClient = new RestClient(apiLocation);
			RestRequest restRequest = new RestRequest(cardName);
			var restResponse = restClient.Execute(restRequest);
			JsonTranslator jsonTranslator = new JsonTranslator();
			var card = jsonTranslator.Deserialize<Card>(restResponse.Content);
			return card;
		}
	}
}