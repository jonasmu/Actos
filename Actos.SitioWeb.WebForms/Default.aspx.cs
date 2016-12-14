using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class Default : PaginaBase
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblActos.Text = Lenguaje.Actos;
                lnkAgresores.Text = Lenguaje.Agresores;
                lnkVictimas.Text = Lenguaje.Victimas;
                lnkAntecedentes.Text = Lenguaje.Antecedentes;

                lnkAgresores.NavigateUrl = urlAgresores;
                lnkVictimas.NavigateUrl = urlVictimas;
                lnkAntecedentes.NavigateUrl = urlAntecedentes;
            }
        }
        #endregion
    }
}