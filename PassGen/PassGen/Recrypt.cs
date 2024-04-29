using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using System.Linq;
using System.Collections.Generic;
//Class used by the main form for encryption

/// <summary>
/// Recrypt class has two methods Encrypt and Decrypt which takes three parameters a hash Key, an insertion vector, and the plaintext string that needs encrypted. The decrypt method works in reverse with the ciphertext.
/// </summary>
public class Recrypt
{
  
    /// <summary>
    /// The Encrypt method takes simpletext, an AES key, and an insertion vector (iv) and returns ciphered text.
    /// </summary>
    /// <param name="simpletext">the string to be encrypted</param>
    /// <param name="key">an AES key of 16 bits</param>
    /// <param name="iv">insertion vector of 16 bits</param>
    /// <returns>cipheredtext</returns>
    public static byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
    {

        byte[] cipheredtext;
      
        using (Aes aes = Aes.Create())
        {
            ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(simpletext);
                    }

                    cipheredtext = memoryStream.ToArray();
                }
            }
        }
        return cipheredtext;
    }
    /// <summary>
    /// The Decrypt class will take ciphered text and decrypts it utilizing the generated AES key and insertion vector (iv) that was created when the text was encrypted
    /// </summary>
    /// <param name="cipheredtext">the string to be decrypted</param>
    /// <param name="key">the AES key generated when string was encrypted</param>
    /// <param name="iv">the insertion vector generated when string was encrypted</param>
    /// <returns>simpletext decrypted from the provided key and vector</returns>
    public static string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv)
    {
        string simpletext = String.Empty;
        using (Aes aes = Aes.Create())
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

            using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamreader = new StreamReader(cryptoStream))
                    {
                        simpletext = streamreader.ReadToEnd();
                    }
                }
                
            }
        }
        return simpletext;
    } 
}
