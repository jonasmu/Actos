using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actos.SitioWeb.MVC.Controllers
{
    public abstract class _ControladorBase : Controller
    {
        public ServicioClient servicioWeb = new ServicioClient();
    }
}