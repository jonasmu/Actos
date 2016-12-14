using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos.Interfaces
{
    public interface IAccesoDatosAntecedentes
    {
        DataTable Antecedentes_DevolverTodos();

        DataTable Antecedentes_DevolverPorId(int id);

        DataTable Antecedentes_DevolverPorAgresor(Agresor agresor);

        DataTable Antecedentes_DevolverPorVictima(Victima victima);

        int Antecedentes_Insertar(Antecedente antecedente);

        void Antecedentes_Modificar(Antecedente antecedente);

        void Antecedentes_Eliminar(Antecedente antecedente);


        void AntecedentesVictimas_Insertar(Antecedente antecedente, Victima victima);

        DataTable AntecedentesVictimas_DevolverPorAntecedente(Antecedente antecedente);

        void AntecedentesVictimas_EliminarPorAntecedente(Antecedente antecedente);
    }
}
