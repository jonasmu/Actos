using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Repositorios
{
    public class RepositorioTiposDirecciones : RepositorioTipos<TipoDireccion>
    {
        #region Metodos
        public override List<TipoDireccion> DevolverTodos()
        {
            if (entidades == null)
            {
                entidades = TablaALista(accesoDatos.TiposDirecciones_DevolverTodos());
            }
            return entidades.ToList();
        }
        #endregion
    }
}
