namespace WEEK1QUIZ.src 
{
    public class Palindrome
    {
        public string Name { get; set; }

        public static bool Check(Palindrome item)
        {
            var Lower = item.Name.ToLower();
            var Backwards = "";

            Lower = Lower.Replace(" ", "");
            Lower = Lower.Replace(".", "");
            Lower = Lower.Replace("?", "");
            Lower = Lower.Replace("!", "");

            for (int i = Lower.Length - 1; i >= 0; i--)
            {
                Backwards += Lower[i];
            }

            if (Lower == Backwards)
            {
                return true;
            }
            return false;
        }
    }
}