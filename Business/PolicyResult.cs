using System;

namespace Business
{
    public class PolicyResult<TResult>
    {
        private TResult result;

        private PolicyResult(TResult result)
        {
            this.result = result;
        }
  
        public bool Satisfied { get; private set; }

        public IBusinessRule SupportingRule { get; private set; }

        public TResult Result
        {
            get
            {
                if (Satisfied)
                    return result;
                throw new InvalidOperationException("Can not obtain result on an failed policy result");
            }
        }

        public static PolicyResult<TResult> CreateSuccessResult(IBusinessRule businessRule, TResult result)
        {
            return new PolicyResult<TResult>(result)
                {
                    SupportingRule = businessRule,
                    Satisfied = true
                };
        }

        public static PolicyResult<TResult> CreateFailureResult(IBusinessRule businessRule)
        {
            return new PolicyResult<TResult>(default(TResult))
                {
                    Satisfied = false,
                    SupportingRule = businessRule
                };
        }
    }
}