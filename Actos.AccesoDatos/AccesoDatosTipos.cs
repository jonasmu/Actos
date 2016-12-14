using Actos.AccesoDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Actos.AccesoDatos
{
    public class AccesoDatosTipos : AccesoDatosBase, IAccesoDatosTipos
    {
        public DataTable Estados_DevolverTodos()
        {
            return DevolverTabla("Estados_DevolverTodos");
        }

        public DataTable TiposDirecciones_DevolverTodos()
        {
            return DevolverTabla("TiposDirecciones_DevolverTodos");
        }

        public DataTable TiposRedesSociales_DevolverTodos()
        {
            return DevolverTabla("TiposRedesSociales_DevolverTodos");
        }

        public DataTable TiposTelefonos_DevolverTodos()
        {
            return DevolverTabla("TiposTelefonos_DevolverTodos");
        }
    }
}
