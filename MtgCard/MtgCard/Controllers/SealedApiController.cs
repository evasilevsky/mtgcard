using MtgCard.Domain;
using MtgCard.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace MtgCard.Controllers
{
    public class SealedApiController : ApiController
    {
		public Pool GetPool()
		{
			var packs = new List<Pack>();
			var packFactory = new PackFactory(new CardAdapter());
			var pool = new Pool();
			for (int i = 0; i < 6; i++)
			{
				var pack = packFactory.BuildRandomPackFromSet("SOI");
				pool.AddPackToPool(pack);
			}
			return pool;
		}
	}
}
