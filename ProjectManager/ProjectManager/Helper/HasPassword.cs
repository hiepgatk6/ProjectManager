using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Helper
{
    public static class HasPassword
    {
        public static string HashPass(string pass)
        {

            var sha256 = SHA256.Create();
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "");
                // Print the string.   
                return hash;
            }
        }
    }
    public static class BienToanCuc
    {
        public static int ID = 1;
        public static string AccountName = "Hiep";
        public static string Password = "123456";
        public static int Role = 1;
        public static string Email = "TranHiep@gmail.com";
        public static string FullName = "Trần Xuân Hiệp";
        public static string Phone = "0927023645";
        public static string ImagePath;


    }
}
