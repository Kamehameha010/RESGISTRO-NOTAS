using System;
using System.Threading.Tasks;

namespace WsSchool.Core.Interfaces
{
    public interface IUnitWork : IAsyncDisposable
    {
        Task SaveAsync();
    }
}
