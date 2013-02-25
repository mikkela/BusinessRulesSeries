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
    }
}
