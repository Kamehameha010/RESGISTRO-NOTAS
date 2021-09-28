using System.Net.Http;
using System.Threading.Tasks;
using WsSchool.Core.Models;

namespace School.UI.Services
{
    public interface IHttpResponse
    {
        Task<Response> GetResponse(HttpResponseMessage responseMessage);
    }
}
