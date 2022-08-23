namespace PhoneNumberReplacer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string storagePath = "../../../htmlDir";
            const string phoneNumberFormat = "123-456-7899";

            var obj = new PhoneNumberFinder();
            try
            {
                obj.FindMatches(storagePath, phoneNumberFormat, 10);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error reading the files: " + storagePath);
                Console.WriteLine(e.Message);
            }
        }
    }
}