using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Localidad : EntidadBase<int>
    {
        #region Atributos
        private string nombre;
        private string codigoArea; 
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string CodigoArea
        {
            get { return codigoArea; }
            set { codigoArea = value; }
        } 
        #endregion
    }
}
