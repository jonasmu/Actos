using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Victima : Persona
    {
        #region Atributos
        private string clave;
        #endregion

        #region Propiedades
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public string Pepe
        {
            get { return Nombre + " " + Apellido; }
        }
        #endregion
    }
}
