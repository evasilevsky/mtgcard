using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgCard.Domain.Formats
{
	public class Modern : Format, IBannable
	{
		public List<string> BannedList
		{
			get
			{
				var list = new List<string>
				{
					"Ancient Den",
					"Birthing Pod",
					"Blazing Shoal",
					"Bloodbraid Elf",
					"Chrome Mox",
					"Cloudpost",
					"Dark Depths",
					"Deathrite Shaman",
					"Dig Through Time",
					"Dread Return",
					"Eye of Ugin",
					"Glimpse of Nature",
					"Great Furnace",
					"Green Sun's Zenith",
					"Hypergenesis",
					"Jace, the Mind Sculptor",
					"Mental Misstep",
					"Ponder",
					"Preordain",
					"Punishing Fire",
					"Rite of Flame",
					"Seat of the Synod",
					"Second Sunrise",
					"Seething Song",
					"Sensei's Divining Top",
					"Skullclamp",
					"Splinter Twin",
					"Stoneforge Mystic",
					"Summer Bloom",
					"Treasure Cruise",
					"Tree of Tales",
					"Umezawa's Jitte",
					"Vault of Whispers"
				};
				return list;
			}
		}
	}
}
