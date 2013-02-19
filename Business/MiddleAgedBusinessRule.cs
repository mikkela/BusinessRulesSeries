namespace Business
{
    public class MiddleAgedBusinessRule : AgeCategorizingBusinessRule
    {
        public MiddleAgedBusinessRule(int currentAge)
            : base(currentAge, 26, 65)
        {
        }
    }
}