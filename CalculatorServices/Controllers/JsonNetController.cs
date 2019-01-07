using Newtonsoft.Json;
using NLog;
using System;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CalculatorServices.Controllers
{
    public class JsonNetController : Controller
    {
        protected Logger Logger()
        {
            var method = new StackFrame(1).GetMethod();
            var fullMethodName =
                string.Format(
                    "{0}.{1}",
                    method.DeclaringType.FullName,
                    method.Name
                );

            return LogManager.GetLogger(fullMethodName);
        }

        protected override JsonResult Json(object data, string contentType,
                  Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            if (behavior == JsonRequestBehavior.DenyGet
                && string.Equals(this.Request.HttpMethod, "GET",
                                 StringComparison.OrdinalIgnoreCase))
                //Call JsonResult to throw the same exception as JsonResult
                return new JsonResult();
            return new JsonNetResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }

        public class JsonNetResult : JsonResult
        {
            public JsonSerializerSettings SerializerSettings { get; set; }
            public Formatting Formatting { get; set; }
            public JsonNetResult()
            {
                SerializerSettings = new JsonSerializerSettings();
            }
            public override void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                    throw new ArgumentNullException("context");
                HttpResponseBase response = context.HttpContext.Response;
                response.ContentType =
                    !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
                if (ContentEncoding != null)
                    response.ContentEncoding = ContentEncoding;
                if (Data != null)
                {
                    JsonTextWriter writer = new JsonTextWriter(response.Output)
                    {
                        Formatting = Formatting
                    };
                    JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                    serializer.Serialize(writer, Data); writer.Flush();
                }
            }
        }
    }
}