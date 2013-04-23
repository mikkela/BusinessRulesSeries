using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AndBusinessRuleExpression : CompositeBusinessRuleExpression
    {
        public AndBusinessRuleExpression(IEnumerable<BusinessRuleExpression> parts) : base(parts)
        {
        }

        protected override bool Combine(IEnumerable<bool> results)
        {
            return results.Aggregate(true, (current, result) => current & result);
        }
    }
}
