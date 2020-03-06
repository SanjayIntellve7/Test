using System;
using System.IO;
using System.Security.Cryptography;

namespace AMS.Broker.IntegrationService
{
    public class Encryption
    {
 
        public void Encrypt(MemoryStream inputImage, string outputfilePath)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            using (Aes encryptor = Aes.Create())
            {
                try
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            int data;
                            while ((data = inputImage.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                           
                        }
                    }

                }
                catch (Exception e)
                {
                }
            }
        }
    }
  }

