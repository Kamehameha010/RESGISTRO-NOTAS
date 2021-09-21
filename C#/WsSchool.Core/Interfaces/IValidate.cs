namespace WsSchool.Core.Interfaces
{
    internal interface IValidate<T, U>
        where T : class
        where U : class
    {
        T Validate(U model);
    }
}
