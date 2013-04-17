using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReferenceBusinessRuleExpression : BusinessRuleExpression
    {
        private readonly IBusinessRule _businessRule;

        public ReferenceBusinessRuleExpression(IBusinessRule businessRule)
        {
            _businessRule = businessRule;
        }

        public override BusinessRuleExpressionEvaluationResult Evaluate()
        {
            var result = _businessRule.Evaluate();
            return new BusinessRuleExpressionEvaluationResult(result, new[] { new Fact(_businessRule, result), });
        }
    }
}
