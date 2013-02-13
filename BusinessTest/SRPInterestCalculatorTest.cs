﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Xunit;
using Xunit.Extensions;

namespace BusinessTest
{
    public class SRPInterestCalculatorTest : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void The_interest_rate_of_a_under_age_person_is_null(int age)
        {
            Assert.Null(new SRPInterestCalculator().CalculateInterestAndReason(age).Item1);
        }

        [Theory]
        [PropertyData("UnderAge")]
        public void The_reason_for_underage_is_as_designed(int age)
        {
            Assert.Equal("Because you are too young",
                new SRPInterestCalculator().CalculateInterestAndReason(age).Item2);
        }

        [Theory]
        [PropertyData("Young")]
        public void The_interest_rate_of_a_young_person_is_25(int age)
        {
            Assert.Equal(25, new SRPInterestCalculator().CalculateInterestAndReason(age).Item1);
        }

        [Theory]
        [PropertyData("Young")]
        public void The_reason_for_young_is_as_designed(int age)
        {
            Assert.Equal("Because you will party before you pay",
                new SRPInterestCalculator().CalculateInterestAndReason(age).Item2);
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_interest_rate_of_a_middle_aged_person_is_15(int age)
        {
            Assert.Equal(15, new SRPInterestCalculator().CalculateInterestAndReason(age).Item1);
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_reason_for_middle_aged_is_as_designed(int age)
        {
            Assert.Equal("Because you got family - we get security",
                new SRPInterestCalculator().CalculateInterestAndReason(age).Item2);
        }

        [Theory]
        [PropertyData("Old")]
        public void The_interest_rate_of_an_old_person_is_20(int age)
        {
            Assert.Equal(20, new SRPInterestCalculator().CalculateInterestAndReason(age).Item1);
        }

        [Theory]
        [PropertyData("Old")]
        public void The_reason_for_old_is_as_designed(int age)
        {
            Assert.Equal("Because you are old",
                new SRPInterestCalculator().CalculateInterestAndReason(age).Item2);
        }
    }
}