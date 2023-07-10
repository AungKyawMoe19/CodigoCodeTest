using System;
using System.Security.Cryptography;
using System.Text;

namespace InfraStructure.Utils
{
    public static class Controller_TextEncryption
    {
        //public const string cryptoKey = "ssbdcdecrypto";
        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        //Encryption string

        public static string Encrypt(string s, string key)
        {

            if (key == "") key = "dbpwdencrypt";
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;
            try
            {
                //  byte[] buffer = Encoding.ASCII.GetBytes(s);
                byte[] buffer = Encoding.Unicode.GetBytes(s);

                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                //des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                des.Key = MD5.ComputeHash(Encoding.Unicode.GetBytes(key));
                des.IV = IV;
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));

            }
            catch
            {
                throw;
            }

            return result;
        }

        // Decryption string

        public static string Decrypt(string s, string key)
        {
            try
            {

                if (key == "") key = "dbpwdencrypt";
                if (s == null || s.Length == 0) return string.Empty;

                string result = string.Empty;

                try
                {
                    byte[] buffer = Convert.FromBase64String(s);

                    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                    MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                    //  des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
                    des.Key = MD5.ComputeHash(Encoding.Unicode.GetBytes(key));
                    des.IV = IV;
                    //  result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                    result = Encoding.Unicode.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                }
                catch
                {
                    throw;
                }

                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Generate_password()
        {
            Random random = new Random();
            int rnum = random.Next(100, 999);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(2, false));
            builder.Append(rnum);
            builder.Append(RandomString(1, true));
            return builder.ToString();

        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


        //public static string getRandomNumber()
        //{
        //    Random random = new Random(100000);
        //    string randomNumber = (random.Next(999, 9999)).ToString("D6");
        //    return randomNumber;
        //}
        public static string getRandomNumber()
        {
            int minimum = 999;
            int maximum = 999999;
            int count = 1;
            int[] ret = new int[count];
            Random rand = new Random();
            double groupSize = ((maximum - minimum) / count);
            if (groupSize < 1) throw new ArgumentOutOfRangeException("count", "Count is too large for given range.");
            for (int i = 0; i < count; ++i)
            {
                ret[i] = rand.Next((int)(i * groupSize) + minimum, (int)((i + 1) * groupSize + minimum));
            }

            string ram_num = ret[0].ToString();
            return ram_num;
        }

    }
}