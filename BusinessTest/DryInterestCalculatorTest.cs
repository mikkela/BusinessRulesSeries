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
    public class DryInterestCalculatorTest  : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void The_reason_for_underage_is_as_designed(int age)
        {
            Assert.Equal("Because you are too young", 
                new DryInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_reason_for_young_is_as_designed(int age)
        {
            Assert.Equal("Because you will party before you pay",
                new DryInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_reason_for_middle_aged_is_as_designed(int age)
        {
            Assert.Equal("Because you got family - we get security",
                new DryInterestCalculator().GetReason(age));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_reason_for_old_is_as_designed(int age)
        {
            Assert.Equal("Because you are old",
                new DryInterestCalculator().GetReason(age));
        }
    }
}
