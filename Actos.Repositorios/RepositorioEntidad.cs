using Actos.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

    /*Clase ABSTRACTA, tiene un rol intermediario
    * existe para incorporar el metodo DevolverPorId
    * que no fue introducido en RepositorioBase porque
    * no todas las clases necesitan DevolverPorId...
    * Por ejemplo: todos las clases Tipo
    * 
    * Ademas para mantener el codigo limpio,
    * se crea la lista de entidades ACA,
    * pero se usa en las clases hijas */


namespace Actos.Repositorios
{
    public abstract class RepositorioEntidad<TEntidad, TIdentidad, TAccesoDatos> : RepositorioBase<TEntidad, TIdentidad, TAccesoDatos>
        where TEntidad : EntidadBase<TIdentidad>
    {
            /*Crea lista de entidades (polimorfismo),
            * es "protected" porque lo utiliza las clases que heredan de esta*/

        #region Atributos
        protected List<TEntidad> entidades = new List<TEntidad>();
        #endregion


            /*Metodo necesario para las clases hijas de entidades */

        #region Metodos
        public abstract TEntidad DevolverPorId(TIdentidad id);
        #endregion
    }
}
