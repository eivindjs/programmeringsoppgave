using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace projectcsharp
{
    /// <summary>
    /// Tord
    /// Her blir passord til nye brukere kryptert.
    /// Ved login sjekkes passord mot database via denne klassen.
    /// </summary>
    public static class Encryption
    { //nøkler som er nødvendig for å hashe
        static readonly string PasswordHash = "P@@Sw0rdH@$h1ng";
        static readonly string SaltKey = "$@LT&K3Y";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        //"dekrypterer"
        public static bool Decrypt(string userpass, string databasepass)
        {
            string decryption = Encrypt(userpass);
            if (decryption == databasepass)
            {
                return true;
            }
            else
                return false;
        }
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
    }
}