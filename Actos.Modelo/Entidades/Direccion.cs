using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Direccion : EntidadBase<int>
    {
        #region Atributos
        private Localidad localidad;
        private TipoDireccion tipo;
        private string calle;
        private string numero;
        private string piso;
        private string departamento;
        #endregion

        #region Propiedades
        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        public TipoDireccion Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        } 
        #endregion
    }
}
