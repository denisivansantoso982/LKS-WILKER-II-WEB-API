using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Web_Api.Model
{
    public class EncryptionModel
    {
        public static string encryption(string data)
        {
            using (SHA256Managed managed = new SHA256Managed())
            {
                byte[] str = Encoding.UTF8.GetBytes(data);
                var encrypt = managed.ComputeHash(str);
                string result = Convert.ToBase64String(encrypt);

                return result;
            }
        }
    }
}