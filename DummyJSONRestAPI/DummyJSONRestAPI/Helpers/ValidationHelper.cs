namespace DummyJSONRestAPI.Helpers
{
    public class ValidationHelper
    {
        public static bool IsValidLetter(string queryString)
        {
            // girilen queryString'in her karekterinin harf olduğunu kontrol eden loop
            bool isAllLetters = true;

            foreach (char c in queryString)
            {
                if (!char.IsLetter(c))
                {
                    isAllLetters = false;
                    break;
                }
            }

            if (isAllLetters)
                return true;
            return false;
        }
    }
}