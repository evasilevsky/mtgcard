using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using MtgCard.Services;
using MtgCard.Domain;

namespace MtgCard.Controllers
{
    public class CardController : ApiController
    {
	    private CardAdapter _cardAdapter = new CardAdapter();
		
        public Card Get(string cardName)
        {
	        return _cardAdapter.GetCardByName(cardName);
        }

	    public List<Card> GetFilteredCards()
	    {
		    return _cardAdapter.GetFilteredCards(Request.GetQueryNameValuePairs());
	    }
    }
}