using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Telefono : EntidadBase<int>
    {
        #region Atributos
        private TipoTelefono tipo;
        private Localidad localidad;
        private string numero; 
        #endregion

        #region Propiedades
        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public TipoTelefono Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        } 
        #endregion
    }
}
