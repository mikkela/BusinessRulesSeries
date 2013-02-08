using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WatiN.Core;
using Xunit;

namespace AcceptanceTest
{
    [Binding]
    public class LoanApplicationStepDefinition
    {
        private WatiN.Core.IE browser;

        [Before]
        public void Before()
        {
            browser = new IE("http://localhost:1051/Application");
        }

        [After]
        public void After()
        {
            browser.Close();
        }

        [Given("I have entered (.*) into the age field")]
        public void GivenIHaveEnteredSomethingIntoTheAgeField(int age)
        {
            browser.TextField("Age").Value = age.ToString();
        }

        [When("I press submit")]
        public void WhenIPressSubmit()
        {
            browser.Button("Apply").Click();
        }

        [Then("the applicant is (accepted|rejected)")]
        public void ThenTheApplicantIs(string result)
        {
            Assert.True(result == "accepted"
                            ? browser.Div("Title").Text.Contains("The customer is accepted")
                            : browser.Div("Title").Text.Contains("The customer is rejected"));
        }

        [Then(@"the interest rate is (.*) %")]
        public void ThenTheInterestRateIs(int rate)
        {
            Assert.True(browser.Div("InterestRate").Text.Contains(rate + " %"));
        }

    }
}
