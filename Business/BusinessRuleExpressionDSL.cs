using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessRuleExpressionDSL
    {
        private BusinessRuleExpression expression;

        public BusinessRuleExpressionDSL(BusinessRuleExpression expression)
        {
            this.expression = expression;
        }

        public BusinessRuleExpression Expression
        {
            get { return expression; }
        }

        public static bool operator false(BusinessRuleExpressionDSL dsl)
        {
            return !dsl.Expression.Evaluate().Result;
        }

        public static bool operator true(BusinessRuleExpressionDSL dsl)
        {
            return dsl.Expression.Evaluate().Result;
        }

        public static implicit operator BusinessRuleExpression(BusinessRuleExpressionDSL dsl)
        {
            return dsl.Expression;
        }

        public static BusinessRuleExpressionDSL operator &(
            BusinessRuleExpressionDSL left, BusinessRuleExpressionDSL right)
        {
            return
                new BusinessRuleExpressionDSL(new AndBusinessRuleExpression(new[] {left.Expression, right.Expression}));
        }

        public static BusinessRuleExpressionDSL operator |(
            BusinessRuleExpressionDSL left, BusinessRuleExpressionDSL right)
        {
            return
                new BusinessRuleExpressionDSL(new OrBusinessRuleExpression(new[] {left.Expression, right.Expression}));
        }

        public static BusinessRuleExpressionDSL operator !(BusinessRuleExpressionDSL inner)
        {
            return
                new BusinessRuleExpressionDSL(new NotBusinessRuleExpression(inner));
        }
    }
}