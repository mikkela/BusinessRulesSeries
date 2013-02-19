using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace LoanApplication.Controllers
{
    public class ApplicationController : Controller
    {
        //
        // GET: /Application/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Apply(int? age)
        {
            var interest = new ReasonBasedInterestCalculator().CalculateInterestRate(age ?? 0);
            var interestRate = interest.Item1;
            if (interestRate.HasValue)
            {
                ViewBag.Title = "The customer is accepted";
                ViewBag.InterestRate = string.Format("The interest rate is set to: {0} %", interestRate.Value);
            }
            else
            {
                ViewBag.Title = "The customer is rejected";
                ViewBag.InterestRate = "No interest rate is provided";
            }

            ViewBag.Reason = new ReasonBasedInterestCalculator().GetReasonForInterest(interest).Item1;
            return View();
        }
    }
}
