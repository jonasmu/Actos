using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public abstract class EntidadBase<TIdentidad>
    {
        #region Atributos
        private TIdentidad id;
        #endregion

        #region Propiedades
        public TIdentidad Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
