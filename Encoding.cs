using System.Security.Cryptography;

namespace ott.core.encoding
{
    public class Encoding
    {
        public async Task<byte[]> Encrypt(string plainText)
        {
            byte[] key = new byte[32];
            byte[] iv = new byte[16];

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            await swEncrypt.WriteAsync(plainText);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public async Task<string> Decrypt(byte[] cipherText)
        {
            byte[] key = new byte[32];
            byte[] iv = new byte[16];

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return await srDecrypt.ReadToEndAsync();
                        }
                    }
                }
            }
        }
    }
}
