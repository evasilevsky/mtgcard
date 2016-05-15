using MtgCard.Domain;
using MtgCard.Services.Interfaces;

namespace MtgCard.Services
{
	public class ApplicationStateRepository : IApplicationStateRepository
	{
		public Draft Draft { get; set; }
        public static int CommonsPerPack
        {
            get
            {
                return 10;
            }
        }
        public static int UncommonsPerPack
        {
            get
            {
                return 3;
            }
        }

        public static int PacksPerDraft { get
            {
                return 3;
            }
        }
    }
}
