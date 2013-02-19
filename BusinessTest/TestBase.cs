using System.Collections;
using System.Collections.Generic;
using Business;

namespace BusinessTest
{
    public class TestBase 
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

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public static IEnumerable<object[]> UnderAge
        {
            get
            {
                return new AgeGenerator(UnderAgedBusinessRule.MinimumAgeValue, UnderAgedBusinessRule.MaximumAgeValue);
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
                return new AgeGenerator(66, 199);
            }
        }
    }
}