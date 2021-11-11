using System;
using System.Security.Cryptography;
using System.Text;
using SchoolSystem.Infrastructure.Interfaces;

namespace SchoolSystem.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string Encrypt(string pwd)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(pwd));
            return Convert.ToBase64String(bytes);
        }
    }
}