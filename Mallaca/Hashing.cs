using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mallaca
{
    public class Hashing
    {
        public static String CreateSHA256(String value)
        {
            var crypt = new SHA256Managed();
            var hash = String.Empty;
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value), 0, Encoding.UTF8.GetByteCount(value));

            return crypto.Aggregate(hash, (current, bit) => current + bit.ToString("x2"));
        }
    }
}
