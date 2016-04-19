using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public class LimitedFormat : Format
	{
		public List<Product> SealedProduct { get; set; }
		public Pool Pool { get; set; }
	}
}
