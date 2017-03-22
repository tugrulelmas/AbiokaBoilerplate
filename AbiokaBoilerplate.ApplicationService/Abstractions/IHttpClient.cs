using System.Net.Http;
using System.Threading.Tasks;

namespace AbiokaBoilerplate.ApplicationService.Abstractions
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
