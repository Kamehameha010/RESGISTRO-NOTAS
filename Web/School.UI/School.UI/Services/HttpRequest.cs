using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WsSchool.Core.Models;

namespace School.UI.Services
{
    public class HttpRequest<T> : IHttpRequest<T> where T : class, new()
    {
        private readonly IHttpResponse _response;
        private readonly HttpClient _httpClient;
        public HttpRequest(IHttpResponse response)
        {
            _response = response;
            _httpClient = new HttpClient();
        }
        public async Task<Response> Delete(string url) => await _response.GetResponse(await _httpClient.DeleteAsync(url));
        public async Task<Response> Get(string url) => await _response.GetResponse(await _httpClient.GetAsync(url));
        public async Task<Response> Post(T model, string url, int? id = null)
        {
            var data = new StringContent(JsonSerializer.Serialize(model));

            var requestUrl = $"{url}/{id?.ToString()}";

            return await _response.GetResponse(await _httpClient.PostAsync(requestUrl, data));
        }

        public async Task<Response> Put(int id, T model, string url)
        {
            var data = new StringContent(JsonSerializer.Serialize(model));
            return await _response.GetResponse(await _httpClient.PostAsync(url, data));
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
