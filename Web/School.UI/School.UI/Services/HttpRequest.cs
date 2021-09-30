using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WsSchool.Core.Models;

namespace School.UI.Services
{
    public class HttpRequest<T,I> : IHttpRequest<T,I> where I : class, new()
    {
        private readonly IHttpResponse<T> _response;
        private readonly HttpClient _httpClient;
        public HttpRequest(IHttpResponse<T> response)
        {
            _response = response;
            _httpClient = new HttpClient();
        }
        public async Task<Response<T>> Delete(string url) => await _response.GetResponse(await _httpClient.DeleteAsync(url));
        public async Task<Response<T>> Get(string url) => await _response.GetResponse(await _httpClient.GetAsync(url));
        public async Task<Response<T>> Post(I model, string url, int? id = null)
        {
            var data = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var requestUrl = $"{url}/{id?.ToString()}";

            return await _response.GetResponse(await _httpClient.PostAsync(requestUrl, data));
        }
        public async Task<Response<T>> Put(int id, I model, string url)
        {
            var data = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _response.GetResponse(await _httpClient.PostAsync(url, data));
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
