using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class RedSocial : EntidadBase<int>
    {
        #region Atributos
        private TipoRedSocial tipo;
        private string nombre; 
        #endregion

        #region Propiedades
        public TipoRedSocial Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        } 
        #endregion
    }
}
