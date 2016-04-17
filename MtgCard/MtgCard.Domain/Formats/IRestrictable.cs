using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public interface IRestrictable
	{
		bool IsCardRestricted(Card cardName);
		List<string> RestrictedList { get; }
	}
}
