using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorServices.Controllers
{
    public class CalcApiController : Controller
    {
        // GET: CalcApi
        public ActionResult Index()
        {
            return View();
        }
    }
}