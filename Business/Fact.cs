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

        protected bool Equals(Fact other)
        {
            return _businessRule.Equals(other._businessRule) && _isTrue.Equals(other._isTrue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fact) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_businessRule.GetHashCode()*397) ^ _isTrue.GetHashCode();
            }
        }
    }
}
