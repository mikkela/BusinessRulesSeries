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
            var result = PolicyResult<int>.CreateSuccessResult(new Fact[0], 42);

            Assert.True(result.Satisfied);
        }

        [Fact]
        public void CreateSuccessResult_returns_a_policy_result_with_SupportingFacts_as_the_given_facts()
        {
            var facts = new [] { new Fact(new Mock<IBusinessRule>().Object, true)};

            var result = PolicyResult<int>.CreateSuccessResult(facts, 42);

            Assert.Equal(facts, result.SupportingFacts);
        }

        [Fact]
        public void CreateSuccessResult_returns_a_policy_result_with_Result_as_the_given_result()
        {
            var result = PolicyResult<int>.CreateSuccessResult(new Fact[0], 42);

            Assert.Equal(42, result.Result);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_Satisfied_false()
        {
            var result = PolicyResult<int>.CreateFailureResult(new Fact[0]);

            Assert.False(result.Satisfied);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_SupportingFacts_as_the_given_rule()
        {
            var facts = new[] { new Fact(new Mock<IBusinessRule>().Object, true) };

            var result = PolicyResult<int>.CreateFailureResult(facts);

            Assert.Equal(facts, result.SupportingFacts);
        }

        [Fact]
        public void CreateFailureResult_returns_a_policy_result_with_Result_throwing_invalid_operation_exception()
        {
            var rule = new Mock<IBusinessRule>().Object;

            var result = PolicyResult<int>.CreateFailureResult(new Fact[0]);

            Assert.Throws<InvalidOperationException>(() => result.Result);
        }

        [Fact]
        public void UpdateResult_returns_a_new_instance_of_the_policy_result()
        {
            var target = PolicyResult<int>.CreateSuccessResult(new Fact[0], 75);

            Assert.NotSame(target, target.UpdateResult(67));
        }

        [Fact]
        public void UpdateResult_returns_a_policy_result_with_the_new_result()
        {
            const int newValue = 6554;
            var target = PolicyResult<int>.CreateSuccessResult(new Fact[0], newValue - 342);
            target = target.UpdateResult(newValue);

            Assert.Equal(newValue, target.Result);
        }

        [Fact]
        public void UpdateResult_returns_an_instance_with_the_same_supporting_business_rule_as_the_original()
        {
            var facts = new[] { new Fact(new Mock<IBusinessRule>().Object, true) };

            var target = PolicyResult<int>.CreateSuccessResult(facts, 75);
            target = target.UpdateResult(67);

            Assert.Same(facts, target.SupportingFacts);
        }

        [Fact]
        public void UpdateResult_cannot_be_called_on_a_failed_result()
        {
            var target = PolicyResult<int>.CreateFailureResult(new Fact[0]);
            
            Assert.Throws(typeof (InvalidOperationException), () => target.UpdateResult(67));
        }
    }
}
