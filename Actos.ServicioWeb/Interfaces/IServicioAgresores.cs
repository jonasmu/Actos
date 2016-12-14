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
        int CrearAgresor(Agresor agresor);

        [OperationContract]
        void ModificarAgresor(Agresor agresor);

        [OperationContract]
        void EliminarAgresor(Agresor agresor);

        [OperationContract]
        Agresor DevolverAgresorPorId(int id, bool telefonos, bool direcciones, bool redesSociales);

        [OperationContract]
        List<Agresor> DevolverAgresores(bool telefonos, bool direcciones, bool redesSociales);
    }
}
