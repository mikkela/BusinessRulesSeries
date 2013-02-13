using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DryInterestCalculator : InterestCalculator
    {
        public string GetReason(int age)
        {
            if (age < 18)
                return "Because you are too young";

            if (age <= 25)
                return "Because you will party before you pay";

            if (age <= 65)
                return "Because you got family - we get security";

            return "Because you are old";
        }
    }
}
