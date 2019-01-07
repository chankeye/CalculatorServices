using System;

namespace CalculatorServices.Models
{
    // <summary>
    /// When called API，return the same object
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// Succeed or failed
        /// </summary>
        public bool Succ { get; set; }
        /// <summary>
        /// Result code(0000=Succeed，Others are error)
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data time
        /// </summary>
        public DateTime DataTime { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }


        public ApiResult() { }

        /// <summary>
        /// Succeed result
        /// </summary>
        /// <param name="data"></param>
        public ApiResult(T data)
        {
            Code = "0000";
            Succ = true;
            DataTime = DateTime.Now;
            Data = data;
        }
    }

    public class ApiError : ApiResult<object>
    {
        /// <summary>
        /// Failed result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ApiError(string code, string message)
        {
            Code = code;
            Succ = false;
            DataTime = DateTime.Now;
            Message = message;
        }
    }
}