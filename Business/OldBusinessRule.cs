namespace Business
{
    public class OldBusinessRule : AgeCategorizingBusinessRule
    {
        public OldBusinessRule(int currentAge)
            : base(currentAge, 66, 199)
        {
        }
    }
}