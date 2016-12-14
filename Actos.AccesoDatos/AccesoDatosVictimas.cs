using Actos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Actos.Modelo.Entidades;

namespace Actos.AccesoDatos
{
    public class AccesoDatosVictimas : AccesoDatosBase, IAccesoDatosVictimas
    {
        public DataTable Victimas_DevolverTodos()
        {
            return DevolverTabla("Victimas_DevolverTodos");
        }

        public DataTable Victimas_DevolverPorId(int id)
        {
            return DevolverTabla("Victimas_DevolverPorId",
               new SqlParameter("@IdVictima", id));
        }

        public int Victimas_Insertar(Victima victima)
        {
            return Convert.ToInt32(DevolverEscalar("Victimas_Insertar",
                new SqlParameter("@Nombre", victima.Nombre),
                new SqlParameter("@Apellido", victima.Apellido),
                new SqlParameter("@Apodo", victima.Apodo),
                new SqlParameter("@Clave", victima.Clave),
                new SqlParameter("@EstaBorrado", victima.EstaBorrado)));
        }

        public void Victimas_Modificar(Victima victima)
        {
            EjecutarConsulta("Victimas_Modificar",
                new SqlParameter("@IdVictima", victima.Id),
                new SqlParameter("@Nombre", victima.Nombre),
                new SqlParameter("@Apellido", victima.Apellido),
                new SqlParameter("@Apodo", victima.Apodo),
                new SqlParameter("@Clave", victima.Clave),
                new SqlParameter("@EstaBorrado", victima.EstaBorrado));
        }
    }
}
