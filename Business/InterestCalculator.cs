using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class InterestCalculator
    {
        public int? CalculateInterestRate(int age)
        {
            if (age < 18)
                return null;

            if (age <= 25)
                return 25;

            if (age <= 65)
                return 15;

            return 20;
        }
    }
}
