using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MtgCard.App.Services
{
	public class CustomHandler1 : DelegatingHandler
	{
		protected async override Task<HttpResponseMessage> SendAsync(
	   HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// Process the HttpRequestMessage object here.
			Debug.WriteLine("Processing request in Custom Handler 1");

			// Once processing is done, call DelegatingHandler.SendAsync to pass it on the 
			// inner handler.
			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

			// Process the incoming HttpResponseMessage object here.
			Debug.WriteLine("Processing response in Custom Handler 1");

			return response;
		}
	}
}
