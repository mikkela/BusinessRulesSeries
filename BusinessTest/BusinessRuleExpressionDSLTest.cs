using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Moq;
using Xunit;

namespace BusinessTest
{
    public class BusinessRuleExpressionDSLTest
    {
        [Fact]
        public void And_with_first_operation_evaluating_to_false_returns_both_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(false);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) &
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 2 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)) &&
                        result.Facts.Any(p => p.BusinessRule.Equals(rule2.Object)));

        }

        [Fact]
        public void Shortcurcuit_And_with_first_operation_evaluating_to_false_returns_first_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(false);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) &&
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 1 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)));

        }

        [Fact]
        public void Shortcurcuit_And_with_first_operation_evaluating_to_true_returns_both_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(true);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) &&
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 2 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)) &&
                        result.Facts.Any(p => p.BusinessRule.Equals(rule2.Object)));
        }

        [Fact]
        public void Or_with_first_operation_evaluating_to_true_returns_both_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(true);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) |
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 2 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)) &&
                        result.Facts.Any(p => p.BusinessRule.Equals(rule2.Object)));

        }

        [Fact]
        public void Shortcurcuit_Or_with_first_operation_evaluating_to_true_returns_first_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(true);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) ||
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 1 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)));

        }

        [Fact]
        public void Shortcurcuit_Or_with_first_operation_evaluating_to_false_returns_both_parts_as_the_result()
        {
            var rule1 = new Mock<IBusinessRule>();
            var rule2 = new Mock<IBusinessRule>();
            rule1.Setup(p => p.Evaluate()).Returns(false);
            rule2.Setup(p => p.Evaluate()).Returns(false);

            var target = new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule1.Object)) ||
                         new BusinessRuleExpressionDSL(new ReferenceBusinessRuleExpression(rule2.Object));
            var result = target.Expression.Evaluate();

            Assert.True(result.Facts.Count() == 2 && result.Facts.Any(p => p.BusinessRule.Equals(rule1.Object)) &&
                        result.Facts.Any(p => p.BusinessRule.Equals(rule2.Object)));

        }

    }
}
