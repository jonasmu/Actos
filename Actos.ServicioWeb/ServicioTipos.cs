using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Actos.Modelo.Entidades.Tipos;

namespace Actos.ServicioWeb
{
    public partial class Servicio
    {
        #region Metodos

        public List<Estado> DevolverEstados()
        {
            return RepositorioEstados.DevolverTodos();
        }

        public List<TipoDireccion> DevolverTiposDirecciones()
        {
            return RepositorioTiposDirecciones.DevolverTodos();
        }

        public List<TipoRedSocial> DevolverTiposRedesSociales()
        {
            return RepositorioTiposRedesSociales.DevolverTodos();
        }

        public List<TipoTelefono> DevolverTiposTelefonos()
        {
            return RepositorioTiposTelefonos.DevolverTodos();
        }

        #endregion
    }
}