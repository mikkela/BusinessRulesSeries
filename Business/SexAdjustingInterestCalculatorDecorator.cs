using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class SexAdjustingInterestCalculatorDecorator : IInterestCalculator
    {
        private const int MaleAdjustment = 0;
        private const int FemaleAdjustement = 5;
        private readonly Sex _sex;
        private readonly IInterestCalculator _interestCalculator;

        private IEnumerable<DecoratingPolicy<int?, Sex>> _decoratingPolicies = new []
            {
                new DecoratingPolicy<int?, Sex>(policyResult => policyResult.Result == null, (policyResult, sex) => policyResult),
                new DecoratingPolicy<int?, Sex>(policyResult => true, (policyResult, sex) => sex == Sex.Female ? HandleFemale(policyResult) : HandleMale(policyResult))
            };

        private static PolicyResult<int?> HandleMale(PolicyResult<int?> policyResult)
        {
            return
                policyResult.UpdateResult(policyResult.Result - MaleAdjustment)
                            .AddFact(new Fact(new FemaleBusinessRule(Sex.Female), false));
        }

        private static PolicyResult<int?> HandleFemale(PolicyResult<int?> policyResult)
        {
            return
                policyResult.UpdateResult(policyResult.Result - FemaleAdjustement)
                            .AddFact(new Fact(new FemaleBusinessRule(Sex.Female), true));
        }


        public SexAdjustingInterestCalculatorDecorator(Sex sex, IInterestCalculator interestCalculator)
        {
            _sex = sex;
            _interestCalculator = interestCalculator;
        }

        public PolicyResult<int?> CalculateInterest()
        {
            var result = _interestCalculator.CalculateInterest();
            
            return result.Satisfied ? 
                Decorate(result) : 
                result;
        }

        private PolicyResult<int?> Decorate(PolicyResult<int?> result)
        {
            return _decoratingPolicies.First(p => p.IsPremiseSatisfied(result)).CreateResponse(result, _sex);
        }
    }
}
