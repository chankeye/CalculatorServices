using System.ComponentModel;

namespace CalculatorServices.Enums
{
    public enum ResultType
    {
        Success,
        [Description("Result is overflow")]
        OverFlow,
        [Description("Divisor can not be zero")]
        ZeroDivisor,
        [Description("Unknown error")]
        Unknown
    }
}