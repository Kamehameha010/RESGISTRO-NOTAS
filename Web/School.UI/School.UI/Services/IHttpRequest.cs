using System;
using System.Threading.Tasks;
using WsSchool.Core.Models;

namespace School.UI.Services
{
    public interface IHttpRequest<T> : IDisposable where T : class, new()
    {
        Task<Response> Post(T model, string url, int? id =null);
        Task<Response> Put(int id, T model, string url);
        Task<Response> Get(string url);
        Task<Response> Delete(string url);
    }
}
