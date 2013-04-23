using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Xunit;
using Xunit.Extensions;

namespace BusinessTest
{
    public class ReasonBasedInterestCalculatorTest : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void The_reason_for_interest_rate_of_a_under_age_female_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new [] {"Because you are too young"}, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Female).CalculateInterest()));
        }

        [Theory]
        [PropertyData("UnderAge")]
        public void The_reason_for_interest_rate_of_a_under_age_male_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you are too young" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Male).CalculateInterest()));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_reason_for_interest_rate_of_a_young_female_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you will party before you pay", "You are a foxy lady" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Female).CalculateInterest()));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_reason_for_interest_rate_of_a_young_male_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you will party before you pay", "You are a dumb guy" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Male).CalculateInterest()));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_reason_for_interest_rate_of_a_middle_aged_female_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you got family - we get security", "You are a foxy lady" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Female).CalculateInterest()));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_reason_for_interest_rate_of_a_middle_aged_male_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you got family - we get security", "You are a dumb guy" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Male).CalculateInterest()));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_reason_for_interest_rate_of_a_old_female_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you are old", "You are a foxy lady" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Female).CalculateInterest()));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_reason_for_interest_rate_of_a_old_male_is_as_defined(int age)
        {
            var target = new ReasonBasedInterestCalculator();
            Assert.Equal(new[] { "Because you are old", "You are a dumb guy" }, target.GetReasonsForInterest(new InterestCalculator(age, Sex.Male).CalculateInterest()));
        }
    }
}
