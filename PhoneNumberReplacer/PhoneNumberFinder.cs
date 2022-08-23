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

        public void FindMatches(string directory, string replaceText, int maxTries)
        {
            foreach (var filePath in Directory.GetFiles(directory, "*.html", SearchOption.AllDirectories)) {
                var count = 0;
                while (count < maxTries) {
                    try {
                        ReplaceInFile(filePath, replaceText);
                        return;
                    } catch (Exception e) {
                        if (++count == maxTries) {
                            Console.WriteLine($"There was an error of reading or writing the file: {filePath} !");
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }
    }
}
