using CalculatorServices.Enums;
using CalculatorServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CalcModuleTest
    {
        #region Add

        [TestMethod]
        public void CanAddPositiveNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Add(100.01m, 200.033m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(300.043m, result.OperationResult);
        }

        [TestMethod]
        public void CanAddNegativeNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Add(-3.99m, -199.01m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(-203, result.OperationResult);
        }

        [TestMethod]
        public void AddNumberOverflow()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Add(decimal.MaxValue, decimal.MaxValue);

            Assert.AreEqual(ResultType.OverFlow, result.ResultCode);
        }

        #endregion // Add

        #region Subtract

        [TestMethod]
        public void CanSubtractPositiveNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Subtract(100.033m, 200.033m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(-100m, result.OperationResult);
        }

        [TestMethod]
        public void CanSubtractNegativeNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Subtract(-100.033m, -200.033m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(100m, result.OperationResult);
        }

        [TestMethod]
        public void SubstractNumberOverflow()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Subtract(decimal.MaxValue, decimal.MinValue);

            Assert.AreEqual(ResultType.OverFlow, result.ResultCode);
        }

        #endregion // Subtract

        #region Multiply

        [TestMethod]
        public void CanMultiplyPositiveNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Multiply(100.033m, 200.033m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(20009.901089m, result.OperationResult);
        }

        [TestMethod]
        public void CanMultiplyNegativeNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Multiply(-100.033m, -200.033m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(20009.901089m, result.OperationResult);
        }

        [TestMethod]
        public void MultiplyNumberOverflow()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Multiply(decimal.MaxValue, decimal.MaxValue);

            Assert.AreEqual(ResultType.OverFlow, result.ResultCode);
        }

        #endregion // Multiply

        #region Divide

        [TestMethod]
        public void CanDividePositiveNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Divide(200.5m, 2.5m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(80.2m, result.OperationResult);
        }

        [TestMethod]
        public void CanDivideNegativeNumber()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Divide(200.5m, -2.5m);

            Assert.AreEqual(ResultType.Success, result.ResultCode);
            Assert.AreEqual(-80.2m, result.OperationResult);
        }

        [TestMethod]
        public void DivideNumberOverflow()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Divide(decimal.MaxValue, 0.1m);

            Assert.AreEqual(ResultType.OverFlow, result.ResultCode);
        }

        [TestMethod]
        public void DivisorIsZero()
        {
            var calcModule = new CalcModule();

            var result = calcModule.Divide(decimal.MaxValue, 0);

            Assert.AreEqual(ResultType.ZeroDivisor, result.ResultCode);
        }

        #endregion // Divide
    }
}