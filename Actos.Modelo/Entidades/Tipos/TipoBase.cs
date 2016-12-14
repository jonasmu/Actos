using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades.Tipos
{
    public abstract class TipoBase : EntidadBase<byte>
    {
        #region Atributos

        private string nombre;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}
