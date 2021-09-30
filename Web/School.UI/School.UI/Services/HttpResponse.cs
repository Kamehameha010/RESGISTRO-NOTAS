using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;

namespace School.UI.Services
{
    public class HttpResponse<T> : IHttpResponse<T>
    {
        public async Task<Response<T>> GetResponse(HttpResponseMessage responseMessage)
        {
            var resp = await responseMessage.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Response<T>>(resp);
        }
    }
}
