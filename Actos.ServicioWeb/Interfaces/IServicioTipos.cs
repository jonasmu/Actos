using Actos.Modelo.Entidades;
using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Actos.ServicioWeb.Interfaces
{
    public partial interface IServicio
    {
        [OperationContract]
        List<Estado> DevolverEstados();

        [OperationContract]
        List<TipoDireccion> DevolverTiposDirecciones();

        [OperationContract]
        List<TipoRedSocial> DevolverTiposRedesSociales();

        [OperationContract]
        List<TipoTelefono> DevolverTiposTelefonos();
    }
}
