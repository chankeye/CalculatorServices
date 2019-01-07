using CalculatorServices.Enums;

namespace CalculatorServices.Models
{
    public class CalcModule
    {
        public (ResultType, double) Addition(double number1, double number2)
        {
            var result = number1 + number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public (ResultType, double) Subtraction(double number1, double number2)
        {
            var result = number1 - number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public (ResultType, double) Multiplication(double number1, double number2)
        {
            var result = number1 * number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }

        public (ResultType, double) Division(double number1, double number2)
        {
            if (number2 == 0)
                return (ResultType.ZeroDivisor, 0);

            var result = number1 / number2;
            var resultType = double.IsInfinity(result) ? ResultType.OverFlow : ResultType.Success;

            return (resultType, result);
        }
    }
}