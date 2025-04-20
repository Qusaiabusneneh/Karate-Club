using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsHashing
    {
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256=SHA256.Create())
            {
                byte[] hashByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashByte).Replace("-", "").ToLower();
            }
        }
    }
}
