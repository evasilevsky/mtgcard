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
				var legalFormats = new List<Format>();

				var type = typeof(Format);
				var allFormatsTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);

				foreach (var formatType in allFormatsTypes)
				{
					var format = Activator.CreateInstance(formatType) as Format;
					foreach (var card in cards)
					{
						//if (format.IsCardLegalInFormat()
						//{
						//	legalFormats.Add(formatType);
						//}
					}
				}
				return legalFormats;
			}
		}

		public bool IsCardLegalInFormat(Format format)
		{
			return true;
		}
	}
}
