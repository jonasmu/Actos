using Actos.AccesoDatos;
using Actos.AccesoDatos.Interfaces;
using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.Repositorios
{
    public abstract class RepositorioTipos<TEntidadTipo> : RepositorioBase<TEntidadTipo, byte, IAccesoDatosTipos>
        where TEntidadTipo : TipoBase, new()
    {
        #region Constructores
        public RepositorioTipos()
        {
            accesoDatos = new AccesoDatosTipos();
        }
        #endregion

        #region Atributos
        protected static List<TEntidadTipo> entidades;
        #endregion

        #region Metodos
        public abstract List<TEntidadTipo> DevolverTodos();

        public TEntidadTipo DevolverPorId(Byte id)
        {
            if (entidades == null)
            {
                entidades = DevolverTodos();
            }
            return entidades.Where(x => x.Id == id).FirstOrDefault();
        }

        protected override TEntidadTipo FilaAEntidad(DataRow fila)
        {
            var entidad = new TEntidadTipo();
            entidad.Id = (Byte)fila[0];
            entidad.Nombre = (String)fila[1];
            return entidad;
        }
        #endregion
    }
}
