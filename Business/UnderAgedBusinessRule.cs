namespace Business
{
    public class UnderAgedBusinessRule : AgeCategorizingBusinessRule
    {
        public const int MinimumAgeValue = 0;
        public const int MaximumAgeValue = 17;
        public UnderAgedBusinessRule(int currentAge) : base(currentAge, MinimumAgeValue, MaximumAgeValue)
        {
        }
    }
}