using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain.Formats
{
	public interface IBannable
	{
		List<string> BannedList { get; }
	}

}
