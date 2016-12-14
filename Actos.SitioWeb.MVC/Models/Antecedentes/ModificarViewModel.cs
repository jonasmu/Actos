using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Actos.SitioWeb.MVC.Models.Antecedentes
{
    public class ModificarViewModel
    {
        public Antecedente Antecedente { get; set; }

        //ESTADOS
        public Estado[] Estados { get; set; }
    }
}