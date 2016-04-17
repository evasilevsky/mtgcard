using MtgCard.Domain.Exceptions;
using MtgCard.Domain.Formats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MtgCard.Domain
{
	public class Deck
	{
		public List<Card> MainBoard{ get; set; }
		public List<Card> SideBoard { get; set; }
		public List<Card> MaybeBoard { get; set; }
		public List<ConstructedFormat> LegalConstructedFormats { get
			{
				var legalFormats = new List<ConstructedFormat>();

				var type = typeof(ConstructedFormat);
				var allFormatsTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && !p.IsAbstract);

				foreach (var formatType in allFormatsTypes)
				{
					var format = Activator.CreateInstance(formatType) as ConstructedFormat;
					var allCards = new List<Card>();
					allCards.AddRange(MainBoard);
					allCards.AddRange(SideBoard);
					if (AreCardsLegalInFormat(allCards, format))
					{
						legalFormats.Add(format);
					}
				}
				return legalFormats;
			}
		}

		public bool AreCardsLegalInFormat(List<Card> cards, ConstructedFormat format)
		{
			var isLegal = true;
			foreach (var card in cards)
			{
				var copies = MainBoard.Count(c => c.name == card.name);
				if (copies > format.MaxNumberOfCopies)
				{
					throw new TooManyCopiesException($"{card.name} has too many copies ({copies} > {format.MaxNumberOfCopies}) in {format.Name}");
				}
				else if (format.IsCardRestricted(card) && copies > 1)
				{
					throw new RestrictedCardException($"{card.name} is restricted in {format.Name}. You are only allowed one copy. ");
				}
				if (format.IsCardBanned(card))
				{
					throw new RestrictedCardException($"{card.name} is banned in {format.Name}. No copies are allowed.");
				}
			}

			return isLegal;
		}

		public bool IsCardLegalInFormat(Format format)
		{
			return true;
		}
	}
}
