using CalculatorServices.Enums;

namespace CalculatorServices.Models
{
    public class CalcModule
    {
        public static (ResultType resultCode, double result) Add(double number1, double number2)
        {
            var result = number1 + number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public static (ResultType resultCode, double result) Subtract(double number1, double number2)
        {
            var result = number1 - number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public static (ResultType resultCode, double result) Multiply(double number1, double number2)
        {
            var result = number1 * number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public static (ResultType resultCode, double result) Divide(double number1, double number2)
        {
            if (number2 == 0)
                return (ResultType.ZeroDivisor, 0);

            var result = number1 / number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }
    }
}