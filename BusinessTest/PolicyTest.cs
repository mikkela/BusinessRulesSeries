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
        public void Ctor_Rule_is_initialized_correctly()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var target = new Policy<int>(rule, 23);

            Assert.Equal(rule, target.Rule);
        }

        [Fact]
        public void Ctor_Result_is_initialized_correctly()
        {
            var result = 453;

            var target = new Policy<int>(new Mock<IBusinessRule>().Object, result);

            Assert.Equal(result, target.Result);
        }

        [Fact]
        public void Apply_returns_a_policy_result_with_success_if_the_business_rule_evaluates_to_true()
        {
            var rule = new Mock<IBusinessRule>();
            rule.Setup(p => p.Evaluate()).Returns(true);

            var target = new Policy<int>(rule.Object, 45);
            var result = target.Apply();

            Assert.True(result.Satisfied);
        }

        [Fact]
        public void Apply_returns_a_policy_result_without_success_if_the_business_rule_evaluates_to_false()
        {
            var rule = new Mock<IBusinessRule>();
            rule.Setup(p => p.Evaluate()).Returns(false);

            var target = new Policy<int>(rule.Object, 45);
            var result = target.Apply();

            Assert.False(result.Satisfied);
        }
    }
}
