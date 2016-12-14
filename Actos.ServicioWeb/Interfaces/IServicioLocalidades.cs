using Actos.Modelo.Entidades;
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
        int CrearLocalidad(Localidad localidad);

        [OperationContract]
        void ModificarLocalidad(Localidad localidad);

        [OperationContract]
        Localidad EliminarLocalidad(Localidad localidad, Localidad localidadReemplazo);

        [OperationContract]
        Localidad DevolverLocalidadPorId(int id);

        [OperationContract]
        List<Localidad> DevolverLocalidad();
    }
}
