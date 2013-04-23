using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrBusinessRuleExpression : CompositeBusinessRuleExpression
    {
        public OrBusinessRuleExpression(IEnumerable<BusinessRuleExpression> parts)
            : base(parts)
        {
        }

        protected override bool Combine(IEnumerable<bool> results)
        {
            return results.Aggregate(false, (current, result) => current | result);
        }

    }
}
