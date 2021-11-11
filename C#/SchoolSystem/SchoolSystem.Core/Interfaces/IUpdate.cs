using System.Threading.Tasks;

namespace SchoolSystem.Core.Interfaces
{
    public interface IUpdate<T>
    {
        void Update(T model);
    }
}