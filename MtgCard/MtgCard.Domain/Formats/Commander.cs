using System;
using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public class Commander : ConstructedFormat, ICommanderBannable
	{
		public Commander()
		{
			MaxNumberOfCopies = 1;
			MinimumDeckSize = 100;
			InitialLifeTotal = 40;
		}

		public List<string> BannedAsCommanderList
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
