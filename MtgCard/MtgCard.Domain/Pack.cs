using System.Collections.Generic;
using MtgCard.Models;

namespace MtgCard.Domain
{
	public class Pack
	{
		public List<Card> Cards { get; set; }
		public string SetName { get; set; }
	}
}
