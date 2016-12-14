using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Actos.SitioWeb.MVC.Models.Agresores
{
    public class ModificarViewModel
    {

        public Agresor Agresor { get; set; }

        public Direccion Direccion { get; set; }

        public RedSocial RedSocial { get; set; }

        public Telefono Telefono { get; set; }

        public Localidad Localidad { get; set; }


        //TIPOS

        public Localidad[] Localidades { get; set; }
        
        public TipoDireccion[] TiposDirecciones { get; set; }

        public TipoRedSocial[] TiposRedesSociales { get; set; }

        public TipoTelefono[] TiposTelefonos { get; set; }
    }
}