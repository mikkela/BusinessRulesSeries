using System.Collections.Generic;

namespace Business
{
    public abstract class DecoratorBusinessRuleExpression : BusinessRuleExpression
    {
        private BusinessRuleExpression inner;

        protected DecoratorBusinessRuleExpression(BusinessRuleExpression inner)
        {
            this.inner = inner;
        }

        public override BusinessRuleExpressionEvaluationResult Evaluate()
        {
            var result = inner.Evaluate();
            return new BusinessRuleExpressionEvaluationResult(ModifyResult(result.Result), ModifyFacts(result.Facts));
        }

        protected abstract bool ModifyResult(bool originalResult);
        protected abstract IEnumerable<Fact> ModifyFacts(IEnumerable<Fact> originalFacts);
    }
}