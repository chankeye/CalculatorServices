using CalculatorServices.Enums;

namespace CalculatorServices.DTOs
{
    public class CalcResult
    {
        public ResultType ResultCode { get; set; }
        public decimal OperationResult { get; set; }
    }
}