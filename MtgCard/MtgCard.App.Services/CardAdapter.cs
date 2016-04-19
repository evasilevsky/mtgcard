using System.Collections.Generic;
using MtgCard.Domain;
using System.Net.Http;
using MtgCard.App.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MtgCard.Services
{
	public class CardAdapter
	{
		private const string apiLocation = "https://api.deckbrew.com/mtg/cards";
		private JsonTranslator jsonTranslator = new JsonTranslator();

		public async Task<Card> GetCardByName(string cardName)
		{
			return await BuildRequestAndSend(cardName);
		}

		private async Task<Card> BuildRequestAndSend(string cardName)
		{
			HttpClientHandler systemHandler = new HttpClientHandler();
			CustomHandler1 handler = new CustomHandler1();
			handler.InnerHandler = systemHandler;
			HttpClient myClient = new HttpClient(handler);
			var cts = new CancellationTokenSource();
			cts.CancelAfter(TimeSpan.FromSeconds(30));

			var resourceUri = new Uri(apiLocation);
			Card card = null;

			try
			{
				HttpResponseMessage response = await myClient.GetAsync(resourceUri + "/" + cardName, cts.Token);
				var content = await response.Content.ReadAsStringAsync();
				card = jsonTranslator.Deserialize<Card>(content);
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (HttpRequestException ex)
			{

			}
			
			return card;
		}

		//public List<Card> GetFilteredCards(IEnumerable<KeyValuePair<string, string>> queryStringParameters)
		//{

		//	RestRequest restRequest = new RestRequest();

		//	foreach (var queryStringParameter in queryStringParameters)
		//	{
		//		restRequest.AddParameter(new Parameter { Name = queryStringParameter.Key, Type = ParameterType.QueryString, Value = queryStringParameter.Value });
		//	}

		//	var restResponse = restClient.Execute(restRequest);
		//	var cards = jsonTranslator.Deserialize<List<Card>>(restResponse.Content);
		//	return cards;
		//}

		public async Task<List<Card>> GetTypeAhead(string searchTerm)
		{
			HttpClientHandler systemHandler = new HttpClientHandler();
			CustomHandler1 handler = new CustomHandler1();
			HttpClient myClient = new HttpClient(handler);
			var cts = new CancellationTokenSource();
			cts.CancelAfter(TimeSpan.FromSeconds(30));

			var resourceUri = new Uri(apiLocation);
			List<Card> card = null;

			try
			{
				HttpResponseMessage response = await myClient.GetAsync(resourceUri + "/typeahead", cts.Token);
				card = jsonTranslator.Deserialize<List<Card>>(response.Content.ToString());
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (HttpRequestException ex)
			{

			}

			return card;
		}

		//public List<Card> GetCardsBySetAndRarity(string setName, Rarity rarity)
		//{
		//	var cards = new List<KeyValuePair<string, string>>
		//	{
		//		new KeyValuePair<string, string>("set", setName), 
		//		new KeyValuePair<string, string>("rarity", rarity.ToString().ToLower()) 
		//	};
		//	return GetFilteredCards(cards);
		//} 
	}
}