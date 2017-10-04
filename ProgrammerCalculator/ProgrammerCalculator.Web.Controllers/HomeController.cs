using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgrammerCalculator.Services.Infrastructure.Contracts;

namespace ProgrammerCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculator calculatorService;

        // Should probably add NummericBaseConverter to convert final result to active nummeric base
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

        // Validate number input to accept only certain values
        public ActionResult InputNumber(string numberValue, string calcInput)
        {
            return this.Content(calcInput + numberValue);
        }

        // Should pass => string buttonValue, int numberBase ( get number base from active radio button of avalaible bases )
        public ActionResult Add()
        {
            //this.calculatorService.Add(numberValue.ToString(), 10);
            return this.Content(string.Empty);
        }

        public ActionResult Subtract()
        {
            //this.calculatorService.Substract();
            return this.Content(string.Empty);
        }

        public ActionResult Multiply()
        {
            //this.calculatorService.Multiply();
            return this.Content(string.Empty);
        }

        public ActionResult Divide()
        {
            //this.calculatorService.Divide();
            return this.Content(string.Empty);
        }

        public ActionResult Evaluate()
        {
            //var result = this.calculatorService.CurrentResult;
            return this.Content(string.Empty);
        }
    }
}