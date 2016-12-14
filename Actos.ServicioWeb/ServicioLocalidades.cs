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

        public int CrearLocalidad(Localidad localidad)
        {
            if (localidad == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoValida);
            }

            if (string.IsNullOrWhiteSpace(localidad.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }

            if (string.IsNullOrWhiteSpace(localidad.CodigoArea))
            {
                throw new FaultException(Lenguaje.CodigoAreaNoValido);
            }

            int valor;
            if (int.TryParse(localidad.CodigoArea, out valor) == false)
            {
                throw new FaultException(Lenguaje.CodigoAreaNoNumerico);
            }

            localidad.Nombre.Trim();
            localidad.CodigoArea.Trim();
            RepositorioLocalidades.Insertar(localidad);
            return localidad.Id;
        }

        public void ModificarLocalidad(Localidad localidad)
        {
            if (localidad == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoValida);
            }

            var localidadModificar = RepositorioLocalidades.DevolverPorId(localidad.Id);
            if (localidadModificar == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoExiste);
            }

            if (string.IsNullOrWhiteSpace(localidad.Nombre))
            {
                throw new FaultException(Lenguaje.NombreNoValido);
            }

            if (string.IsNullOrWhiteSpace(localidad.CodigoArea))
            {
                throw new FaultException(Lenguaje.CodigoAreaNoValido);
            }

            int valor;
            if (int.TryParse(localidad.CodigoArea, out valor) == false)
            {
                throw new FaultException(Lenguaje.CodigoAreaNoNumerico);
            }

            localidadModificar.Nombre = localidad.Nombre;
            localidadModificar.CodigoArea = localidad.CodigoArea;

            RepositorioLocalidades.Modificar(localidadModificar);
        }

        public Localidad EliminarLocalidad(Localidad localidad, Localidad localidadReemplazo)
        {
            if (localidad == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoValida);
            }

            if (localidadReemplazo == null)
            {
                throw new FaultException(Lenguaje.LocalidadReemplazoNoValida);
            }

            if (RepositorioLocalidades.DevolverPorId(localidad.Id) == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoExiste);
            }

            localidadReemplazo = RepositorioLocalidades.DevolverPorId(localidadReemplazo.Id);
            if (localidadReemplazo == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoExiste);
            }
            RepositorioLocalidades.Eliminar(localidad);

            return localidadReemplazo;
        }

        public Localidad DevolverLocalidadPorId(int id)
        {
            var localidad = RepositorioLocalidades.DevolverPorId(id);
            if (localidad == null)
            {
                throw new FaultException(Lenguaje.LocalidadNoExiste);
            }

            return localidad;
        }

        public List<Localidad> DevolverLocalidad()
        {
            return RepositorioLocalidades.DevolverTodos();
        }

        #endregion
    }
}