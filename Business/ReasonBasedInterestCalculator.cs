using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReasonBasedInterestCalculator
    {
        public string GetReasonForInterest(PolicyResult<int?> interest)
        {
            var reasonMap = new[]
                {
                    new {RuleType = typeof (UnderAgedBusinessRule), Reason = "Because you are too young"},
                    new {RuleType = typeof (YoungBusinessRule), Reason = "Because you will party before you pay"},
                    new {RuleType = typeof (MiddleAgedBusinessRule), Reason = "Because you got family - we get security"},
                    new {RuleType = typeof (OldBusinessRule), Reason = "Because you are old"}
                };

            return
                reasonMap.Where(p => p.RuleType == interest.SupportingRule.GetType()).Select(p => p.Reason).First();
        }

        public PolicyResult<int?> CalculateInterestRate(int age)
        {
            var policies = new[]
                {
                    new Policy<int?>(new UnderAgedBusinessRule(age), null),
                    new Policy<int?>(new YoungBusinessRule(age), 25),
                    new Policy<int?>(new MiddleAgedBusinessRule(age), 15),
                    new Policy<int?>(new OldBusinessRule(age), 20),
                };

            return EvaluatePolicies(policies)
                .FirstOrDefault();
        
        }

        private static IEnumerable<PolicyResult<TResult>> EvaluatePolicies<TResult>(IEnumerable<Policy<TResult>> policies)
        {
            return (from policy in policies
                    let application = policy.Apply()
                    where application.Satisfied
                    select application);
        }
    }
}