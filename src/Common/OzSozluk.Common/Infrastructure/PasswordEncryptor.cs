using System.Security.Cryptography;
using System.Text;

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
