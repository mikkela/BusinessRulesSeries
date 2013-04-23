using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class NotBusinessRuleExpression : DecoratorBusinessRuleExpression
    {
        public NotBusinessRuleExpression(BusinessRuleExpression inner) : base(inner)
        {
        }

        protected override IEnumerable<Fact> ModifyFacts(IEnumerable<Fact> originalFacts)
        {
            return originalFacts;
        }

        protected override bool ModifyResult(bool originalResult)
        {
            return !originalResult;
        }
    }
}
