using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class CompositeBusinessRuleExpression : BusinessRuleExpression
    {
        private IEnumerable<BusinessRuleExpression> parts;

        protected CompositeBusinessRuleExpression(IEnumerable<BusinessRuleExpression> parts)
        {
            this.parts = parts;
        }

        public override BusinessRuleExpressionEvaluationResult Evaluate()
        {
            var evaluationResults = parts.Select(p => p.Evaluate());
            IEnumerable<Fact> facts = new List<Fact>();
            facts = evaluationResults.Aggregate(facts, (current, evaluationResult) => current.Union(evaluationResult.Facts));
            return new BusinessRuleExpressionEvaluationResult(Combine(evaluationResults.Select(p => p.Result)), facts);
        }

        protected abstract bool Combine(IEnumerable<bool> results);
    }
}
