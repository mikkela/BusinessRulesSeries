using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ReasonBasedInterestCalculator
    {
        public Tuple<string, IBusinessRule> GetReasonForInterest(Tuple<int?, IBusinessRule> interest)
        {
            var reasonMap = new[]
                {
                    new {Rule = typeof (UnderAgedBusinessRule), Reason = "Because you are too young"},
                    new {Rule = typeof (YoungBusinessRule), Reason = "Because you will party before you pay"},
                    new {Rule = typeof (MiddleAgedBusinessRule), Reason = "Because you got family - we get security"},
                    new {Rule = typeof (OldBusinessRule), Reason = "Because you are old"}
                };

            return
                new Tuple<string, IBusinessRule>(
                    reasonMap.Where(p => p.Rule == interest.Item2.GetType()).Select(p => p.Reason).First(),
                    interest.Item2);
        }

        public Tuple<int?, IBusinessRule> CalculateInterestRate(int age)
        {
            Tuple<bool, IBusinessRule> isApplicantAccepted = IsApplicantAccepted(age);
            if (!isApplicantAccepted.Item1)
                return new Tuple<int?, IBusinessRule>(null, isApplicantAccepted.Item2);

            var interestMap = new[]
                {
                    new {Rule = typeof (YoungBusinessRule), Rate = 25},
                    new {Rule = typeof (MiddleAgedBusinessRule), Rate = 15},
                    new {Rule = typeof (OldBusinessRule), Rate = 20}
                };

            return
                new Tuple<int?, IBusinessRule>(
                    interestMap.Where(p => p.Rule == isApplicantAccepted.Item2.GetType()).Select(p => p.Rate).First(),
                    isApplicantAccepted.Item2);
        }

        public Tuple<bool, IBusinessRule> IsApplicantAccepted(int age)
        {
            var acceptRules = new IBusinessRule[]
                {new YoungBusinessRule(age), new MiddleAgedBusinessRule(age), new OldBusinessRule(age)};
            var rejectRules = new IBusinessRule[] {new UnderAgedBusinessRule(age),};

            return EvaluateStatement(acceptRules, rejectRules);
        }

        private Tuple<bool, IBusinessRule> EvaluateStatement(IEnumerable<IBusinessRule> acceptRules,
                                                             IEnumerable<IBusinessRule> rejectRules)
        {
            IBusinessRule acceptMatch = acceptRules.FirstOrDefault(p => p.Evaluate());
            if (acceptMatch != null)
                return new Tuple<bool, IBusinessRule>(true, acceptMatch);
            IBusinessRule rejectMatch = rejectRules.FirstOrDefault(p => p.Evaluate());
            if (rejectMatch != null)
                return new Tuple<bool, IBusinessRule>(false, rejectMatch);

            throw new ArgumentException("No rules accepting or rejecting the statement");
        }
    }
}