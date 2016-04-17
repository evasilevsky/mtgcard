using System;
using System.Collections.Generic;

namespace MtgCard.Domain.Formats
{
	public class Vintage : IBannable, IRestrictable
	{

		public bool IsCardRestricted(Card card)
		{
			return RestrictedList.Contains(card.name);
		}
		public bool IsCardBanned(Card card)
		{
			return BannedList.Contains(card.name);
		}
		public List<string> BannedList
		{
			get
			{
				var list = new List<string>
				{
					"Advantageous Proclamation",
					"Amulet of Quoz",
					"Backup Plan",
					"Brago's Favor",
					"Bronze Tablet",
					"Chaos Orb",
					"Contract from Below",
					"Darkpact",
					"Demonic Attorney",
					"Double Stroke",
					"Falling Star",
					"Immediate Action",
					"Iterative Analysis",
					"Jeweled Bird",
					"Muzzio's Preparations",
					"Power Play",
					"Rebirth",
					"Secret Summoning",
					"Secrets of Paradise",
					"Sentinel Dispatch",
					"Shahrazad",
					"Tempest Efreet",
					"Timmerian Fiends",
					"Unexpected Potential",
					"Worldknit"
				};
				return list;
			}
		}

		public List<string> RestrictedList
		{
			get
			{
				var list = new List<string>
				{
					"Ancestral Recall",
					"Balance",
					"Black Lotus",
					"Brainstorm",
					"Chalice of the Void",
					"Channel",
					"Demonic Consultation",
					"Demonic Tutor",
					"Dig Through Time",
					"Fastbond",
					"Flash",
					"Imperial Seal",
					"Library of Alexandria",
					"Lion's Eye Diamond",
					"Lodestone Golem",
					"Lotus Petal", 
					"Mana Crypt",
					"Mana Vault",
					"Memory Jar",
					"Merchant Scroll", 
					"Mind's Desire",
					"Mox Emerald",
					"Mox Jet",
					"Mox Pearl",
					"Mox Ruby",
					"Mox Sapphire",
					"Mystical Tutor",
					"Necropotence",
					"Ponder",
					"Sol Ring",
					"Strip Mine",
					"Time Vault",
					"Time Walk",
					"Timetwister",
					"Tinker",
					"Tolarian Academy",
					"Treasure Cruise",
					"Trinisphere", 
					"Vampiric Tutor",
					"Wheel of Fortune",
					"Windfall",
					"Yawgmoth's Bargain",
					"Yawgmoth's Will"
				};
				return list;
			}
		}
	}
}
