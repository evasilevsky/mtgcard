using System;

namespace MtgCard.Models
{
	public class Edition
	{
		public String set;
		public String setId;
		public String rarity;
		public String artist;
		public String multiverseId;
		public String number;
		public String layout;
		public Price price;
		public String url;
		public String imageUrl;
		public String setUrl;
		public String storeUrl;

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