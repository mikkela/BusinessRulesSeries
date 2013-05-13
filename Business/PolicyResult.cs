using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class PolicyResult<TResult>
    {
        private readonly TResult _result;

        private PolicyResult(TResult result)
        {
            _result = result;
        }
  
        public bool Satisfied { get; private set; }

        public IEnumerable<Fact> SupportingFacts { get; private set; }

        public TResult Result
        {
            get
            {
                if (Satisfied)
                    return _result;
                throw new InvalidOperationException("Can not obtain result on an failed policy result");
            }
        }

        public PolicyResult<TResult> UpdateResult(TResult newResult)
        {
            if (!Satisfied)
                throw new InvalidOperationException("The result of a failed policy result can not be updated");
            
            return CreateSuccessResult(SupportingFacts, newResult);
        }

        public PolicyResult<TResult> AddFact(Fact newFact)
        {
            if (!Satisfied)
                throw new InvalidOperationException("The facts of a failed policy result can not be updated");

            return CreateSuccessResult(SupportingFacts.Union(new [] {newFact}), Result);
        }


        public static PolicyResult<TResult> CreateSuccessResult(IEnumerable<Fact> supportingFacts , TResult result)
        {
            return new PolicyResult<TResult>(result)
                {
                    SupportingFacts = supportingFacts,
                    Satisfied = true
                };
        }

        public static PolicyResult<TResult> CreateFailureResult(IEnumerable<Fact> supportingFacts)
        {
            return new PolicyResult<TResult>(default(TResult))
                {
                    Satisfied = false,
                    SupportingFacts = supportingFacts
                };
        }
    }
}