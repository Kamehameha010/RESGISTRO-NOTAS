using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WsSchool.Core.Models;

namespace School.UI.Services
{
    public class HttpResponse : IHttpResponse
    {
        public async Task<Response> GetResponse(HttpResponseMessage responseMessage)
        {
            var resp = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Response>(resp);
        }
    }
}
