using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReasonBasedInterestCalculator
    {
        public IEnumerable<string> GetReasonsForInterest(PolicyResult<int?> interest)
        {
            var reasonMap = new[]
                {
                    new {RuleType = typeof (UnderAgedBusinessRule), Value = true, Reason = "Because you are too young"},
                    new {RuleType = typeof (YoungBusinessRule), Value = true, Reason = "Because you will party before you pay"},
                    new {RuleType = typeof (MiddleAgedBusinessRule), Value = true, Reason = "Because you got family - we get security"},
                    new {RuleType = typeof (OldBusinessRule), Value = true, Reason = "Because you are old"},
                    new {RuleType = typeof (FemaleBusinessRule), Value = true, Reason = "You are a foxy lady"},
                    new {RuleType = typeof (FemaleBusinessRule), Value = false, Reason = "You are a dumb guy"}
                };

            return
                reasonMap.Where(p => interest.SupportingFacts.Any(q => q.BusinessRule.GetType() == p.RuleType && q.IsTrue == p.Value)).Select(p => p.Reason);
        }
    }
}