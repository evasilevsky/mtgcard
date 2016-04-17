using System;
using System.Collections.Generic;

namespace MtgCard.Domain
{
	public class Format
	{
		public string Name { get; set; }
		public int MinimumDeckSize { get; set; }
		public int InitialHandSize { get; set; }
		public int InitialLifeTotal { get; set; }
	}	
}