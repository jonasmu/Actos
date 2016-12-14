using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Agresor : Persona
    {
        #region Atributos

        private string ocupacion;
        private string caracteristicas;
        private string metodos;
        private List<Direccion> direcciones;
        private List<RedSocial> redesSociales;
        private List<Telefono> telefonos;
        private byte[] foto;
        private int puntaje;

        #endregion

        #region Propiedades

        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public List<Telefono> Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }

        public List<Direccion> Direcciones
        {
            get { return direcciones; }
            set { direcciones = value; }
        }

        public List<RedSocial> RedesSociales
        {
            get { return redesSociales; }
            set { redesSociales = value; }
        }

        public string Ocupacion
        {
            get { return ocupacion; }
            set { ocupacion = value; }
        }

        public string Caracteristicas
        {
            get { return caracteristicas; }
            set { caracteristicas = value; }
        }

        public string Metodos
        {
            get { return metodos; }
            set { metodos = value; }
        }
        #endregion
    }
}
