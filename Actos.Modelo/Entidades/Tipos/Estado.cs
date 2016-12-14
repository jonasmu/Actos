using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades.Tipos
{
    public class Estado : TipoBase
    {
        #region Metodos

        public override string ToString()
        {
            return Nombre;
        }

        #endregion
    }
}
