using System;
using System.Collections.Generic;
using System.Linq;

namespace MtgCard.Domain
{
	public class Deck
	{
		public List<Card> cards{ get; set; }
		public List<Format> LegalFormats { get
			{
				var formats = new List<Format>();
				foreach (var format in Enum.GetValues(typeof(Format)).Cast<Format>())
				{
					if (IsCardLegalInFormat(format))
					{
						formats.Add(format);
					}
				}
				return formats;
			}
		}

		public bool IsCardLegalInFormat(Format format)
		{
			return true;
		}
	}
}
