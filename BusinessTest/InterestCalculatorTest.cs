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
    public class InterestCalculatorTest
    {
        private class AgeGenerator : IEnumerable<object[]>
        {
            private readonly int _from;
            private readonly int _to;

            public AgeGenerator(int from, int to)
            {
                _from = @from;
                _to = to;
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                for(int i = _from; i <= _to; i++)
                {
                    yield return new object[] {i};
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        [Theory]
        [PropertyData("UnderAge")]
        public void The_interest_rate_of_a_under_age_person_is_null(int age)
        {
            Assert.Null(new InterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("Young")]
        public void The_interest_rate_of_a_young_person_is_25(int age)
        {
            Assert.Equal(25, new InterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void The_interest_rate_of_a_middle_aged_person_is_15(int age)
        {
            Assert.Equal(15, new InterestCalculator().CalculateInterestRate(age));
        }

        [Theory]
        [PropertyData("Old")]
        public void The_interest_rate_of_an_old_person_is_20(int age)
        {
            Assert.Equal(20, new InterestCalculator().CalculateInterestRate(age));
        }

        public static IEnumerable<object[]> UnderAge
        {
            get
            {
                return new AgeGenerator(0, 17);
            }
        }

        public static IEnumerable<object[]> Young
        {
            get
            {
                return new AgeGenerator(18, 25);
            }
        }

        public static IEnumerable<object[]> MiddleAged
        {
            get
            {
                return new AgeGenerator(26, 65);
            }
        }

        public static IEnumerable<object[]> Old
        {
            get
            {
                return new AgeGenerator(66, 165);
            }
        }
    }
}
