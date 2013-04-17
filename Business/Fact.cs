using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Fact
    {
        private readonly IBusinessRule _businessRule;
        private readonly bool _isTrue;

        public Fact(IBusinessRule businessRule, bool isTrue)
        {
            _businessRule = businessRule;
            _isTrue = isTrue;
        }

        public IBusinessRule BusinessRule
        {
            get { return _businessRule; }
        }

        public bool IsTrue
        {
            get { return _isTrue; }
        }
    }
}
