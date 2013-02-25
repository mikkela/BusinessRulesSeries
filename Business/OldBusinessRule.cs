namespace Business
{
    public class OldBusinessRule : AgeCategorizingBusinessRule
    {
        public const int MinimumAgeValue = 66;
        public const int MaximumAgeValue = 199;
        
        public OldBusinessRule(int currentAge)
            : base(currentAge, MinimumAgeValue, MaximumAgeValue)
        {
        }
    }
}