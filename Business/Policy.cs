using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Policy<TResult>
    {
        public Policy(IBusinessRule rule, TResult result)
        {
            Result = result;
            Rule = rule;
        }

        public IBusinessRule Rule { get; private set;  }
        public TResult Result { get; private set; }

        public PolicyResult<TResult> Apply()
        {
            return (Rule.Evaluate())
                       ? PolicyResult<TResult>.CreateSuccessResult(Rule, Result)
                       : PolicyResult<TResult>.CreateFailureResult(Rule);
        }
    }
}
