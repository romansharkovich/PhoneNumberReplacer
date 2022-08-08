using PhoneNumberReplacer;

namespace SmartParkWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string storagePath = "../htmlDir";
            const string phoneNumberFormat = "123-456-7899";

            var obj = new PhoneNumberFinder();
            obj.FindMatches(storagePath, phoneNumberFormat);
        }
    }
}