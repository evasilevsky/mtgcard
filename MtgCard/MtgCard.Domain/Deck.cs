using MtgCard.Domain.Formats;
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

		public bool IsCardBannedInFormat(Card card, IBannable format)
		{
			var isBanned = false;
			foreach (var bannedCard in format.BannedList)
			{
				if (card.name == bannedCard)
				{
					isBanned = true;
				}
			}
			return isBanned;
		}

		public bool IsCardLegalInFormat(Format format)
		{
			return true;
		}
	}
}
