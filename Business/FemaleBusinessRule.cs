using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FemaleBusinessRule : IBusinessRule
    {
        private readonly Sex _sex;

        public FemaleBusinessRule(Sex sex)
        {
            _sex = sex;
        }

        public bool Evaluate()
        {
            return _sex == Sex.Female;
        }
    }
}
