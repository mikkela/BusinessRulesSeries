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
        private readonly Sex _sex;

        public InterestCalculator(int age, Sex sex)
        {
            this.age = age;
            _sex = sex;
        }

        public PolicyResult<int?> CalculateInterest()
        {
            var policies = new[]
                {
                    new Policy<int?>(new ReferenceBusinessRuleExpression(new UnderAgedBusinessRule(age)), null),
                    new Policy<int?>(new AndBusinessRuleExpression(new [] { new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex)), new ReferenceBusinessRuleExpression(new YoungBusinessRule(age)) }), 22),
                    new Policy<int?>(new AndBusinessRuleExpression(new BusinessRuleExpression[] { new NotBusinessRuleExpression(new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex))), new ReferenceBusinessRuleExpression(new YoungBusinessRule(age)) }), 27),
                    new Policy<int?>(new AndBusinessRuleExpression(new [] { new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex)), new ReferenceBusinessRuleExpression(new MiddleAgedBusinessRule(age)) }), 12),
                    new Policy<int?>(new AndBusinessRuleExpression(new BusinessRuleExpression[] { new NotBusinessRuleExpression(new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex))), new ReferenceBusinessRuleExpression(new MiddleAgedBusinessRule(age)) }), 17),
                    new Policy<int?>(new AndBusinessRuleExpression(new [] { new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex)), new ReferenceBusinessRuleExpression(new OldBusinessRule(age)) }), 17),
                    new Policy<int?>(new AndBusinessRuleExpression(new BusinessRuleExpression[] { new NotBusinessRuleExpression(new ReferenceBusinessRuleExpression(new FemaleBusinessRule(_sex))), new ReferenceBusinessRuleExpression(new OldBusinessRule(age)) }), 22),
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
