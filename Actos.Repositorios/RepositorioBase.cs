using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

    /*Clase PAPA
    * esta hereda a todas*/


namespace Actos.Repositorios
{
    public abstract class RepositorioBase<TEntidad, TIdentidad, TAccesoDatos>
        where TEntidad : EntidadBase<TIdentidad>
    {
        /*Es "internal" porque solo se va a  
         * utilizar en el ensamblado/proyecto*/

        #region Atributos
        internal TAccesoDatos accesoDatos;
        #endregion

        #region Metodo

            /*Conversor de texto plano de DataTable/DataSet*/

        protected abstract TEntidad FilaAEntidad(DataRow fila);

        public List<TEntidad> TablaALista(DataTable tabla)
        {
            var lista = new List<TEntidad>();
            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(FilaAEntidad(fila));
            }
            return lista;
        }

        #endregion
    }
}
