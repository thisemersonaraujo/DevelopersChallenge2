using System;
using System.Security.Cryptography;
using System.Text;

namespace BankingConciliation.AppService.Useful
{
    public class Cryptography
    {
        public string GetMD5(string content)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return CreateHash(md5Hash, content);
            }
        }

        public bool CompareMD5(string oldContent, string newContent)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var content = GetMD5(oldContent);
                if (CheckHash(md5Hash, newContent, content)) return true;
                else return false;
            }
        }

        private string CreateHash(MD5 md5Hash, string content)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(content));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        private bool CheckHash(MD5 md5Hash, string newContent, string content)
        {
            StringComparer _ = StringComparer.OrdinalIgnoreCase;

            if (0 == _.Compare(newContent, content)) return true;
            else return false;
        }
    }
}
