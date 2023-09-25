using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.Framework
{
    public class SecurityProvider
    {
        public static byte[] GenerateKeyFromPassphrase(string passphrase)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(passphrase));
                return hash;
            }
        }

        public  static void GenerateKeyFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Serial");

            try
            {
                string content = HardwareSerial.GetHardDriveSerialNumber();

                File.WriteAllText(filePath, content);

                Console.WriteLine("File created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public static bool IsValidLicense()
        {
            try
            {
                string license = GetLicnese();
                string passphrase = "IMSV4IOS";
                byte[] encryptedKey = Convert.FromBase64String(license);
                byte[] cryptographicKey = GenerateKeyFromPassphrase(passphrase);

                string decryptedKey = DecryptKey(encryptedKey, cryptographicKey);
                string serialKey = HardwareSerial.GetHardDriveSerialNumber();
                if (decryptedKey == serialKey)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public static byte[] EncryptKey(string key, byte[] cryptographicKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = cryptographicKey;
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] encryptedBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                        cs.Write(keyBytes, 0, keyBytes.Length);
                    }
                    encryptedBytes = ms.ToArray();
                }

                return aes.IV.Concat(encryptedBytes).ToArray();
            }
        }

        public static string DecryptKey(byte[] encryptedData, byte[] cryptographicKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = cryptographicKey;

                byte[] iv = encryptedData.Take(16).ToArray();
                byte[] encryptedBytes = encryptedData.Skip(16).ToArray();

                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] decryptedBytes;
                using (MemoryStream ms = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            decryptedBytes = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                        }
                    }
                }

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
        public static string GetLicnese()
        {
            try
            {

                using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "License"))) 
                { 
                    string licenseKey = reader.ReadToEnd();
                    return licenseKey;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found, permissions, etc.)
                Console.WriteLine("An error occurred while reading the license file: " + ex.Message);
                return string.Empty; // or throw an exception
            }
        }
    }
}
