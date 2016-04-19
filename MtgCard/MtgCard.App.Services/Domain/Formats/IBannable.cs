using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public interface IBannable
	{
		bool IsCardBanned(Card card);
		List<string> BannedList { get; }
	}

}
