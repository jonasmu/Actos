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

        public int CrearAntecedente(Antecedente antecedente)
        {
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoValido);
            }
            if (String.IsNullOrWhiteSpace(antecedente.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }
            if (String.IsNullOrWhiteSpace(antecedente.Perjuicios))
            {
                throw new FaultException(Lenguaje.PerjuiciosNoValidos);
            }
            if (antecedente.Fecha > DateTime.Now)
            {
                throw new FaultException(Lenguaje.FechaNoValida);
            }
            if (String.IsNullOrWhiteSpace(antecedente.Ubicacion))
            {
                throw new FaultException(Lenguaje.UbicacionNoValida);
            }

            if (antecedente.Estado == null)
            {
                throw new FaultException(Lenguaje.EstadoNoValido);
            }

            if (RepositorioEstados.DevolverPorId(antecedente.Estado.Id) == null)
            {
                throw new FaultException(Lenguaje.EstadoNoValido);
            }

            var victima = RepositorioVictimas.DevolverPorId(antecedente.Victima.Id);
            if (victima == null || victima.EstaBorrado == true)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }

            var agresor = RepositorioAgresores.DevolverPorId(antecedente.Agresor.Id);
            if (agresor == null || agresor.EstaBorrado == true)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }

            antecedente.Nombre.Trim();
            antecedente.Observaciones.Trim();
            antecedente.Perjuicios.Trim();
            antecedente.Ubicacion.Trim();
            RepositorioAntecedentes.Insertar(antecedente);
            return antecedente.Id;
        }

        public void ModificarAntecedente(Antecedente antecedente)
        {
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoValido);
            }

            var antecedenteModificar = RepositorioAntecedentes.DevolverPorId(antecedente.Id);
            if (antecedenteModificar == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoExiste);
            }

            if (String.IsNullOrWhiteSpace(antecedente.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }

            if (String.IsNullOrWhiteSpace(antecedente.Perjuicios))
            {
                throw new FaultException(Lenguaje.PerjuiciosNoValidos);
            }

            if (antecedente.Fecha == null)
            {
                throw new FaultException(Lenguaje.FechaNoValida);
            }

            if (String.IsNullOrWhiteSpace(antecedente.Ubicacion))
            {
                throw new FaultException(Lenguaje.UbicacionNoValida);
            }

            if (antecedente.Estado == null)
            {
                throw new FaultException(Lenguaje.EstadoNoValido);
            }

            if (RepositorioEstados.DevolverPorId(antecedente.Estado.Id) == null)
            {
                throw new FaultException(Lenguaje.EstadoNoValido);
            }

            if (antecedente.Victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoValida);
            }

            var victima = RepositorioVictimas.DevolverPorId(antecedente.Victima.Id);
            if (victima == null || victima.EstaBorrado == true)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }

            if (antecedente.Agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoValido);
            }

            var agresor = RepositorioAgresores.DevolverPorId(antecedente.Agresor.Id);
            if (agresor == null || agresor.EstaBorrado == true)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }

            antecedenteModificar.Estado = antecedente.Estado;
            antecedenteModificar.Nombre = antecedente.Nombre;
            antecedenteModificar.Victima = antecedente.Victima;
            antecedenteModificar.Agresor = antecedente.Agresor;
            antecedenteModificar.Fecha = antecedente.Fecha;
            antecedenteModificar.Observaciones = antecedente.Observaciones;
            antecedenteModificar.Perjuicios = antecedente.Perjuicios;
            antecedenteModificar.Ubicacion = antecedente.Ubicacion;
            antecedenteModificar.Latitud = antecedente.Latitud;
            antecedenteModificar.Longitud = antecedente.Longitud;

            RepositorioAntecedentes.Modificar(antecedenteModificar);
        }

        public void EliminarAntecedente(Antecedente antecedente)
        {
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoValido);
            }

            antecedente = RepositorioAntecedentes.DevolverPorId(antecedente.Id);
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoExiste);
            }

            RepositorioAntecedentes.Eliminar(antecedente);
        }

        public Antecedente DevolverAntecedentePorId(int id, bool puntajes)
        {
            var antecedente = RepositorioAntecedentes.DevolverPorId(id, puntajes);
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoExiste);
            }

            return antecedente;
        }

        public List<Antecedente> DevolverAntecedentesPorAgresor(Agresor agresor, bool puntajes)
        {
            if (agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoValido);
            }

            agresor = RepositorioAgresores.DevolverPorId(agresor.Id);
            if (agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }

            return RepositorioAntecedentes.DevolverPorAgresor(agresor, puntajes);
        }

        public List<Antecedente> DevolverAntecedentesPorVictima(Victima victima, bool puntajes)
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

            return RepositorioAntecedentes.DevolverPorVictima(victima, puntajes);
        }

        public List<Antecedente> DevolverAntecedentes(bool puntajes)
        {
            return RepositorioAntecedentes.DevolverTodos(puntajes);
        }

        public void AgregarPuntaje(Antecedente antecedente, Victima victima)
        {
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoValido);
            }

            antecedente = RepositorioAntecedentes.DevolverPorId(antecedente.Id);
            if (antecedente == null)
            {
                throw new FaultException(Lenguaje.AntecedenteNoExiste);
            }

            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoValida);
            }

            victima = RepositorioVictimas.DevolverPorId(victima.Id);
            if (victima == null)
            {
                throw new FaultException(Lenguaje.VictimaNoExiste);
            }

            RepositorioAntecedentes.InsertarPuntajes(antecedente, victima);
        }

        #endregion
    }
}