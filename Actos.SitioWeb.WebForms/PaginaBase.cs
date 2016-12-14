using Actos.SitioWeb.WebForms.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Actos.SitioWeb.WebForms
{
    public abstract class PaginaBase : System.Web.UI.Page
    {
        #region Atributos

        protected ServicioClient servicioWeb = new ServicioClient();

        protected string urlAgresores = @"~/Agresores.aspx";
        protected string urlAgresoresDetalle = @"~/AgresoresDetalle.aspx";
        protected string urlAgresoresNuevo = @"~/AgresoresNuevo.aspx";
        protected string urlAgresoresModificar = @"~/AgresoresModificar.aspx";

        protected string urlVictimas = @"~/Victimas.aspx";
        protected string urlVictimasDetalle = @"~/VictimasDetalle.aspx";
        protected string urlVictimasNuevo = @"~/VictimasNuevo.aspx";
        protected string urlVictimasModificar = @"~/VictimasModificar.aspx";

        protected string urlAntecedentes = @"~/Antecedentes.aspx";
        protected string urlAntecedentesDetalle = @"~/AntecedentesDetalle.aspx";
        protected string urlAntecedentesNuevo = @"~/AntecedentesNuevo.aspx";
        protected string urlAntecedentesModificar = @"~/AntecedentesModificar.aspx";
        #endregion

        #region Metodos


        /// <summary>
        /// Agrega querystring a dirección url.
        /// Escribir "direccion url", "clave = valor".
        /// No hace falta el signo ?.
        /// Por ejemplo: "pepe.aspx, id = 1"
        /// </summary>
        /// <param name="queryStrings"></param>
        /// <returns>?key=value</returns>
        public string QueryStrings_Url(string url, params string[] queryStrings)
        {
            url += "?";
            for (int i = 0; i < queryStrings.Length; i++)
            {
                url += queryStrings[i];
            }


            return url;
        }
        #endregion
    }
}