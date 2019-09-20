using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text; 

namespace GHMS.Core.Helper
{

    public class EncryptionHelper
    {
        private static string keyString = "VeR1f^m^B@nk5_Templ@r:0123456789";
        public static string DecryptString(string encrString)
        {
            var fullCipher = Convert.FromBase64String(encrString);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        public static string EnryptString(string strEncrypted)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(strEncrypted);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }



        //public static string DecryptString(string encrString)
        //{
        //    if (String.IsNullOrEmpty(encrString))
        //        return encrString;
        //    byte[] b;
        //    string decrypted;
        //    try
        //    {
        //        b = Convert.FromBase64String(encrString);
        //        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
        //    }
        //    catch (FormatException fe)
        //    {
        //        decrypted = "";
        //    }
        //    return decrypted;
        //}

        //public static string EnryptString(string strEncrypted)
        //{
        //    if (String.IsNullOrEmpty(strEncrypted))
        //        return strEncrypted;
        //    byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
        //    string encrypted = Convert.ToBase64String(b);
        //    return encrypted;
        //}
    }
}
