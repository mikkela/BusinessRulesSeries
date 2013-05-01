using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReasonBasedInterestCalculator
    {
        public IEnumerable<string> GetReasonsForInterest(PolicyResult<int?> interest)
        {
            var reasonMap = new Dictionary<Predicate<Fact>, string>
                {
                    {IsSatisfied<UnderAgedBusinessRule>, "Because you are too young"},
                    {IsSatisfied<YoungBusinessRule>, "Because you will party before you pay"},
                    {IsSatisfied<MiddleAgedBusinessRule>, "Because you got family - we get security"},
                    {IsSatisfied<OldBusinessRule>, "Because you are old"},
                    {IsSatisfied<FemaleBusinessRule>, "You are a foxy lady"},
                    {IsNotSatisfied<FemaleBusinessRule>, "You are a dumb guy"}
                };

            return
                reasonMap.Where(p => interest.SupportingFacts.Any(q => p.Key(q))).Select(p => p.Value);
        }

        private static bool IsSatisfied<TRule>(Fact fact) where TRule : IBusinessRule
        {
            return fact.BusinessRule is TRule && fact.IsTrue;
        }

        private static bool IsNotSatisfied<TRule>(Fact fact) where TRule : IBusinessRule
        {
            return fact.BusinessRule is TRule && !fact.IsTrue;
        }
    }
}