using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Xunit;
using Xunit.Extensions;

namespace BusinessTest
{
    public class InterestCalculatorTest : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void The_interest_rate_of_a_under_age_female_is_null(int age)
        {
            Assert.Null(new InterestCalculator(age, Sex.Female).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("UnderAge")]
        public void The_interest_rate_of_a_under_age_male_is_null(int age)
        {
            Assert.Null(new InterestCalculator(age, Sex.Male).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("Young")]
        public void The_interest_rate_of_a_young_female_is_22(int age)
        {
            Assert.Equal(22, new InterestCalculator(age, Sex.Female).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("Young")]
        public void The_interest_rate_of_a_young_male_is_27(int age)
        {
            Assert.Equal(27, new InterestCalculator(age, Sex.Male).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_interest_rate_of_a_middle_aged_female_is_12(int age)
        {
            Assert.Equal(12, new InterestCalculator(age, Sex.Female).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_interest_rate_of_a_middle_aged_male_is_17(int age)
        {
            Assert.Equal(17, new InterestCalculator(age, Sex.Male).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("Old")]
        public void The_interest_rate_of_an_old_female_is_17(int age)
        {
            Assert.Equal(17, new InterestCalculator(age, Sex.Female).CalculateInterest().Result);
        }

        [Theory]
        [PropertyData("Old")]
        public void The_interest_rate_of_an_old_male_is_22(int age)
        {
            Assert.Equal(22, new InterestCalculator(age, Sex.Male).CalculateInterest().Result);
        }
    }
}
