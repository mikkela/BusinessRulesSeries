using System.Linq;
using Business;
using Moq;

namespace BusinessTest
{
    public static class PartHelper
    {
        public static BusinessRuleExpression CreatePart(bool result, params IBusinessRule[] rules)
        {
            var r = new Mock<BusinessRuleExpression>();
            r.Setup(p => p.Evaluate())
             .Returns(new BusinessRuleExpressionEvaluationResult(result,
                                                                 rules.Select(p => new Fact(p, result))));

            return r.Object;
        }
    }
}