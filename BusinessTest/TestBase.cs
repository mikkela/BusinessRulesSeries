using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for (int i = _from; i <= _to; i++)
                {
                    yield return new object[] { i };
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
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
