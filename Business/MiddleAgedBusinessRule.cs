namespace Business
{
    public class MiddleAgedBusinessRule : AgeCategorizingBusinessRule
    {
        public const int MinimumAgeValue = 26;
        public const int MaximumAgeValue = 65;
        
        public MiddleAgedBusinessRule(int currentAge)
            : base(currentAge, MinimumAgeValue, MaximumAgeValue)
        {
        }
    }
}