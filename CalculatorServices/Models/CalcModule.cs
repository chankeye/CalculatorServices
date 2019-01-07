using CalculatorServices.DTOs;
using CalculatorServices.Enums;
using System;

namespace CalculatorServices.Models
{
    public class CalcModule
    {
        public CalcResult Add(decimal num1, decimal num2)
        {
            return Calc(num1, num2, OperatorType.Add);
        }

        public CalcResult Subtract(decimal num1, decimal num2)
        {
            return Calc(num1, num2, OperatorType.Subtract);
        }

        public CalcResult Multiply(decimal num1, decimal num2)
        {
            return Calc(num1, num2, OperatorType.Multiply);
        }

        public CalcResult Divide(decimal num1, decimal num2)
        {
            if (num2 == 0)
                return new CalcResult { ResultCode = ResultType.ZeroDivisor };

            return Calc(num1, num2, OperatorType.Divide);
        }

        private CalcResult Calc(decimal num1, decimal num2, OperatorType opera)
        {
            var result = new CalcResult
            {
                ResultCode = ResultType.Success
            };

            try
            {
                switch (opera)
                {
                    case OperatorType.Add:
                        result.OperationResult = num1 + num2;
                        break;
                    case OperatorType.Subtract:
                        result.OperationResult = num1 - num2;
                        break;
                    case OperatorType.Multiply:
                        result.OperationResult = num1 * num2;
                        break;
                    case OperatorType.Divide:
                        result.OperationResult = num1 / num2;
                        break;
                }
            }
            catch (OverflowException)
            {
                result.ResultCode = ResultType.OverFlow;
            }

            return result;
        }
    }
}