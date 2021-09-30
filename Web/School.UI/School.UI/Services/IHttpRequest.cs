using System;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;

namespace School.UI.Services
{
    public interface IHttpRequest<T,I> : IDisposable where I : class, new()
    {
        Task<Response<T>> Post(I model, string url, int? id =null);
        Task<Response<T>> Put(int id, I model, string url);
        Task<Response<T>> Get(string url);
        Task<Response<T>> Delete(string url);
    }
}
