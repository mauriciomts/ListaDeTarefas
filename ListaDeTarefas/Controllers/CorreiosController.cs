using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace ListaDeTarefas.Controllers
{
    public class CorreiosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CorreiosCalc(string cep)
        {
            return Json(null, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
