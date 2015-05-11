using MtgCard.Domain;
using MtgCard.Services.Interfaces;

namespace MtgCard.Services
{
	public class ApplicationStateRepository : IApplicationStateRepository
	{
		public Draft Draft { get; set; }
	}
}
