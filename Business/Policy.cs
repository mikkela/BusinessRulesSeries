using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Policy<TResult>
    {
        public Policy(BusinessRuleExpression expression, TResult result)
        {
            Result = result;
            Expression = expression;
        }

        public BusinessRuleExpression Expression { get; private set; }
        public TResult Result { get; private set; }

        public PolicyResult<TResult> Apply()
        {
            var evaluation = Expression.Evaluate();
            return (evaluation.Result)
                       ? PolicyResult<TResult>.CreateSuccessResult(evaluation.Facts, Result)
                       : PolicyResult<TResult>.CreateFailureResult(evaluation.Facts);
        }
    }
}
