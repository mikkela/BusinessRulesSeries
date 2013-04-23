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
    public class PolicyTest
    {
        [Fact]
        public void Ctor_Expression_is_initialized_correctly()
        {
            var expression = new Mock<BusinessRuleExpression>().Object;

            var target = new Policy<int>(expression, 23);

            Assert.Equal(expression, target.Expression);
        }

        [Fact]
        public void Ctor_Result_is_initialized_correctly()
        {
            const int result = 453;

            var target = new Policy<int>(new Mock<BusinessRuleExpression>().Object, result);

            Assert.Equal(result, target.Result);
        }

        [Fact]
        public void Apply_returns_a_policy_result_with_success_if_the_business_rule_evaluates_to_true()
        {
            var expression = new Mock<BusinessRuleExpression>();
            expression.Setup(p => p.Evaluate()).Returns(new BusinessRuleExpressionEvaluationResult(true, new Fact[0]));

            var target = new Policy<int>(expression.Object, 45);
            var result = target.Apply();

            Assert.True(result.Satisfied);
        }

        [Fact]
        public void Apply_returns_a_policy_result_without_success_if_the_business_rule_evaluates_to_false()
        {
            var expression = new Mock<BusinessRuleExpression>();
            expression.Setup(p => p.Evaluate()).Returns(new BusinessRuleExpressionEvaluationResult(true, new Fact[0]));


            var target = new Policy<int>(expression.Object, 45);
            var result = target.Apply();

            Assert.False(result.Satisfied);
        }
    }
}
