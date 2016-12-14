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
    public class AccesoDatosAgresores : AccesoDatosBase, IAccesoDatosAgresores
    {
        public DataTable Agresores_DevolverPorId(int id)
        {
            return DevolverTabla("Agresores_DevolverPorId",
               new SqlParameter("@IdAgresor", id));
        }

        public DataTable Agresores_DevolverTodos()
        {
            return DevolverTabla("Agresores_DevolverTodos");
        }

        private SqlParameter[] CrearParametros(Agresor agresor, bool incluirId)
        {
            var parametros = new List<SqlParameter>();
            if (incluirId)
            {
                parametros.Add(new SqlParameter("@IdAgresor", agresor.Id));
            }
            parametros.Add(new SqlParameter("@Nombre", agresor.Nombre));
            parametros.Add(new SqlParameter("@Apellido", agresor.Apellido));
            parametros.Add(new SqlParameter("@Apodo", agresor.Apodo));
            parametros.Add(new SqlParameter("@Ocupacion", agresor.Ocupacion));
            parametros.Add(new SqlParameter("@Caracteristicas", agresor.Caracteristicas));
            parametros.Add(new SqlParameter("@Metodos", agresor.Metodos));
            parametros.Add(new SqlParameter("@EstaBorrado", agresor.EstaBorrado));
            if (agresor.Foto != null)
            {
                parametros.Add(new SqlParameter("@Foto", agresor.Foto));
            }

            return parametros.ToArray();
        }

        public int Agresores_Insertar(Agresor agresor)
        {
            var parametros = CrearParametros(agresor, false);
            return Convert.ToInt32(DevolverEscalar("Agresores_Insertar", parametros));

            //if (agresor.Foto == null)
            //{
            //    return Convert.ToInt32(DevolverEscalar("Agresores_Insertar",
            //    new SqlParameter("@Nombre", agresor.Nombre),
            //    new SqlParameter("@Apellido", agresor.Apellido),
            //    new SqlParameter("@Apodo", agresor.Apodo),
            //    new SqlParameter("@Ocupacion", agresor.Ocupacion),
            //    new SqlParameter("@Caracteristicas", agresor.Caracteristicas),
            //    new SqlParameter("@Metodos", agresor.Metodos),
            //    new SqlParameter("@EstaBorrado", agresor.EstaBorrado)));
            //}
            //else
            //{
            //    return Convert.ToInt32(DevolverEscalar("Agresores_Insertar",
            //    new SqlParameter("@Nombre", agresor.Nombre),
            //    new SqlParameter("@Apellido", agresor.Apellido),
            //    new SqlParameter("@Apodo", agresor.Apodo),
            //    new SqlParameter("@Ocupacion", agresor.Ocupacion),
            //    new SqlParameter("@Caracteristicas", agresor.Caracteristicas),
            //    new SqlParameter("@Metodos", agresor.Metodos),
            //    new SqlParameter("@Foto", agresor.Foto),
            //    new SqlParameter("@EstaBorrado", agresor.EstaBorrado)));
            //}
        }

        public void Agresores_Modificar(Agresor agresor)
        {
            var parametros = CrearParametros(agresor, true);
            EjecutarConsulta("Agresores_Modificar", parametros);


            //if (agresor.Foto == null)
            //{
            //    EjecutarConsulta("Agresores_Modificar",
            //    new SqlParameter("@IdAgresor", agresor.Id),
            //    new SqlParameter("@Nombre", agresor.Nombre),
            //    new SqlParameter("@Apellido", agresor.Apellido),
            //    new SqlParameter("@Apodo", agresor.Apodo),
            //    new SqlParameter("@Ocupacion", agresor.Ocupacion),
            //    new SqlParameter("@Caracteristicas", agresor.Caracteristicas),
            //    new SqlParameter("@Metodos", agresor.Metodos),
            //    new SqlParameter("@EstaBorrado", agresor.EstaBorrado));
            //}
            //else
            //{
            //    EjecutarConsulta("Agresores_Modificar",
            //    new SqlParameter("@IdAgresor", agresor.Id),
            //    new SqlParameter("@Nombre", agresor.Nombre),
            //    new SqlParameter("@Apellido", agresor.Apellido),
            //    new SqlParameter("@Apodo", agresor.Apodo),
            //    new SqlParameter("@Ocupacion", agresor.Ocupacion),
            //    new SqlParameter("@Caracteristicas", agresor.Caracteristicas),
            //    new SqlParameter("@Metodos", agresor.Metodos),
            //    new SqlParameter("@Foto", agresor.Foto),
            //    new SqlParameter("@EstaBorrado", agresor.EstaBorrado));
            //}
        }



        /*DEVOLVER POR AGRESOR*/

        public DataTable AgresoresTelefonos_DevolverPorAgresor(Agresor agresor)
        {
            return DevolverTabla("AgresoresTelefonos_DevolverPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }

        public DataTable AgresoresRedesSociales_DevolverPorAgresor(Agresor agresor)
        {
            return DevolverTabla("AgresoresRedesSociales_DevolverPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }

        public DataTable AgresoresDirecciones_DevolverPorAgresor(Agresor agresor)
        {
            return DevolverTabla("AgresoresDirecciones_DevolverPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }


        /*ELIMINAR POR AGRESOR*/

        public void AgresoresDirecciones_EliminarPorAgresor(Agresor agresor)
        {
            EjecutarConsulta("AgresoresDirecciones_EliminarPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }

        public void AgresoresRedesSociales_EliminarPorAgresor(Agresor agresor)
        {
            EjecutarConsulta("AgresoresRedesSociales_EliminarPorAgresor",
                new SqlParameter("@IdAgresor", agresor.Id));
        }

        public void AgresoresTelefonos_EliminarPorAgresor(Agresor agresor)
        {
            EjecutarConsulta("AgresoresTelefonos_EliminarPorAgresor",
               new SqlParameter("@IdAgresor", agresor.Id));
        }


        /*INSERTAR POR AGRESOR*/

        public int AgresoresDirecciones_Insertar(Direccion direccion, Agresor agresor)
        {
            return Convert.ToInt32(DevolverEscalar("AgresoresDirecciones_Insertar",
                new SqlParameter("@IdAgresor", agresor.Id),
                new SqlParameter("@IdLocalidad", direccion.Localidad.Id),
                new SqlParameter("@IdTipoDireccion", direccion.Tipo.Id),
                new SqlParameter("@Calle", direccion.Calle),
                new SqlParameter("@Numero", direccion.Numero),
                new SqlParameter("@Departamento", direccion.Departamento),
                new SqlParameter("@Piso", direccion.Piso)));
        }

        public int AgresoresRedesSociales_Insertar(RedSocial redSocial, Agresor agresor)
        {
            return Convert.ToInt32(DevolverEscalar("AgresoresRedesSociales_Insertar",
                  new SqlParameter("@IdAgresor", agresor.Id),
                  new SqlParameter("@IdTipoRedSocial", redSocial.Tipo.Id),
                  new SqlParameter("@Nombre", redSocial.Nombre)));
        }

        public int AgresoresTelefonos_Insertar(Telefono telefono, Agresor agresor)
        {
            return Convert.ToInt32(DevolverEscalar("AgresoresTelefonos_Insertar",
                new SqlParameter("@IdAgresor", agresor.Id),
                new SqlParameter("@IdTipoTelefono", telefono.Tipo.Id),
                new SqlParameter("@IdLocalidad", telefono.Localidad.Id),
                new SqlParameter("@Numero", telefono.Numero)));
        }
    }
}
