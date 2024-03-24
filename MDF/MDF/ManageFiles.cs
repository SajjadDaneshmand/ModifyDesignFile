using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WpfTestApp
{
    class ManageFiles : IManageFiles
    {
        public string OpenFile(string path)
        {
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                // Read the content from the file
                return reader.ReadToEnd();
            }
        }
        public void ReplaceInDesignFile(string filePath, bool toDot = true)
        {
            string content = OpenFile(filePath);

            for (int i = 0; i < 10; i++)
            {
                string strI = Convert.ToString(i);

                if (toDot)
                {
                    content = ReplaceToAll(content, $"{strI}/", $"{strI}.");
                }
                else
                {
                    content = ReplaceToAll(content, $"{strI}.", $"{strI}/");
                }
                SaveFile(filePath, content);

            }
        }


        public void SaveFile(string path, string content)
        {

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.Write(content);
            }


        }
        public string ReplaceToAll(string content, string input, string output)
        {
            while (content.Contains(input))
            {
                content = content.Replace(input, output);
            }
            return content;
        }
    }
}
