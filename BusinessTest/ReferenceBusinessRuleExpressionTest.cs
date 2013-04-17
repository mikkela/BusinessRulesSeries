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
    public class ReferenceBusinessRuleExpressionTest
    {
        [Fact]
        public void Evaluate_returns_a_result_with_Result_true_when_the_rules_evaluates_true()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(true);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.True(target.Evaluate().Result);
        }

        [Fact]
        public void Evaluate_returns_a_result_with_a_single_fact_when_the_rules_evaluates_true()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(true);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.Equal(1, target.Evaluate().Facts.Count());
        }

        [Fact]
        public void Evaluate_returns_a_result_with_Fact_thats_true_when_the_rules_evaluates_true()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(true);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.True(target.Evaluate().Facts.First().IsTrue);
        }

        [Fact]
        public void Evaluate_returns_a_result_with_Fact_thats_refers_to_the_rule_when_the_rules_evaluates_true()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(true);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.Equal(businessRule.Object, target.Evaluate().Facts.First().BusinessRule);
        }

        [Fact]
        public void Evaluate_returns_a_result_with_Result_false_when_the_rules_evaluates_false()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(false);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.False(target.Evaluate().Result);
        }

        [Fact]
        public void Evaluate_returns_a_result_with_a_single_fact_when_the_rules_evaluates_false()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(false);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.Equal(1, target.Evaluate().Facts.Count());
        }

        [Fact]
        public void Evaluate_returns_a_result_with_Fact_thats_false_when_the_rules_evaluates_false()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(false);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.False(target.Evaluate().Facts.First().IsTrue);
        }

        [Fact]
        public void Evaluate_returns_a_result_with_Fact_thats_refers_to_the_rule_when_the_rules_evaluates_false()
        {
            var businessRule = new Mock<IBusinessRule>();
            businessRule.Setup(p => p.Evaluate()).Returns(false);

            var target = new ReferenceBusinessRuleExpression(businessRule.Object);

            Assert.Equal(businessRule.Object, target.Evaluate().Facts.First().BusinessRule);
        }
    }
}
