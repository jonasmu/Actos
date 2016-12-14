using Actos.AccesoDatos.Interfaces;
using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Actos.AccesoDatos;

namespace Actos.Repositorios
{
    public class RepositorioAgresores : RepositorioEntidad<Agresor, int, IAccesoDatosAgresores>
    {
        #region Constructores
        public RepositorioAgresores()
        {
            accesoDatos = new AccesoDatosAgresores();
        }
        #endregion

        #region Atributos

        private RepositorioTiposDirecciones repositorioTiposDirecciones = new RepositorioTiposDirecciones();
        private RepositorioTiposRedesSociales repositorioTiposRedesSociales = new RepositorioTiposRedesSociales();
        private RepositorioTiposTelefonos repositorioTiposTelefonos = new RepositorioTiposTelefonos();
        private RepositorioLocalidades repositorioLocalidades = new RepositorioLocalidades();

        #endregion

        #region Metodos

        /*FILA A ENTIDAD*/

        private Telefono FilaATelefono(DataRow fila)
        {
            var telefono = new Telefono();
            telefono.Id = (int)fila["IdAgresorTelefono"];
            telefono.Tipo = repositorioTiposTelefonos.DevolverPorId((byte)fila["IdTipoTelefono"]);
            telefono.Localidad = repositorioLocalidades.DevolverPorId((int)fila["IdLocalidad"]);
            telefono.Numero = (string)fila["Numero"];
            return telefono;
        }

        private RedSocial FilaARedSocial(DataRow fila)
        {
            var redSocial = new RedSocial();
            redSocial.Id = (int)fila["IdAgresorRedSocial"];
            redSocial.Tipo = repositorioTiposRedesSociales.DevolverPorId((byte)fila["IdTipoRedSocial"]);
            redSocial.Nombre = (string)fila["Nombre"];
            return redSocial;
        }

        private Direccion FilaADireccion(DataRow fila)
        {
            var direccion = new Direccion();
            direccion.Id = (int)fila["IdAgresorDireccion"];
            direccion.Tipo = repositorioTiposDirecciones.DevolverPorId((byte)fila["IdTipoDireccion"]);
            direccion.Localidad = repositorioLocalidades.DevolverPorId((int)fila["IdLocalidad"]);
            direccion.Calle = (string)fila["Calle"];
            direccion.Numero = (string)fila["Numero"];
            direccion.Departamento = (string)fila["Departamento"];
            direccion.Piso = (string)fila["Piso"];
            return direccion;
        }

        protected override Agresor FilaAEntidad(DataRow fila)
        {
            var agresor = new Agresor();
            agresor.Id = (int)fila["IdAgresor"];
            agresor.Nombre = (string)fila["Nombre"];
            agresor.Apellido = (string)fila["Apellido"];
            agresor.Apodo = (string)fila["Apodo"];
            agresor.Ocupacion = (string)fila["Ocupacion"];
            agresor.Caracteristicas = (string)fila["Caracteristicas"];
            agresor.Metodos = (string)fila["Metodos"];
            agresor.EstaBorrado = (bool)fila["EstaBorrado"];
            if (fila["Foto"].Equals(DBNull.Value))
            {
                agresor.Foto = null;
            }
            else
            {
                agresor.Foto = (byte[])fila["Foto"];
            }
            agresor.Puntaje = (int)fila["Puntaje"];
            return agresor;
        }

        /*AGRESOR*/

        public override Agresor DevolverPorId(int id)
        {
            return DevolverPorId(id, true, true, true);
        }

        public Agresor DevolverPorId(int id, bool telefonos, bool direcciones, bool redesSociales)
        {
            var agresor = entidades.Where(x => x.Id == id).SingleOrDefault();
            if (agresor == null)
            {
                using (var dt = accesoDatos.Agresores_DevolverPorId(id))
                {
                    if (dt.Rows.Count != 0)
                    {
                        agresor = FilaAEntidad(dt.Rows[0]);
                        if (telefonos)
                        {
                            agresor.Telefonos = DevolverTelefonosPorAgresor(agresor);
                        }
                        if (direcciones)
                        {
                            agresor.Direcciones = DevolverDireccionesPorAgresor(agresor);
                        }
                        if (redesSociales)
                        {
                            agresor.RedesSociales = DevolverRedesSocialesPorAgresor(agresor);
                        }
                        entidades.Add(agresor);
                    }
                }
            }
            return agresor;
        }

        public void Insertar(Agresor agresor)
        {
            agresor.Id = accesoDatos.Agresores_Insertar(agresor);
        }

        public void Modificar(Agresor agresor)
        {
            accesoDatos.Agresores_Modificar(agresor);
        }

        public List<Agresor> DevolverTodos(bool telefonos, bool direcciones, bool redesSociales)
        {
            using (var dt = accesoDatos.Agresores_DevolverTodos())
            {
                entidades = TablaALista(dt);
                foreach (var item in entidades)
                {
                    if (telefonos)
                    {
                        item.Telefonos = DevolverTelefonosPorAgresor(item);
                    }
                    if (direcciones)
                    {
                        item.RedesSociales = DevolverRedesSocialesPorAgresor(item);
                    }
                    if (redesSociales)
                    {
                        item.Direcciones = DevolverDireccionesPorAgresor(item);
                    }
                }
            }
            return entidades;
        }


        /*DEVOLVER POR AGRESOR*/

        private List<Telefono> DevolverTelefonosPorAgresor(Agresor agresor)
        {
            var lista = new List<Telefono>();
            using (var dt = accesoDatos.AgresoresTelefonos_DevolverPorAgresor(agresor))
            {
                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(FilaATelefono(fila));
                }
            }
            return lista;
        }

        private List<RedSocial> DevolverRedesSocialesPorAgresor(Agresor agresor)
        {
            var lista = new List<RedSocial>();
            using (var dt = accesoDatos.AgresoresRedesSociales_DevolverPorAgresor(agresor))
            {
                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(FilaARedSocial(fila));
                }
            }
            return lista;
        }

        private List<Direccion> DevolverDireccionesPorAgresor(Agresor agresor)
        {
            var lista = new List<Direccion>();
            using (var dt = accesoDatos.AgresoresDirecciones_DevolverPorAgresor(agresor))
            {
                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(FilaADireccion(fila));
                }
            }
            return lista;
        }


        /*INSERTAR POR AGRESOR*/

        public void InsertarTelefono(Telefono telefono, Agresor agresor)
        {
            telefono.Id = accesoDatos.AgresoresTelefonos_Insertar(telefono, agresor);
        }

        public void InsertarRedSocial(RedSocial redSocial, Agresor agresor)
        {
            redSocial.Id = accesoDatos.AgresoresRedesSociales_Insertar(redSocial, agresor);
        }

        public void InsertarDireccion(Direccion direccion, Agresor agresor)
        {
            direccion.Id = accesoDatos.AgresoresDirecciones_Insertar(direccion, agresor);
        }


        /*ELIMINAR POR AGRESOR*/

        public void EliminarTelefonoPorAgresor(Agresor agresor)
        {
            accesoDatos.AgresoresTelefonos_EliminarPorAgresor(agresor);
        }

        public void EliminarRedSocialPorAgresor(Agresor agresor)
        {
            accesoDatos.AgresoresRedesSociales_EliminarPorAgresor(agresor);
        }

        public void EliminarDireccionPorAgresor(Agresor agresor)
        {
            accesoDatos.AgresoresDirecciones_EliminarPorAgresor(agresor);
        }

        #endregion
    }
}
