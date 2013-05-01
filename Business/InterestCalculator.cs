using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class InterestCalculator : IInterestCalculator
    {
        private readonly int _age;
        private readonly Sex _sex;

        public InterestCalculator(int age, Sex sex)
        {
            _age = age;
            _sex = sex;
        }

        public PolicyResult<int?> CalculateInterest()
        {
            var policies = new[]
                {
                    new Policy<int?>(IsUnderaged(_age), null),
                    new Policy<int?>(IsFemale(_sex) && IsYoung(_age), 22),
                    new Policy<int?>(!IsFemale(_sex) & IsYoung(_age), 27),
                    new Policy<int?>(IsFemale(_sex) & IsMiddleAged(_age), 12),
                    new Policy<int?>(!IsFemale(_sex) & IsMiddleAged(_age), 17),
                    new Policy<int?>(IsFemale(_sex) & IsOld(_age), 17),
                    new Policy<int?>(!IsFemale(_sex) & IsOld(_age), 22),
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

        private BusinessRuleExpressionDSL IsFemale(Sex sex)
        {
            return new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(new FemaleBusinessRule(sex)));
        }

        private BusinessRuleExpressionDSL IsUnderaged(int age)
        {
            return new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(new UnderAgedBusinessRule(age)));
        }

        private BusinessRuleExpressionDSL IsYoung(int age)
        {
            return new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(new YoungBusinessRule(age)));
        }

        private BusinessRuleExpressionDSL IsMiddleAged(int age)
        {
            return new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(new MiddleAgedBusinessRule(age)));
        }

        private BusinessRuleExpressionDSL IsOld(int age)
        {
            return new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(new OldBusinessRule(age)));
        }

    }
}
