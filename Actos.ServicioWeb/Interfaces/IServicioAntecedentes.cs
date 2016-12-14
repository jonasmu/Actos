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
        int CrearAntecedente(Antecedente antecedente);

        [OperationContract]
        void ModificarAntecedente(Antecedente antecedente);

        [OperationContract]
        void EliminarAntecedente(Antecedente antecedente);

        [OperationContract]
        Antecedente DevolverAntecedentePorId(int id, bool puntajes);

        [OperationContract]
        List<Antecedente> DevolverAntecedentesPorAgresor(Agresor agresor, bool puntajes);

        [OperationContract]
        List<Antecedente> DevolverAntecedentesPorVictima(Victima victima, bool puntajes);

        [OperationContract]
        List<Antecedente> DevolverAntecedentes(bool puntajes);

        [OperationContract]
        void AgregarPuntaje(Antecedente antecedente, Victima victima);
    }
}
