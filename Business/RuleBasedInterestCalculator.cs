using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RuleBasedInterestCalculator
    {
        public int? CalculateInterestRate(int age)
        {
            if (new UnderAgedBusinessRule(age).Evaluate())
                return null;

            if (new YoungBusinessRule(age).Evaluate())
                return 25;

            if (new MiddleAgedBusinessRule(age).Evaluate())
                return 15;

            if (new OldBusinessRule(age).Evaluate())
                return 20;

            throw new ArgumentException("Invalid age: " + age);
        }

        public string GetReason(int age)
        {
            if (new UnderAgedBusinessRule(age).Evaluate())
                return "Because you are too young";

            if (new YoungBusinessRule(age).Evaluate())
                return "Because you will party before you pay";

            if (new MiddleAgedBusinessRule(age).Evaluate())
                return "Because you got family - we get security";

            if (new OldBusinessRule(age).Evaluate())
                return "Because you are old";

            throw new ArgumentException("Invalid age: " + age);
        }
    }
}
