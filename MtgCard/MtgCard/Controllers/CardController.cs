using System.Web.Http;
using MtgCard.Services;
using MtgCard.Models;

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