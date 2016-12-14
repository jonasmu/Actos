using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Actos.AccesoDatos.Interfaces
{
    public interface IAccesoDatosTipos
    {
        DataTable Estados_DevolverTodos();

        DataTable TiposTelefonos_DevolverTodos();

        DataTable TiposDirecciones_DevolverTodos();

        DataTable TiposRedesSociales_DevolverTodos();
    }
}
