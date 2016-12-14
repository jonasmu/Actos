using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Repositorios
{
    public class RepositorioTiposRedesSociales : RepositorioTipos<TipoRedSocial>
    {
        #region Metodos
        public override List<TipoRedSocial> DevolverTodos()
        {
            if (entidades == null)
            {
                entidades = TablaALista(accesoDatos.TiposRedesSociales_DevolverTodos());
            }
            return entidades.ToList();
        }
        #endregion
    }
}
