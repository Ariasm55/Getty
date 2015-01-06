using System;
using System.Security.Cryptography;
using System.Text;

namespace Collective.Library
{
    public class Crypt
    {
        public static string Md5(string input)
        {
            try
            {
                using (var md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                    var sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    return sBuilder.ToString();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Crypt error",exception);
            }
        }
    }
}
