using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OzSozluk.Common.Infrastructure
{
    public class PasswordEncryptor
    {
        public static string Encrypt(string password)
        {
            using var md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(password); //disaridan aldigimizi byte array yaptik
            byte[] hashBytes = md5.ComputeHash(inputBytes);       //hashledik

            return Convert.ToHexString(hashBytes);             //bunlari string yapip donduk
        }
    }
}
