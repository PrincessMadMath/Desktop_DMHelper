using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Helper
{
    public static class FileHelper
    {
        public static List<string> GetAllFilesInDirectoryAndSubDirectories(string path, string pattern)
        {
            String[] allfiles = Directory.GetFiles(path, pattern, System.IO.SearchOption.AllDirectories);
            return allfiles.ToList();
        }

        public static string ReadFile(string path)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }
    }
}