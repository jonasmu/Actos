using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Repositorios
{
    public class RepositorioTiposTelefonos : RepositorioTipos<TipoTelefono>
    {
        #region Metodos
        public override List<TipoTelefono> DevolverTodos()
        {
            if (entidades == null)
            {
                entidades = TablaALista(accesoDatos.TiposTelefonos_DevolverTodos());
            }
            return entidades.ToList();
        }
        #endregion
    }
}
