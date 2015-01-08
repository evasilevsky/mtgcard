using System.Web.Http;
using System.Web.Mvc;
using MtgCard.Models;
using MtgCard.Services;

namespace MtgCard.Controllers
{
    public class CardController : ApiController
    {
	    private CardAdapter _cardAdapter = new CardAdapter();

	    public CardController()
	    {
		    
	    }

        public Card Get(string cardName)
        {
            return _cardAdapter.GetCardByName(cardName);
        }
    }
}