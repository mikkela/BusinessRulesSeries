using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class InterestCalculator : IInterestCalculator
    {
        private readonly int age;

        public InterestCalculator(int age)
        {
            this.age = age;
        }

        public PolicyResult<int?> CalculateInterest()
        {
            var policies = new[]
                {
                    new Policy<int?>(new UnderAgedBusinessRule(age), null),
                    new Policy<int?>(new YoungBusinessRule(age), 27),
                    new Policy<int?>(new MiddleAgedBusinessRule(age), 17),
                    new Policy<int?>(new OldBusinessRule(age), 22),
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
