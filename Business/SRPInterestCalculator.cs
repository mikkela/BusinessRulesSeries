using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SRPInterestCalculator
    {
        public Tuple<int?, string> CalculateInterestAndReason(int age)
        {
            if (age < 18)
                return new Tuple<int?, string>(null, "Because you are too young");

            if (age <= 25)
                return new Tuple<int?, string>(25, "Because you will party before you pay");

            if (age <= 65)
                return new Tuple<int?, string>(15, "Because you got family - we get security");

            return new Tuple<int?, string>(20, "Because you are old");
        }
    }
}
