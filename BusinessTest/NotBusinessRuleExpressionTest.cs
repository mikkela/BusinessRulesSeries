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
    public class NotBusinessRuleExpressionTest
    {
        private static readonly IBusinessRule rule = new Mock<IBusinessRule>().Object;
        
        [Fact]
        public void Original_evaluates_to_false_then_true_is_returned()
        {
            var originalPart = PartHelper.CreatePart(false, rule);
            var target = new NotBusinessRuleExpression(originalPart);

            var result = target.Evaluate();

            Assert.True(result.Result);
        }

        [Fact]
        public void Original_evaluates_to_false_then_the_original_fact_list_is_returned()
        {
            var originalPart = PartHelper.CreatePart(false, rule);
            var target = new NotBusinessRuleExpression(originalPart);

            var result = target.Evaluate();

            Assert.Equal(new []{ new Fact(rule, false)}, result.Facts);
        }

        [Fact]
        public void Original_evaluates_to_true_then_false_is_returned()
        {
            var originalPart = PartHelper.CreatePart(true, rule);
            var target = new NotBusinessRuleExpression(originalPart);

            var result = target.Evaluate();

            Assert.False(result.Result);
        }

        [Fact]
        public void Original_evaluates_to_true_then_the_original_fact_list_is_returned()
        {
            var originalPart = PartHelper.CreatePart(true, rule);
            var target = new NotBusinessRuleExpression(originalPart);

            var result = target.Evaluate();

            Assert.Equal(new[] { new Fact(rule, true) }, result.Facts);
        }
    }
}
