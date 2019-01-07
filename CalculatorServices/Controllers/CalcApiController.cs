using CalculatorServices.DTOs;
using CalculatorServices.Enums;
using CalculatorServices.Models;
using CalculatorServices.Utilites;
using System;
using System.Web.Mvc;

namespace CalculatorServices.Controllers
{
    public class CalcApiController : JsonNetController
    {
        [HttpPost]
        public ActionResult Add(decimal number1, decimal number2)
        {
            Logger().Debug($"number1: {number1}, number2: {number2}");

            var calcModule = new CalcModule();
            return GetJsonResult(calcModule.Add(number1, number2));
        }

        [HttpPost]
        public ActionResult Subtract(decimal number1, decimal number2)
        {
            Logger().Debug($"number1: {number1}, number2: {number2}");

            var calcModule = new CalcModule();
            return GetJsonResult(calcModule.Subtract(number1, number2));
        }

        [HttpPost]
        public ActionResult Multiply(decimal number1, decimal number2)
        {
            Logger().Debug($"number1: {number1}, number2: {number2}");

            var calcModule = new CalcModule();
            return GetJsonResult(calcModule.Multiply(number1, number2));
        }

        [HttpPost]
        public ActionResult Divide(decimal number1, decimal number2)
        {
            Logger().Debug($"number1: {number1}, number2: {number2}");

            var calcModule = new CalcModule();
            return GetJsonResult(calcModule.Divide(number1, number2));
        }

        private JsonResult GetJsonResult(CalcResult calcResult)
        {
            Logger().Debug($"ResultCode: {calcResult.ResultCode}, OperationResult: {calcResult.OperationResult}");
            try
            {
                switch (calcResult.ResultCode)
                {
                    case ResultType.Success:
                        return Json(new ApiResult<decimal>(calcResult.OperationResult));
                    case ResultType.OverFlow:
                    case ResultType.ZeroDivisor:
                        return Json(new ApiError(calcResult.ResultCode.ToString(), calcResult.ResultCode.GetDescription()));
                    default:
                        return Json(new ApiError(ResultType.Unknown.ToString(), ResultType.Unknown.GetDescription()));
                }
            }
            catch (Exception ex)
            {
                Logger().Error(ex.ToString());
                return Json(new ApiError(ResultType.Exception.ToString(), ex.Message));
            }
        }
    }
}