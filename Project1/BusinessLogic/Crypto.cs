using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject1.BusinessLogic
{
    public static class Crypto
    {
        public static string Hash(string pw)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(pw)));
        }
    }
}
