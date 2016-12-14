using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Repositorios
{
    public class RepositorioEstados : RepositorioTipos<Estado>
    {
        #region Metodos
        public override List<Estado> DevolverTodos()
        {
            if (entidades == null)
            {
                entidades = TablaALista(accesoDatos.Estados_DevolverTodos());
            }
            return entidades.ToList();
        }
        #endregion
    }
}
