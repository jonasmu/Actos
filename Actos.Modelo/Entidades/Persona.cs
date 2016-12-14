using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public abstract class Persona : EntidadBase<int>
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private string apodo;
        private bool estaBorrado;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Apodo
        {
            get { return apodo; }
            set { apodo = value; }
        }

        public bool EstaBorrado
        {
            get { return estaBorrado; }
            set { estaBorrado = value; }
        }
        #endregion
    }
}
