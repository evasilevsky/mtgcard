using System;
using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public abstract class ConstructedFormat : Format, IBannable, IRestrictable
	{
		public ConstructedFormat()
		{
			InitialLifeTotal = 20;
		}

		public int MaxNumberOfCopies { get; set; }

		public virtual List<string> RestrictedList
		{
			get
			{
				return new List<string>();
			}
		}

		public bool IsCardRestricted(Card card)
		{
			return RestrictedList.Contains(card.name);
		}
		public virtual List<string> BannedList
		{
			get
			{
				return new List<string>();
			}
		}

		public bool IsCardBanned(Card card)
		{
			return BannedList.Contains(card.name);
		}
	}
}
