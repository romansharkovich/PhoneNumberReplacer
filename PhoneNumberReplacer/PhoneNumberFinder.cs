using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PhoneNumberReplacer
{
    public class PhoneNumberFinder
    {
        private string? content;
        public void ReplaceInFile(string filePath, string replaceText)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
                reader.Close();

                Regex regex = new Regex("[0-9]{3}-[0-9]{3}-[0-9]{4}");
                content = regex.Replace(content, replaceText);
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Close();
            }
        }

        public void FindMatches(string directory, string replaceText)
        {
            foreach (var filePath in Directory.GetFiles(directory, "*.html")) {
                ReplaceInFile(filePath, replaceText);
            }
        }

        //TODO
        /*public void FindMatchesParallel(string directory, string replaceText)
        {
            ParallelLoopResult result = Parallel.ForEach<string>(Directory.GetFiles(directory, "*.html"),
                ReplaceInFile;
        }*/
    }
}
