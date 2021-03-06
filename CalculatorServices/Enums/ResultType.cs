﻿using System.ComponentModel;

namespace CalculatorServices.Enums
{
    public enum ResultType
    {
        Success = 200,
        [Description("Result is overflow")]
        OverFlow = 400,
        [Description("Divisor can not be zero")]
        ZeroDivisor,
        [Description("Unknown error")]
        Unknown,
        Exception = 500
    }
}