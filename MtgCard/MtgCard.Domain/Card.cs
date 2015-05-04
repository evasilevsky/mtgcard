using System;
using System.Collections.Generic;

namespace MtgCard.Models
{
	public class Card
	{
		public string name;
		public string id;
		public string url;
		public string storeUrl;
		public List<string> types;
		public List<string> colors;
		public int convertedManaCost;
		public string cost;
		public string text;
		public Formats formats;
		public List<Edition> editions;
		public Guid CardId;
	}
}