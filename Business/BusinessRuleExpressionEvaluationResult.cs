using System.Collections.Generic;

namespace Business
{
    public class BusinessRuleExpressionEvaluationResult
    {
        private readonly bool _result;
        private readonly IEnumerable<Fact> _facts;

        public BusinessRuleExpressionEvaluationResult(bool result, IEnumerable<Fact> facts)
        {
            _result = result;
            _facts = facts;
        }

        public bool Result
        {
            get { return _result; }
        }

        public IEnumerable<Fact> Facts
        {
            get { return _facts; }
        }
    }
}