

using System.Threading.Tasks;


namespace SchoolSystem.UI.Interfaces
{
    public interface IRequestServices
    {
        Task<ApiResponse<object>> Post();
        Task<ApiResponse<object>> Put();
        Task<ApiResponse<object>> Delete();
        Task<ApiResponse<object>> Get();
    }

    public class ApiResponse<T>
    {
    }
}