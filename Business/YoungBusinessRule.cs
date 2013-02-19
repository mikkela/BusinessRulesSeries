namespace Business
{
    public class YoungBusinessRule : AgeCategorizingBusinessRule
    {
        public YoungBusinessRule(int currentAge)
            : base(currentAge, 18, 25)
        {
        }
    }
}