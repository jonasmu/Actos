using Actos.Modelo.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actos.Modelo.Entidades
{
    public class Antecedente : EntidadBase<int>
    {
        #region Atributos
        private Estado estado;
        private string nombre;
        private Victima victima;
        private Agresor agresor;
        private DateTime fecha;
        private string observaciones;
        private string perjuicios;
        private string ubicacion;
        private double latitud;
        private double longitud;
        private List<Victima> puntajes;

        #endregion

        #region Propiedades

        public List<Victima> Puntajes
        {
            get { return puntajes; }
            set { puntajes = value; }
        }

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public double Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public Victima Victima
        {
            get { return victima; }
            set { victima = value; }
        }

        public Agresor Agresor
        {
            get { return agresor; }
            set { agresor = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public string Perjuicios
        {
            get { return perjuicios; }
            set { perjuicios = value; }
        }

        #endregion

    }
}
