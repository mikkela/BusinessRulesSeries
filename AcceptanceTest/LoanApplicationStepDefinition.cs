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

        [Given("I have chosen the sex to be '(male|female)'")]
        public void GivenIHaveChosenASex(string sex)
        {
            if (sex == "male")
            {
                browser.RadioButton("Male").Checked = true;
                browser.RadioButton("Female").Checked = false;
            }
            else {
                browser.RadioButton("Male").Checked = false;
                browser.RadioButton("Female").Checked = true;
            }
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

        [Then(@"the reason is '(.*)'")]
        public void ThenTheReasonIsTProvideLoansToMinors(string reason)
        {
            Assert.True(browser.Div("Reason").Text.Contains(reason));
        }

    }
}
