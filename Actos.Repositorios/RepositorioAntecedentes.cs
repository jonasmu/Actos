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
    public class RepositorioAntecedentes : RepositorioEntidad<Antecedente, int, IAccesoDatosAntecedentes>
    {
        #region Constructores
        public RepositorioAntecedentes()
        {
            accesoDatos = new AccesoDatosAntecedentes();
        }
        #endregion

        #region Atributos

        private RepositorioEstados repositorioEstados = new RepositorioEstados();
        private RepositorioVictimas repositorioVictimas = new RepositorioVictimas();
        private RepositorioAgresores repositorioAgresores = new RepositorioAgresores();

        #endregion

        #region Metodos

        protected override Antecedente FilaAEntidad(DataRow fila)
        {
            var antecedente = new Antecedente();
            antecedente.Id = (int)fila["IdAntecedente"];
            antecedente.Estado = repositorioEstados.DevolverPorId((byte)fila["IdEstado"]);
            antecedente.Agresor = repositorioAgresores.DevolverPorId((int)fila["IdAgresor"]);
            antecedente.Victima = repositorioVictimas.DevolverPorId((int)fila["IdVictima"]);
            antecedente.Nombre = (string)fila["Nombre"];
            antecedente.Fecha = (DateTime)fila["Fecha"];
            antecedente.Ubicacion = (string)fila["Ubicacion"];
            antecedente.Latitud = (double)fila["Latitud"];
            antecedente.Longitud = (double)fila["Longitud"];
            antecedente.Observaciones = (string)fila["Observaciones"];
            antecedente.Perjuicios = (string)fila["Perjuicios"];
            return antecedente;
        }

        public override Antecedente DevolverPorId(int id)
        {
            return DevolverPorId(id, true);
        }

        public Antecedente DevolverPorId(int id, bool puntajes)
        {
            var antecedente = entidades.Where(x => x.Id == id).SingleOrDefault();
            if (antecedente == null)
            {
                using (var dt = accesoDatos.Antecedentes_DevolverPorId(id))
                {
                    if (dt.Rows.Count != 0)
                    {
                        antecedente = FilaAEntidad(dt.Rows[0]);
                        if (puntajes)
                        {
                            antecedente.Puntajes = DevolverPuntajesPorAntecedente(antecedente);
                        }
                        entidades.Add(antecedente);
                    }
                }
            }
            return antecedente;
        }

        public void Insertar(Antecedente antecedente)
        {
            antecedente.Id = accesoDatos.Antecedentes_Insertar(antecedente);
        }

        public void Modificar(Antecedente antecedente)
        {
            accesoDatos.Antecedentes_Modificar(antecedente);
        }

        public void Eliminar(Antecedente antecedente)
        {
            accesoDatos.Antecedentes_Eliminar(antecedente);
            accesoDatos.AntecedentesVictimas_EliminarPorAntecedente(antecedente);
        }

        public List<Antecedente> DevolverTodos(bool puntajes)
        {
            using (var dt = accesoDatos.Antecedentes_DevolverTodos())
            {
                entidades = TablaALista(dt);
                if (puntajes)
                {
                    foreach (var item in entidades)
                    {
                        item.Puntajes = DevolverPuntajesPorAntecedente(item);
                    }
                }
            }
            return entidades;
        }

        public List<Antecedente> DevolverPorAgresor(Agresor agresor, bool puntajes)
        {
            using (var dt = accesoDatos.Antecedentes_DevolverPorAgresor(agresor))
            {
                entidades = TablaALista(dt);
                if (puntajes)
                {
                    foreach (var item in entidades)
                    {
                        item.Puntajes = DevolverPuntajesPorAntecedente(item);
                    }
                }
            }
            return entidades;
        }

        public List<Antecedente> DevolverPorVictima(Victima victima, bool puntajes)
        {
            using (var dt = accesoDatos.Antecedentes_DevolverPorVictima(victima))
            {
                entidades = TablaALista(dt);
                if (puntajes)
                {
                    foreach (var item in entidades)
                    {
                        item.Puntajes = DevolverPuntajesPorAntecedente(item);
                    }
                }
            }
            return entidades;
        }


        public void InsertarPuntajes(Antecedente antecedente, Victima victima)
        {
            accesoDatos.AntecedentesVictimas_Insertar(antecedente, victima);
        }

        private List<Victima> DevolverPuntajesPorAntecedente(Antecedente antecedente)
        {
            var lista = new List<Victima>();
            using (var dt = accesoDatos.AntecedentesVictimas_DevolverPorAntecedente(antecedente))
            {
                foreach (DataRow fila in dt.Rows)
                {
                    lista.Add(repositorioVictimas.DevolverPorId((int)fila["IdVictima"]));
                }
            }
            return lista;
        }

        private void EliminarPuntajesPorAntecedente(Antecedente antecedente)
        {
            accesoDatos.AntecedentesVictimas_EliminarPorAntecedente(antecedente);
        }

        #endregion
    }
}
