using Actos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Actos.Modelo.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Actos.AccesoDatos
{
    public class AccesoDatosAntecedentes : AccesoDatosBase, IAccesoDatosAntecedentes
    {
        public DataTable Antecedentes_DevolverPorAgresor(Agresor agresor)
        {
            return DevolverTabla("Antecedentes_DevolverPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }

        public DataTable Antecedentes_DevolverPorVictima(Victima victima)
        {
            return DevolverTabla("Antecedentes_DevolverPorVictima",
                new SqlParameter("@IdVictima", victima.Id));
        }

        public DataTable Antecedentes_DevolverPorId(int id)
        {
            return DevolverTabla("Antecedentes_DevolverPorId",
                new SqlParameter("@IdAntecedente", id));
        }

        public DataTable Antecedentes_DevolverTodos()
        {
            return DevolverTabla("Antecedentes_DevolverTodos");
        }

        public int Antecedentes_Insertar(Antecedente antecedente)
        {
            return Convert.ToInt32(DevolverEscalar("Antecedentes_Insertar",
                new SqlParameter("@Nombre", antecedente.Nombre),
                new SqlParameter("@IdEstado", antecedente.Estado.Id),
                new SqlParameter("@IdVictima", antecedente.Victima.Id),
                new SqlParameter("@IdAgresor", antecedente.Agresor.Id),
                new SqlParameter("@Fecha", antecedente.Fecha),
                new SqlParameter("@Ubicacion", antecedente.Ubicacion),
                new SqlParameter("@Latitud", antecedente.Latitud),
                new SqlParameter("@Longitud", antecedente.Longitud),
                new SqlParameter("@Observaciones", antecedente.Observaciones),
                new SqlParameter("@Perjuicios", antecedente.Perjuicios)));
        }

        public void Antecedentes_Modificar(Antecedente antecedente)
        {
            EjecutarConsulta("Antecedentes_Modificar",
                new SqlParameter("@IdAntecedente", antecedente.Id),
                new SqlParameter("@Nombre", antecedente.Nombre),
                new SqlParameter("@IdEstado", antecedente.Estado.Id),
                new SqlParameter("@IdVictima", antecedente.Victima.Id),
                new SqlParameter("@IdAgresor", antecedente.Agresor.Id),
                new SqlParameter("@Fecha", antecedente.Fecha),
                new SqlParameter("@Ubicacion", antecedente.Ubicacion),
                new SqlParameter("@Latitud", antecedente.Latitud),
                new SqlParameter("@Longitud", antecedente.Longitud),
                new SqlParameter("@Observaciones", antecedente.Observaciones),
                new SqlParameter("@Perjuicios", antecedente.Perjuicios));
        }

        public void Antecedentes_Eliminar(Antecedente antecedente)
        {
            EjecutarConsulta("Antecedentes_Eliminar",
            new SqlParameter("@IdAntecedente", antecedente.Id));
        }

        public void AntecedentesVictimas_Insertar(Antecedente antecedente, Victima victima)
        {
            EjecutarConsulta("AntecedentesVictimas_Insertar",
                new SqlParameter("@IdAntecedente", antecedente.Id),
                new SqlParameter("@IdVictima", victima.Id));
        }

        public DataTable AntecedentesVictimas_DevolverPorAntecedente(Antecedente antecedente)
        {
            return DevolverTabla("AntecedentesVictimas_DevolverPorAntecedente",
                new SqlParameter("@IdAntecedente", antecedente.Id));
        }

        public void AntecedentesVictimas_EliminarPorAntecedente(Antecedente antecedente)
        {
            EjecutarConsulta("AntecedentesVictimas_EliminarPorAntecedente",
                new SqlParameter("@IdAntecedente", antecedente.Id));
        }
    }
}
