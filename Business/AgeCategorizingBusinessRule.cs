namespace Business
{
    public abstract class AgeCategorizingBusinessRule : BusinessRule
    {
        protected AgeCategorizingBusinessRule(int currentAge, int minimumAge, int maximumAge)
        {
            CurrentAge = currentAge;
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
        }

        public int CurrentAge { get; private set; }
        public int MinimumAge { get; private set; }
        public int MaximumAge { get; private set; }

        public bool Evaluate()
        {
            return 
                MinimumAge <= CurrentAge && 
                CurrentAge <= MaximumAge;
        }
    }
}