using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TFive_Class
{
    public class TFiveSecurity
    {
        #region En&De 1 / 8Keys

        public static string PasswordNeed8; // 8
        public static string EncryptString(string inputString)
        {
            string result;
            var str = PasswordNeed8;
            using (var descryptoServiceProvider = new DESCryptoServiceProvider())
            {
                if (!string.IsNullOrEmpty(inputString))
                {
                    var rgbIV = new byte[]
                    {
                        12,
                        21,
                        43,
                        17,
                        57,
                        35,
                        67,
                        27
                    };
                    var rgbKey = Encoding.UTF8.GetBytes(str);
                    inputString = inputString.Replace(" ", "+");
                    inputString = inputString.Replace('-', '+');
                    inputString = inputString.Replace('_', '/');
                    var bytes = Encoding.UTF8.GetBytes(inputString);
                    var memoryStream = new MemoryStream();
                    var transform = descryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
                    using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    result = Convert.ToBase64String(memoryStream.ToArray());
                }
                else
                {
                    result = null;
                }
            }

            return result;
        }
        public static string DecryptString(string inputString)
        {
            string result;
            var str = PasswordNeed8;
            using (var descryptoServiceProvider = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();
                var utf = Encoding.UTF8;
                if (!string.IsNullOrEmpty(inputString))
                {
                    byte[] rgbIV = {
                        12,
                        21,
                        43,
                        17,
                        57,
                        35,
                        67,
                        27
                    };
                    var rgbKey = Encoding.UTF8.GetBytes(str);
                    var array = Convert.FromBase64String(inputString);
                    using (var transform = descryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV))
                    {
                        CryptoStream cryptoStream;
                        using (cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(array, 0, array.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }
                    result = utf.GetString(memoryStream.ToArray());
                }
                else
                {
                    result = null;
                }
            }

            return result;
        }

        #endregion

        #region En&De 2 / 16Keys
        // Password16 must = (keysize / 8).  
        // Default keysize is 256, Password16 must be 32 bytes long.
        // Using a 16 character string here gives us 32 bytes when converted to a byte array.
        public static string Password16;

        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        //Encrypt
        public static string PasswordUp2You;
        public static string EncryptString2(string plainText)//, string PasswordUp2You)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(Password16);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes;
            using (var password = new PasswordDeriveBytes(PasswordUp2You, null))
            {
                keyBytes = password.GetBytes(keysize / 8);
            }

            ICryptoTransform encryptor;
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            }

            var memoryStream = new MemoryStream();
            byte[] cipherTextBytes;
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
            }

            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString2(string cipherText)//, string PasswordUp2You)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(Password16);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes;
            using (var password = new PasswordDeriveBytes(PasswordUp2You, null))
            {
                keyBytes = password.GetBytes(keysize / 8);
            }

            ICryptoTransform decryptor;
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            }

            var memoryStream = new MemoryStream(cipherTextBytes);
            byte[] plainTextBytes;
            int decryptedByteCount;
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                plainTextBytes = new byte[cipherTextBytes.Length];
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
            }

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        #endregion
    }
}
