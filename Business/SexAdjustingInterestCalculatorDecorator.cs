namespace Business
{
    public class SexAdjustingInterestCalculatorDecorator : IInterestCalculator
    {
        private const int MaleAdjustment = 0;
        private const int FemaleAdjustement = 5;
        private readonly Sex _sex;
        private readonly IInterestCalculator _interestCalculator;

        public SexAdjustingInterestCalculatorDecorator(Sex sex, IInterestCalculator interestCalculator)
        {
            _sex = sex;
            _interestCalculator = interestCalculator;
        }

        public PolicyResult<int?> CalculateInterest()
        {
            var result = _interestCalculator.CalculateInterest();
            
            return result.Satisfied ? 
                result.UpdateResult(DecorateResultValue(result)) : 
                result;
        }

        private int? DecorateResultValue(PolicyResult<int?> result)
        {
            int? resultValue = (result.Result.HasValue)
                                   ? AdjustAccordingToSex(result)
                                   : null;
            return resultValue;
        }

        private int? AdjustAccordingToSex(PolicyResult<int?> result)
        {
            return
                result.Result - LookupSexAdjustement();       
        }

        private int LookupSexAdjustement()
        {
            return _sex == Sex.Male ? MaleAdjustment : FemaleAdjustement;
        }
    }
}
