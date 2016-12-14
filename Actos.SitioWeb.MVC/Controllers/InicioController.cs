using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actos.SitioWeb.MVC.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}