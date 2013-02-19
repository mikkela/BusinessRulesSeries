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
    public class RuleListBasedInterestCalculatorTest : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void The_interest_rate_of_a_under_age_person_is_null(int age)
        {
            Assert.Null(new RuleListBasedInterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_interest_rate_of_a_young_person_is_25(int age)
        {
            Assert.Equal(25, new RuleListBasedInterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_interest_rate_of_a_middle_aged_person_is_15(int age)
        {
            Assert.Equal(15, new RuleListBasedInterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_interest_rate_of_an_old_person_is_20(int age)
        {
            Assert.Equal(20, new RuleListBasedInterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("UnderAge")]
        public void The_reason_for_interest_rate_of_a_under_age_person_is_as_defined(int age)
        {
            Assert.Equal("Because you are too young", new RuleListBasedInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_reason_for_interest_rate_of_a_young_person_is_as_defined(int age)
        {
            Assert.Equal("Because you will party before you pay", new RuleListBasedInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_reason_for_interest_rate_of_a_middle_aged_person_is_as_defined(int age)
        {
            Assert.Equal("Because you got family - we get security", new RuleListBasedInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_reason_for_interest_rate_of_an_old_person_is_as_defined(int age)
        {
            Assert.Equal("Because you are old", new RuleListBasedInterestCalculator().GetReason(age));
        }
    }
}
