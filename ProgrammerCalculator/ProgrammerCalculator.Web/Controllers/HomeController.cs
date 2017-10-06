using System.Web.Mvc;
using ProgrammerCalculator.Helpers.Contracts;
using ProgrammerCalculator.Helpers.Constants;

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

        public ActionResult InputNumber(string numberValue, string calcInput, int fromBase)
        {
            if (calcInput == GlobalConstants.LeadingZeroCharacter || this.calculatorService.IsOperatorSelected)
            {
                this.calculatorService.IsOperatorSelected = false;
                return this.Content(numberValue);
            }

            return this.Content(calcInput + numberValue);
        }

        public ActionResult Add(string calcInput, int fromBase)
        {
            var result = this.calculatorService.Add(calcInput, fromBase);

            return this.Content(result);
        }

        public ActionResult Subtract(string calcInput, int fromBase)
        {
            var result = this.calculatorService.Substract(calcInput, fromBase);

            return this.Content(result);
        }

        public ActionResult Multiply(string calcInput, int fromBase)
        {
            var result = this.calculatorService.Multiply(calcInput, fromBase);

            return this.Content(result);
        }

        public ActionResult Divide(string calcInput, int fromBase)
        {
            var result = this.calculatorService.Divide(calcInput, fromBase);

            return this.Content(result);
        }

        public ActionResult Evaluate(string calcInput, int fromBase)
        {
            var result = this.calculatorService.Evaluate(calcInput, fromBase);
            this.calculatorService.ResetResult();

            return this.Content(result.ToString());
        }

        public ActionResult ResetExpression()
        {
            this.calculatorService.ResetResult();
            return this.Content(GlobalConstants.LeadingZeroCharacter);
        }
    }
}