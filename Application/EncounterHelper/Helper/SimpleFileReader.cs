using System;
using System.IO;
using System.Linq.Expressions;

namespace Helper
{
    public static class SimpleFileReader
    {
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