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
        private static bool inExpression = false;

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
            if (calcInput == "0" || inExpression)
            {
                inExpression = false;
                return this.Content(numberValue);
            }

            return this.Content(calcInput + numberValue);
        }

        // Should pass => string buttonValue, int numberBase ( get number base from active radio button of avalaible bases )
        public ActionResult Add(string calcInput)
        {
            var result = this.calculatorService.Add(calcInput, 10);

            if (result > long.Parse(calcInput))
            {
                inExpression = true;
            }

            return this.Content(result.ToString());
        }

        public ActionResult Subtract(string calcInput)
        {
            var result = this.calculatorService.Substract(calcInput, 10);

            if (this.calculatorService.LastOperator != Services.Infrastructure.Enumerations.OperatorType.None)
            {
                inExpression = true;
            }

            return this.Content(result.ToString());
        }

        public ActionResult Multiply(string calcInput)
        {
            var result = this.calculatorService.Multiply(calcInput, 10);

            if (this.calculatorService.LastOperator != Services.Infrastructure.Enumerations.OperatorType.None)
            {
                inExpression = true;
            }

            return this.Content(result.ToString());
        }

        public ActionResult Divide(string calcInput)
        {
            var result = this.calculatorService.Divide(calcInput, 10);

            if (this.calculatorService.LastOperator != Services.Infrastructure.Enumerations.OperatorType.None)
            {
                inExpression = true;
            }

            return this.Content(result.ToString());
        }

        public ActionResult Evaluate(string calcInput)
        {
            var result = this.calculatorService.Evaluate(calcInput, 10);
            this.calculatorService.ResetResult();

            return this.Content(result.ToString());
        }

        public ActionResult ResetExpression()
        {
            this.calculatorService.ResetResult();
            return this.Content("0");
        }
    }
}