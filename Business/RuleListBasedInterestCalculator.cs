using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RuleListBasedInterestCalculator
    {
        private List<Tuple<Func<int, IBusinessRule>, int?>> interestList = new List<Tuple<Func<int, IBusinessRule>, int?>>()
            {
                new Tuple<Func<int, IBusinessRule>, int?>( age => new UnderAgedBusinessRule(age), null),
                new Tuple<Func<int, IBusinessRule>, int?>( age => new YoungBusinessRule(age), 25),
                new Tuple<Func<int, IBusinessRule>, int?>( age => new MiddleAgedBusinessRule(age), 15),
                new Tuple<Func<int, IBusinessRule>, int?>( age => new OldBusinessRule(age), 20),
            };

        private List<Tuple<Func<int, IBusinessRule>, string>> reasonList = new List<Tuple<Func<int, IBusinessRule>, string>>()
            {
                new Tuple<Func<int, IBusinessRule>, string>( age => new UnderAgedBusinessRule(age), "Because you are too young"),
                new Tuple<Func<int, IBusinessRule>, string>( age => new YoungBusinessRule(age), "Because you will party before you pay"),
                new Tuple<Func<int, IBusinessRule>, string>( age => new MiddleAgedBusinessRule(age), "Because you got family - we get security"),
                new Tuple<Func<int, IBusinessRule>, string>( age => new OldBusinessRule(age), "Because you are old"),
            };


        public int? CalculateInterestRate(int age)
        {
            var match = interestList.FirstOrDefault(p => p.Item1(age).Evaluate());
            if (match == null)
                throw new ArgumentException("Invalid age: " + age);
            return match.Item2;
        }

        public string GetReason(int age)
        {
            var match = reasonList.FirstOrDefault(p => p.Item1(age).Evaluate());
            if (match == null)
                throw new ArgumentException("Invalid age: " + age);
            return match.Item2;
        }
    }
}
