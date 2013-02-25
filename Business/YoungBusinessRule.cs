namespace Business
{
    public class YoungBusinessRule : AgeCategorizingBusinessRule
    {
        public const int MinimumAgeValue = 18;
        public const int MaximumAgeValue = 25;
        
        public YoungBusinessRule(int currentAge)
            : base(currentAge, MinimumAgeValue, MaximumAgeValue)
        {
        }
    }
}