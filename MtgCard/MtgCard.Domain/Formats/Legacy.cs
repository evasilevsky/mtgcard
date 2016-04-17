using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain.Formats
{
	public class Legacy : Format, IBannable
	{
		public List<string> BannedList
		{
			get
			{
				var list = new List<string>
				{
					"Advantageous Proclamation",
					"Amulet of Quoz",
					"Ancestral Recall",
					"Backup Plan",
					"Balance",
					"Bazaar of Baghdad",
					"Black Lotus",
					"Brago's Favor",
					"Bronze Tablet",
					"Channel",
					"Chaos Orb",
					"Contract from Below",
					"Darkpact",
					"Demonic Attorney",
					"Demonic Consultation",
					"Demonic Tutor",
					"Dig Through Time",
					"Double Stroke",
					"Earthcraft",
					"Falling Star",
					"Fastbond",
					"Flash",
					"Frantic Search",
					"Goblin Recruiter",
					"Gush",
					"Hermit Druid",
					"Immediate Action",
					"Imperial Seal",
					"Iterative Analysis",
					"Jeweled Bird",
					"Library of Alexandria",
					"Mana Crypt",
					"Mana Drain",
					"Mana Vault",
					"Memory Jar",
					"Mental Misstep",
					"Mind Twist",
					"Mind's Desire",
					"Mishra's Workshop",
					"Mox Emerald",
					"Mox Jet",
					"Mox Pearl",
					"Mox Ruby",
					"Mox Sapphire",
					"Muzzio's Preparations",
					"Mystical Tutor",
					"Necropotence",
					"Oath of Druids",
					"Power Play",
					"Rebirth",
					"Secret Summoning",
					"Secrets of Paradise",
					"Sentinel Dispatch",
					"Shahrazad",
					"Skullclamp",
					"Sol Ring",
					"Strip Mine",
					"Survival of the Fittest",
					"Tempest Efreet",
					"Time Vault",
					"Time Walk", 
					"Timetwister", 
					"Timmerian Fiends", 
					"Tinker", 
					"Tolarian Academy", 
					"Treasure Cruise",
					"Unexpected Potential", 
					"Vampiric Tutor",
					"Wheel of Fortune", 
					"Windfall", 
					"Worldknit", 
					"Yawgmoth's Bargain", 
					"Yawgmoth's Will"
				};
				return list;
			}
		}
	}
}
