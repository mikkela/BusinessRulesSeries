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
    public class AndBusinessRuleExpressionTest
    {
        private static readonly IBusinessRule rule1 = new Mock<IBusinessRule>().Object;
        private static readonly IBusinessRule rule2 = new Mock<IBusinessRule>().Object;
        
        [Fact]
        public void two_parts_that_both_evaluates_to_true_gives_a_true()
        {
            var part1 = PartHelper.CreatePart(true, rule1);
            var part2 = PartHelper.CreatePart(true, rule2);

            var target = new AndBusinessRuleExpression(new[] {part1, part2});

            Assert.True(target.Evaluate().Result);
        }

        [Fact]
        public void two_parts_that_both_evaluates_to_true_gives_a_list_of_two_facts()
        {
            var part1 = PartHelper.CreatePart(true, rule1);
            var part2 = PartHelper.CreatePart(true, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.Equal(new [] {new Fact(rule1, true), new Fact(rule2, true),  }, target.Evaluate().Facts);
        }

        [Fact]
        public void two_parts_first_is_true_second_is_false_evaluates_to_false_gives_a_true()
        {
            var part1 = PartHelper.CreatePart(true, rule1);
            var part2 = PartHelper.CreatePart(false, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.False(target.Evaluate().Result);
        }

        [Fact]
        public void two_parts_first_is_true_second_is_false_gives_a_list_of_two_facts()
        {
            var part1 = PartHelper.CreatePart(true, rule1);
            var part2 = PartHelper.CreatePart(false, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.Equal(new[] { new Fact(rule1, true), new Fact(rule2, false), }, target.Evaluate().Facts);
        }

        [Fact]
        public void two_parts_first_is_false_second_is_true_gives_a_false()
        {
            var part1 = PartHelper.CreatePart(false, rule1);
            var part2 = PartHelper.CreatePart(true, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.False(target.Evaluate().Result);
        }

        [Fact]
        public void two_parts_first_is_false_second_is_true_gives_a_list_of_two_facts()
        {
            var part1 = PartHelper.CreatePart(false, rule1);
            var part2 = PartHelper.CreatePart(true, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.Equal(new[] { new Fact(rule1, false), new Fact(rule2, true), }, target.Evaluate().Facts);
        }

        [Fact]
        public void two_parts_that_both_evaluates_to_false_gives_a_false()
        {
            var part1 = PartHelper.CreatePart(false, rule1);
            var part2 = PartHelper.CreatePart(false, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.False(target.Evaluate().Result);
        }

        [Fact]
        public void two_parts_that_both_evaluates_to_false_gives_a_list_of_two_facts()
        {
            var part1 = PartHelper.CreatePart(false, rule1);
            var part2 = PartHelper.CreatePart(false, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.Equal(new[] { new Fact(rule1, false), new Fact(rule2, false), }, target.Evaluate().Facts);
        }

        [Fact]
        public void two_parts_with_overlapping_facts_are_oonly_represented_once()
        {
            var part1 = PartHelper.CreatePart(false, rule1, rule2);
            var part2 = PartHelper.CreatePart(false, rule2);

            var target = new AndBusinessRuleExpression(new[] { part1, part2 });

            Assert.Equal(new[] { new Fact(rule1, false), new Fact(rule2, false), }, target.Evaluate().Facts);
        }
    }
}
