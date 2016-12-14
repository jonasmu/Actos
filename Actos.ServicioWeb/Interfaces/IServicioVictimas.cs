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
        int CrearVictima(Victima victima);

        [OperationContract]
        void ModificarVictima(Victima victima);

        [OperationContract]
        void EliminarVictima(Victima victima);

        [OperationContract]
        Victima DevolverVictimaPorId(int id);

        [OperationContract]
        List<Victima> DevolverVictimas();
    }
}
