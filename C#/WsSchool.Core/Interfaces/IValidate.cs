namespace WsSchool.Core.Interfaces
{
#nullable enable
    public interface IValidate<T>
        where T : class   
    {
        T? Validate(T model);
    }
#nullable disable
}
