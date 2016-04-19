using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public interface ICommanderBannable
	{
		List<string> BannedAsCommanderList { get; }
	}
}
