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
    public class RepositorioVictimas : RepositorioEntidad<Victima, int, IAccesoDatosVictimas>
    {
        #region Constructores
        public RepositorioVictimas()
        {
            accesoDatos = new AccesoDatosVictimas();
        }
        #endregion

        #region Metodos
        protected override Victima FilaAEntidad(DataRow fila)
        {
            var victima = new Victima();
            victima.Id = (int)fila["IdVictima"];
            victima.Nombre = (string)fila["Nombre"];
            victima.Apellido = (string)fila["Apellido"];
            victima.Apodo = (string)fila["Apodo"];
            victima.Clave = (string)fila["Clave"];
            victima.EstaBorrado = (bool)fila["EstaBorrado"];
            return victima;
        }

            /*Primero se fija si ya esta cargado el dato requerido,
            * eso lo hace con la expresion lambda, consulta linq "reducida"
            * si devuelve NULL significa de que no tiene el dato
            * entonces llama a la base de datos para cargarlo.
            * La palabra USING significa que despues de usar el recurso
            * lo desecha de memoria (para que no quede dando vueltas al
            * pedo hasta que garbage colector se de cuenta)*/

        public override Victima DevolverPorId(int id)
        {
            var victima = entidades.Where(x => x.Id == id).SingleOrDefault();
            if (victima == null)
            {
                using (var dt = accesoDatos.Victimas_DevolverPorId(id))
                {
                    if (dt.Rows.Count != 0)
                    {
                        victima = FilaAEntidad(dt.Rows[0]);
                        entidades.Add(victima);
                    }
                }
            }
            return victima;
        }

        public List<Victima> DevolverTodos()
        {
            using (var dt = accesoDatos.Victimas_DevolverTodos())
            {
                entidades = TablaALista(dt);
            }
            return entidades;
        }

        public void Insertar(Victima victima)
        {
            victima.Id = accesoDatos.Victimas_Insertar(victima);
        }

        public void Modificar(Victima victima)
        {
            accesoDatos.Victimas_Modificar(victima);
        }
        #endregion
    }
}
