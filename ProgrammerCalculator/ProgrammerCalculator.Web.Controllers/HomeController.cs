using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgrammerCalculator.Services.Contacts;

namespace ProgrammerCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculator calculatorService;

        public HomeController(ICalculator calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Should pass => string buttonValue, int numberBase ( get number base from active radio button of avalaible bases )
        // Also validate number input to accept only certain values
        public ActionResult InputNumber(int numberValue)
        {
            //this.calculatorService.Add(numberValue.ToString(), 10);
            return this.Content(numberValue.ToString());
        }
    }
}