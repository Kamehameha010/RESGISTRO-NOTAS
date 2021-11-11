namespace SchoolSystem.Infrastructure.Interfaces
{
    public interface IPasswordService
    {
        string Encrypt(string pwd);
    }
}