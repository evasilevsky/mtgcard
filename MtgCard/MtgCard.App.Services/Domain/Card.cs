using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MtgCard.Domain
{
	public class Card : INotifyPropertyChanged
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
		public Format formats;
		public List<Edition> editions;
		public Guid CardId;

		public int copies;

		public event PropertyChangedEventHandler PropertyChanged;

		public string DefaultImage
		{
			get
			{
				return editions?[0].image_Url;
			}
		}
	}
}