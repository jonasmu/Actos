using Actos.AccesoDatos.Interfaces;
using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos
{
    public class AccesoDatosLocalidades : AccesoDatosBase, IAccesoDatosLocalidades
    {
        public DataTable Localidades_DevolverPorId(int id)
        {
            return DevolverTabla("Localidades_DevolverPorId",
                new SqlParameter("@IdLocalidad", id));
        }

        public DataTable Localidades_DevolverTodos()
        {
            return DevolverTabla("Localidades_DevolverTodos");
        }

        public int Localidades_Insertar(Localidad localidad)
        {
            return Convert.ToInt32(DevolverEscalar("Localidades_Insertar",
                new SqlParameter("@Nombre", localidad.Nombre),
                new SqlParameter("@CodigoArea", localidad.CodigoArea)));
        }

        public void Localidades_Modificar(Localidad localidad)
        {
            EjecutarConsulta("Localidades_Modificar",
                 new SqlParameter("@IdLocalidad", localidad.Id),
                 new SqlParameter("@Nombre", localidad.Nombre),
                 new SqlParameter("@CodigoArea", localidad.CodigoArea));
        }

        public void Localidades_Eliminar(Localidad localidad)
        {
            EjecutarConsulta("Localidades_Eliminar",
                 new SqlParameter("@IdLocalidad", localidad.Id));
        }
    }
}
