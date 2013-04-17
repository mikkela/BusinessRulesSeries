using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class BusinessRuleExpression
    {
        public abstract BusinessRuleExpressionEvaluationResult Evaluate();
    }
}
