﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using System.Linq;
using System.Collections.Generic;
//Class used by the main form for encryption
public class Recrypt
{
  

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
        return (cipheredtext);
    }

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
