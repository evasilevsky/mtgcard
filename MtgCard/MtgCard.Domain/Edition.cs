using System;

namespace MtgCard.Models
{
	public class Edition
	{
		public string set;
		public string set_Id;
		public string rarity;
		public string artist;
		public string multiverseId;
		public string number;
		public string layout;
		public Price price;
		public string url;
		public string image_Url;
		public string setUrl;
		public string storeUrl;

		//    "set": "Alliances",
		//    "set_id": "ALL",
		//    "rarity": "uncommon",
		//    "artist": "Terese Nielsen",
		//    "multiverse_id": 3107,
		//    "number": "",
		//    "layout": "normal",
		//    "price": {
		//      "low": 7500,
		//      "median": 8938,
		//      "high": 12825
		//    },
		//    "url": "https://api.deckbrew.com/mtg/cards?multiverseid=3107",
		//    "image_url": "https://image.deckbrew.com/mtg/multiverseid/3107.jpg",
		//    "set_url": "https://api.deckbrew.com/mtg/sets/ALL",
		//    "store_url": "http://store.tcgplayer.com/magic/alliances/force-of-will?partner=DECKBREW"
	}
}