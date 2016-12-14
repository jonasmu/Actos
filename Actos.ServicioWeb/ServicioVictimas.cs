using Actos.Modelo.Entidades;
using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Actos.ServicioWeb
{
    public partial class Servicio
    {
        #region Metodos

        public int CrearVictima(Victima victima)
        {
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoValida);
            }
            if (String.IsNullOrWhiteSpace(victima.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }
            if (String.IsNullOrWhiteSpace(victima.Apellido))
            {
                throw new FaultException(Lenguaje.ApellidoNoValido);
            }
            if (String.IsNullOrWhiteSpace(victima.Apodo))
            {
                throw new FaultException(Lenguaje.ApodoNoValido);
            }
            if (String.IsNullOrWhiteSpace(victima.Clave))
            {
                throw new FaultException(Lenguaje.ClaveNoValida);
            }
            victima.EstaBorrado = false;
            victima.Nombre.Trim();
            victima.Apellido.Trim();
            victima.Apodo.Trim();
            RepositorioVictimas.Insertar(victima);
            return victima.Id;
        }

        public void ModificarVictima(Victima victima)
        {
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoValida);
            }

            var victimaModificar = RepositorioVictimas.DevolverPorId(victima.Id);
            if (victimaModificar == null)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }
            if (victimaModificar.EstaBorrado)
            {
                throw new FaultException(Lenguaje.VictimaYaEliminada);
            }
            if (string.IsNullOrWhiteSpace(victima.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }
            if (string.IsNullOrWhiteSpace(victima.Apellido))
            {
                throw new FaultException(Lenguaje.ApellidoNoValido);
            }
            if (String.IsNullOrWhiteSpace(victima.Apodo))
            {
                throw new FaultException(Lenguaje.ApodoNoValido);
            }
            if (string.IsNullOrWhiteSpace(victima.Clave))
            {
                throw new FaultException(Lenguaje.ClaveNoValida);
            }
            victimaModificar.Nombre = victima.Nombre.Trim();
            victimaModificar.Apellido = victima.Apellido.Trim();
            victimaModificar.Apodo = victima.Apodo.Trim();
            victimaModificar.Clave = victima.Clave;

            RepositorioVictimas.Modificar(victimaModificar);
        }

        public void EliminarVictima(Victima victima)
        {
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoValida);
            }

            victima = RepositorioVictimas.DevolverPorId(victima.Id);
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }
            if (victima.EstaBorrado)
            {
                throw new FaultException(Lenguaje.VictimaYaEliminada);
            }
            victima.EstaBorrado = true;
            RepositorioVictimas.Modificar(victima);
        }

        public Victima DevolverVictimaPorId(int id)
        {
            var victima = RepositorioVictimas.DevolverPorId(id);
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }
            return victima;
        }

        public List<Victima> DevolverVictimas()
        {
            return RepositorioVictimas.DevolverTodos();
        }

        #endregion
    }
}