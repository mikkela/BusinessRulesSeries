using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReasonBasedInterestCalculator
    {
        public Tuple<string, IBusinessRule> GetReasonForInterest(Tuple<int?, IBusinessRule> interest)
        {
            var reasonMap = new[]
                {
                    new {RuleType = typeof (UnderAgedBusinessRule), Reason = "Because you are too young"},
                    new {RuleType = typeof (YoungBusinessRule), Reason = "Because you will party before you pay"},
                    new {RuleType = typeof (MiddleAgedBusinessRule), Reason = "Because you got family - we get security"},
                    new {RuleType = typeof (OldBusinessRule), Reason = "Because you are old"}
                };

            return
                new Tuple<string, IBusinessRule>(
                    reasonMap.Where(p => p.RuleType == interest.Item2.GetType()).Select(p => p.Reason).First(),
                    interest.Item2);
        }

        public Tuple<int?, IBusinessRule> CalculateInterestRate(int age)
        {
            var policies = new[]
                {
                    new Policy<int?>(new UnderAgedBusinessRule(age), null),
                    new Policy<int?>(new YoungBusinessRule(age), 25),
                    new Policy<int?>(new MiddleAgedBusinessRule(age), 15),
                    new Policy<int?>(new OldBusinessRule(age), 20),
                };

            return EvaluatePolicies(policies)
                .Select(p => new Tuple<int?, IBusinessRule>(p.Result, p.SupportingRule))
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