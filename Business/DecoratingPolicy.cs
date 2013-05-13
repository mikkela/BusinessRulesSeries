using System;

namespace Business
{
    public class DecoratingPolicy<TResult, TContext> 
    {
        private readonly Func<PolicyResult<TResult>, bool> _premise;
        private readonly Func<PolicyResult<TResult>, TContext, PolicyResult<TResult>> _response;

        public DecoratingPolicy(Func<PolicyResult<TResult>, bool> premise,
                                Func<PolicyResult<TResult>, TContext, PolicyResult<TResult>> response)
        {
            _premise = premise;
            _response = response;
        }

        public bool IsPremiseSatisfied(PolicyResult<TResult> policyResult)
        {
            return _premise(policyResult);
        }

        public PolicyResult<TResult> CreateResponse(PolicyResult<TResult> policyResult, TContext context)
        {
            return _response(policyResult, context);
        }
    }
}