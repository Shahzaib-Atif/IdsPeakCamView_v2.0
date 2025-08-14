namespace ImageProcessingLibrary.Services
{
    using ImageProcessingLibrary.Helpers;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class DataProtector
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("214365AB214365AB"); // Must be 16, 24, or 32 bytes
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("214365AB214365AB");   // Must be 16 bytes

        /// <summary> Encrypts a plain text string using AES and returns a Base64 string. </summary>
        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cs))
            {
                writer.Write(plainText);
                writer.Flush();  // Ensure data is written to CryptoStream
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary> Decrypts a Base64-encoded AES string and returns the original text. </summary>
        public static string Decrypt(string encryptedText, string fieldName = "")
        {
            try
            {
                using Aes aes = Aes.Create();
                aes.Key = Key;
                aes.IV = IV;

                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using var ms = new MemoryStream(Convert.FromBase64String(encryptedText));
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var reader = new StreamReader(cs);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                ExceptionHelper.DisplayErrorMessage($"An error occured while decrypting {fieldName} info:" +
                    $"\n\"{ex.Message}\"");
                return string.Empty;
            }
        }
    }
}
