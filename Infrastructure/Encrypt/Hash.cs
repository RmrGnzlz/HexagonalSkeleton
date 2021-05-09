using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Encrypt
{
    public static class Hash
    {
        public static string GetSha256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            foreach (var t in stream)
                sb.AppendFormat("{0:x2}", t);
            return sb.ToString();
        }
    }
}