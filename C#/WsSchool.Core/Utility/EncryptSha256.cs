using System.Security.Cryptography;
using System.Text;
using WsSchool.Core.Interfaces;

namespace WsSchool.Core.Utility
{
    public class EncryptSha256 : IEncrypt
    {
        public string EncryptString(string phrase)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(phrase));

            StringBuilder strBuilder = new StringBuilder();

            foreach (var str in bytes)
            {
                strBuilder.AppendFormat("{0:x2}", str);
            }
            return strBuilder.ToString();
        }
    }
}
