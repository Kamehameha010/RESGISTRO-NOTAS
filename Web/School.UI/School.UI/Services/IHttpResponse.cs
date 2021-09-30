using System.Net.Http;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;

namespace School.UI.Services
{
    public interface IHttpResponse<T>
    {
        
        Task<Response<T>> GetResponse(HttpResponseMessage responseMessage);
    }
}
