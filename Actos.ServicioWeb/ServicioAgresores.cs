using Actos.Modelo.Entidades;
using Actos.Modelo.Enumeradores;
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

        public int CrearAgresor(Agresor agresor)
        {
            if (agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoValido);
            }
            if (string.IsNullOrWhiteSpace(agresor.Nombre) &
                string.IsNullOrWhiteSpace(agresor.Apellido) &
                string.IsNullOrWhiteSpace(agresor.Apodo))
            {
                throw new FaultException(Lenguaje.AgresorSinNombreApellidoApodo);
            }

            if (string.IsNullOrEmpty(agresor.Nombre))
            {
                agresor.Nombre = string.Empty;
            }
            if (string.IsNullOrEmpty(agresor.Apellido))
            {
                agresor.Apellido = string.Empty;
            }
            if (string.IsNullOrEmpty(agresor.Apodo))
            {
                agresor.Apodo = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(agresor.Ocupacion))
            {
                throw new FaultException(Lenguaje.OcupacionNoValida);
            }
            if (string.IsNullOrWhiteSpace(agresor.Metodos))
            {
                throw new FaultException(Lenguaje.MetodosNoValidos);
            }
            if (string.IsNullOrWhiteSpace(agresor.Caracteristicas))
            {
                throw new FaultException(Lenguaje.CaracteristicasNoValidas);
            }
            agresor.EstaBorrado = false;
            agresor.Nombre.Trim();
            agresor.Apellido.Trim();
            agresor.Apodo.Trim();
            agresor.Ocupacion.Trim();
            agresor.Metodos.Trim();
            agresor.Caracteristicas.Trim();

            if (agresor.Telefonos != null)
            {
                foreach (var item in agresor.Telefonos)
                {
                    item.Localidad = RepositorioLocalidades.DevolverPorId(item.Localidad.Id);
                    if (item.Localidad == null)
                    {
                        throw new FaultException(Lenguaje.LocalidadNoValida);
                    }

                    item.Tipo = RepositorioTiposTelefonos.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoTelefonoNoValido);
                    }

                    if (string.IsNullOrWhiteSpace(item.Numero))
                    {
                        throw new FaultException(Lenguaje.NumeroNoValido);
                    }
                }
            }

            if (agresor.Direcciones != null)
            {
                foreach (var item in agresor.Direcciones)
                {
                    item.Localidad = RepositorioLocalidades.DevolverPorId(item.Localidad.Id);
                    if (item.Localidad == null)
                    {
                        throw new FaultException(Lenguaje.LocalidadNoValida);
                    }

                    item.Tipo = RepositorioTiposDirecciones.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoDireccionNoValido);
                    }
                    if (string.IsNullOrWhiteSpace(item.Calle))
                    {
                        throw new FaultException(Lenguaje.CalleNoValida);
                    }
                    if (string.IsNullOrWhiteSpace(item.Numero))
                    {
                        throw new FaultException(Lenguaje.NumeroNoValido);
                    }
                    switch ((EnumTiposDirecciones)item.Tipo.Id)
                    {
                        case EnumTiposDirecciones.Departamento:
                            if (string.IsNullOrWhiteSpace(item.Departamento) | item.Departamento.Length > 4)
                            {
                                throw new FaultException(Lenguaje.NumeroNoValido);
                            }
                            if (string.IsNullOrWhiteSpace(item.Piso) | item.Piso.Length > 3)
                            {
                                throw new FaultException(Lenguaje.NumeroNoValido);
                            }
                            break;
                        default:
                            item.Departamento = string.Empty;
                            item.Piso = string.Empty;
                            break;
                    }
                }
            }

            if (agresor.RedesSociales != null)
            {
                foreach (var item in agresor.RedesSociales)
                {
                    item.Tipo = RepositorioTiposRedesSociales.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoRedSocialNoValido);
                    }

                    if (string.IsNullOrEmpty(item.Nombre))
                    {
                        throw new FaultException(Lenguaje.NombreNoValido);
                    }
                }
            }

            RepositorioAgresores.Insertar(agresor);

            if (agresor.Telefonos != null)
            {
                foreach (var item in agresor.Telefonos)
                {
                    RepositorioAgresores.InsertarTelefono(item, agresor);
                }
            }

            if (agresor.Direcciones != null)
            {
                foreach (var item in agresor.Direcciones)
                {
                    RepositorioAgresores.InsertarDireccion(item, agresor);
                }
            }

            if (agresor.RedesSociales != null)
            {
                foreach (var item in agresor.RedesSociales)
                {
                    RepositorioAgresores.InsertarRedSocial(item, agresor);
                }
            }
            return agresor.Id;
        }

        public void ModificarAgresor(Agresor agresor)
        {
            if (agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }

            var agresorModificar = RepositorioAgresores.DevolverPorId(agresor.Id);
            if (agresorModificar == null)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }
            if (agresorModificar.EstaBorrado)
            {
                throw new FaultException(Lenguaje.AgresorYaEliminado);
            }
            if (string.IsNullOrWhiteSpace(agresor.Nombre) &
                string.IsNullOrWhiteSpace(agresor.Apellido) &
                string.IsNullOrWhiteSpace(agresor.Apodo))
            {
                throw new FaultException(Lenguaje.AgresorSinNombreApellidoApodo);
            }

            if (string.IsNullOrEmpty(agresor.Nombre))
            {
                agresor.Nombre = string.Empty;
            }
            if (string.IsNullOrEmpty(agresor.Apellido))
            {
                agresor.Apellido = string.Empty;
            }
            if (string.IsNullOrEmpty(agresor.Apodo))
            {
                agresor.Apodo = string.Empty;
            }


            if (string.IsNullOrWhiteSpace(agresor.Ocupacion))
            {
                throw new FaultException(Lenguaje.OcupacionNoValida);
            }
            if (string.IsNullOrWhiteSpace(agresor.Metodos))
            {
                throw new FaultException(Lenguaje.MetodosNoValidos);
            }
            if (string.IsNullOrWhiteSpace(agresor.Caracteristicas))
            {
                throw new FaultException(Lenguaje.CaracteristicasNoValidas);
            }
            agresorModificar.Nombre = agresor.Nombre.Trim();
            agresorModificar.Apellido = agresor.Apellido.Trim();
            agresorModificar.Apodo = agresor.Apodo.Trim();
            agresorModificar.Ocupacion = agresor.Ocupacion.Trim();
            agresorModificar.Metodos = agresor.Metodos.Trim();
            agresorModificar.Direcciones = agresor.Direcciones;
            agresorModificar.RedesSociales = agresor.RedesSociales;
            agresorModificar.Telefonos = agresor.Telefonos;
            agresorModificar.Caracteristicas = agresor.Caracteristicas.Trim();

            if (agresor.Telefonos != null)
            {
                foreach (var item in agresor.Telefonos)
                {
                    item.Localidad = RepositorioLocalidades.DevolverPorId(item.Localidad.Id);
                    if (item.Localidad == null)
                    {
                        throw new FaultException(Lenguaje.LocalidadNoValida);
                    }

                    item.Tipo = RepositorioTiposTelefonos.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoTelefonoNoValido);
                    }

                    if (string.IsNullOrWhiteSpace(item.Numero))
                    {
                        throw new FaultException(Lenguaje.NumeroNoValido);
                    }
                }
            }

            if (agresor.Direcciones != null)
            {
                foreach (var item in agresor.Direcciones)
                {
                    item.Localidad = RepositorioLocalidades.DevolverPorId(item.Localidad.Id);
                    if (item.Localidad == null)
                    {
                        throw new FaultException(Lenguaje.LocalidadNoValida);
                    }

                    item.Tipo = RepositorioTiposDirecciones.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoDireccionNoValido);
                    }
                    if (string.IsNullOrWhiteSpace(item.Calle))
                    {
                        throw new FaultException(Lenguaje.CalleNoValida);
                    }
                    if (string.IsNullOrWhiteSpace(item.Numero))
                    {
                        throw new FaultException(Lenguaje.NumeroNoValido);
                    }
                    switch ((EnumTiposDirecciones)item.Tipo.Id)
                    {
                        case EnumTiposDirecciones.Departamento:
                            if (string.IsNullOrWhiteSpace(item.Departamento) | item.Departamento.Length > 4)
                            {
                                throw new FaultException(Lenguaje.DepartamentoNoValido);
                            }
                            if (string.IsNullOrWhiteSpace(item.Piso) | item.Piso.Length > 3)
                            {
                                throw new FaultException(Lenguaje.PisoNoValido);
                            }
                            break;
                        default:
                            item.Departamento = string.Empty;
                            item.Piso = string.Empty;
                            break;
                    }
                }
            }

            if (agresor.RedesSociales != null)
            {
                foreach (var item in agresor.RedesSociales)
                {
                    item.Tipo = RepositorioTiposRedesSociales.DevolverPorId(item.Tipo.Id);
                    if (item.Tipo == null)
                    {
                        throw new FaultException(Lenguaje.TipoRedSocialNoValido);
                    }

                    if (string.IsNullOrEmpty(item.Nombre))
                    {
                        throw new FaultException(Lenguaje.NombreNoValido);
                    }
                }
            }

            RepositorioAgresores.Modificar(agresorModificar);

            RepositorioAgresores.EliminarTelefonoPorAgresor(agresorModificar);
            if (agresorModificar.Telefonos != null)
            {
                foreach (var item in agresorModificar.Telefonos)
                {
                    RepositorioAgresores.InsertarTelefono(item, agresorModificar);
                }
            }

            RepositorioAgresores.EliminarDireccionPorAgresor(agresorModificar);
            if (agresorModificar.Direcciones != null)
            {
                foreach (var item in agresorModificar.Direcciones)
                {
                    RepositorioAgresores.InsertarDireccion(item, agresorModificar);
                }
            }

            RepositorioAgresores.EliminarRedSocialPorAgresor(agresorModificar);
            if (agresorModificar.RedesSociales != null)
            {
                foreach (var item in agresorModificar.RedesSociales)
                {
                    RepositorioAgresores.InsertarRedSocial(item, agresorModificar);
                }
            }
        }

        public void EliminarAgresor(Agresor agresor)
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
            if (agresor.EstaBorrado)
            {
                throw new FaultException(Lenguaje.AgresorYaEliminado);
            }
            agresor.EstaBorrado = true;
            RepositorioAgresores.Modificar(agresor);

        }


        public Agresor DevolverAgresorPorId(int id, bool telefonos, bool direcciones, bool redesSociales)
        {
            var agresor = RepositorioAgresores.DevolverPorId(id, telefonos, direcciones, redesSociales);
            if (agresor == null)
            {
                throw new FaultException(Lenguaje.AgresorNoExiste);
            }
            return agresor;
        }

        public List<Agresor> DevolverAgresores(bool telefonos, bool direcciones, bool redesSociales)
        {
            return RepositorioAgresores.DevolverTodos(telefonos, direcciones, redesSociales);
        }

        #endregion
    }
}