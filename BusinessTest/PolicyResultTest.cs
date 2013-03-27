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
    public class PolicyResultTest
    {
        [Fact]
        public void CreateSuccessResult_returns_a_policy_result_with_Satisfied_true()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateSuccessResult(rule, 42);

            Assert.True(result.Satisfied);
        }

        [Fact]
        public void CreateSuccessResult_returns_a_policy_result_with_SupportingRule_as_the_given_rule()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateSuccessResult(rule, 42);

            Assert.Equal(rule, result.SupportingRule);
        }

        [Fact]
        public void CreateSuccessResult_returns_a_policy_result_with_Result_as_the_given_result()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateSuccessResult(rule, 42);

            Assert.Equal(42, result.Result);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_Satisfied_false()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateFailureResult(rule);

            Assert.False(result.Satisfied);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_SupportingRule_as_the_given_rule()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateFailureResult(rule);

            Assert.Equal(rule, result.SupportingRule);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_Result_throwing_invalid_operation_exception()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateFailureResult(rule);

            Assert.Throws<InvalidOperationException>(() => result.Result);
        }

        [Fact]
        public void UpdateResult_returns_a_new_instance_of_the_policy_result()
        {
            var target = PolicyResult<int>.CreateSuccessResult(new Mock<IBusinessRule>().Object, 75);

            Assert.NotSame(target, target.UpdateResult(67));
        }

        [Fact]
        public void UpdateResult_returns_a_policy_result_with_the_new_result()
        {
            const int newValue = 6554;
            var target = PolicyResult<int>.CreateSuccessResult(new Mock<IBusinessRule>().Object, newValue-342);
            target = target.UpdateResult(newValue);

            Assert.Equal(newValue, target.Result);
        }

        [Fact]
        public void UpdateResult_returns_an_instance_with_the_same_supporting_business_rule_as_the_original()
        {
            var businessRule = new Mock<IBusinessRule>().Object;
            var target = PolicyResult<int>.CreateSuccessResult(businessRule, 75);
            target = target.UpdateResult(67);

            Assert.Same(businessRule, target.SupportingRule);
        }

        [Fact]
        public void UpdateResult_cannot_be_called_on_a_failed_result()
        {
            var target = PolicyResult<int>.CreateFailureResult(new Mock<IBusinessRule>().Object);
            
            Assert.Throws(typeof (InvalidOperationException), () => target.UpdateResult(67));
        }
    }
}
