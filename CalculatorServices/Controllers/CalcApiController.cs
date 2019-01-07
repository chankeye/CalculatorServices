using CalculatorServices.Enums;
using CalculatorServices.Models;
using CalculatorServices.Utilites;
using System.Web.Mvc;

namespace CalculatorServices.Controllers
{
    public class CalcApiController : JsonNetController
    {
        [HttpPost]
        public ActionResult Add(double number1, double number2)
        {
            return GetJsonResult(CalcModule.Add(number1, number2));
        }

        [HttpPost]
        public ActionResult Subtract(double number1, double number2)
        {
            return GetJsonResult(CalcModule.Subtract(number1, number2));
        }

        [HttpPost]
        public ActionResult Multiply(double number1, double number2)
        {
            return GetJsonResult(CalcModule.Multiply(number1, number2));
        }

        [HttpPost]
        public ActionResult Divide(double number1, double number2)
        {
            return GetJsonResult(CalcModule.Divide(number1, number2));
        }

        private JsonResult GetJsonResult((ResultType resultCode, double result) calcResult)
        {
            switch (calcResult.resultCode)
            {
                case ResultType.Success:
                    return Json(new ApiResult<double>(calcResult.result));
                case ResultType.OverFlow:
                case ResultType.ZeroDivisor:
                    return Json(new ApiError(calcResult.resultCode.ToString(), calcResult.resultCode.GetDescription()));
                default:
                    return Json(new ApiError(ResultType.Unknown.ToString(), ResultType.Unknown.GetDescription()));
            }
        }
    }
}