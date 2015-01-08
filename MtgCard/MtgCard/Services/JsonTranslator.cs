using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MtgCard.Services
{
	public class JsonTranslator
	{
		public T Deserialize<T>(string content)
		{
			var result = JsonConvert.DeserializeObject<dynamic>(content);
			if (result != null && result["data"] != null)
			{
				content = JsonConvert.SerializeObject(result["data"]);
			}

			var deserializeObject = JsonConvert.DeserializeObject<T>(content);
			return deserializeObject;
		}

		public string Serialize(object objectToTranslate)
		{
			return JsonConvert.SerializeObject(objectToTranslate, (Formatting)Formatting.None, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), MissingMemberHandling = MissingMemberHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
		}
	}
}