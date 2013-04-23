using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Xunit.Extensions;
using Business;

namespace BusinessTest
{
    public class SexAdjustingInterestCalculatorDecoratorTest
    {
        [Fact]
        public void CalculateInterest_returns_the_transfered_result_if_failure()
        {
            var result = PolicyResult<int?>.CreateFailureResult(new Fact[] { });
            var component = new Mock<IInterestCalculator>();
            component.Setup(p => p.CalculateInterest()).Returns(result);

            var target = new SexAdjustingInterestCalculatorDecorator(Sex.Female, component.Object);

            Assert.Same(result, target.CalculateInterest());
        }

        [Fact]
        public void CalculateInterest_returns_null_if_the_inner_result_is_null()
        {
            var component = new Mock<IInterestCalculator>();
            component.Setup(p => p.CalculateInterest()).Returns(PolicyResult<int?>.CreateSuccessResult(new Fact[] { }, null));
            
            var target = new SexAdjustingInterestCalculatorDecorator(Sex.Female, component.Object);

            Assert.Null(target.CalculateInterest().Result);
        }

        [Fact]
        public void CalculateInterest_returns_the_result_without_modifications_if_the_sex_is_male()
        {
            const int interestRate = 24;
            var component = new Mock<IInterestCalculator>();
            component.Setup(p => p.CalculateInterest()).Returns(PolicyResult<int?>.CreateSuccessResult(new Fact[] { }, interestRate));

            var target = new SexAdjustingInterestCalculatorDecorator(Sex.Male, component.Object);

            Assert.Equal(interestRate, target.CalculateInterest().Result);
        }

        [Fact]
        public void CalculateInterest_returns_the_result_minus_5_percent_point_if_the_sex_is_female()
        {
            const int interestRate = 24;
            var component = new Mock<IInterestCalculator>();
            component.Setup(p => p.CalculateInterest()).Returns(PolicyResult<int?>.CreateSuccessResult(new Fact[] { }, interestRate));

            var target = new SexAdjustingInterestCalculatorDecorator(Sex.Female, component.Object);

            Assert.Equal(19, target.CalculateInterest().Result);
        }

        [Fact]
        public void CalculateInterest_returns_a_satisfied_policy_result_if_the_inner_result_is_satisfied()
        {
            var component = new Mock<IInterestCalculator>();
            component.Setup(p => p.CalculateInterest()).Returns(PolicyResult<int?>.CreateSuccessResult(new Fact[] { }, null));

            var target = new SexAdjustingInterestCalculatorDecorator(Sex.Female, component.Object);

            Assert.True(target.CalculateInterest().Satisfied);
        }
    }
}
