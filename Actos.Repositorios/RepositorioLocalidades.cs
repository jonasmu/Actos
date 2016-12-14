using Actos.AccesoDatos.Interfaces;
using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Actos.AccesoDatos;

namespace Actos.Repositorios
{
    public class RepositorioLocalidades : RepositorioEntidad<Localidad, int, IAccesoDatosLocalidades>
    {
        #region Constructores
        public RepositorioLocalidades()
        {
            accesoDatos = new AccesoDatosLocalidades();
        }
        #endregion

        #region Metodos

        protected override Localidad FilaAEntidad(DataRow fila)
        {
            var localidad = new Localidad();
            localidad.Id = (int)fila["IdLocalidad"];
            localidad.Nombre = (string)fila["Nombre"];
            localidad.CodigoArea = (string)fila["CodigoArea"];
            return localidad;
        }

        public override Localidad DevolverPorId(int id)
        {
            var localidad = entidades.Where(x => x.Id == id).SingleOrDefault();
            if (localidad == null)
            {
                using (var dt = accesoDatos.Localidades_DevolverPorId(id))
                {
                    if (dt.Rows.Count != 0)
                    {
                        localidad = FilaAEntidad(dt.Rows[0]);
                        entidades.Add(localidad);
                    }
                }
            }
            return localidad;
        }

        public List<Localidad> DevolverTodos()
        {
            using (var dt = accesoDatos.Localidades_DevolverTodos())
            {
                entidades = TablaALista(dt);
            }
            return entidades;
        }

        public void Insertar(Localidad localidad)
        {
            localidad.Id = accesoDatos.Localidades_Insertar(localidad);
        }

        public void Modificar(Localidad localidad)
        {
            accesoDatos.Localidades_Modificar(localidad);
        }

        public void Eliminar(Localidad localidad)
        {
            accesoDatos.Localidades_Eliminar(localidad);
        }
        #endregion
    }
}
