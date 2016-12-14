using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class Portal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Lenguaje.Actos;

            lnkAgresores.Text = Lenguaje.Agresores;
            lnkVictimas.Text = Lenguaje.Victimas;
            lnkAntecedentes.Text = Lenguaje.Antecedentes;

            lnkAgresores.NavigateUrl = "~/Agresores.aspx";
            lnkVictimas.NavigateUrl = "~/Victimas.aspx";
            lnkAntecedentes.NavigateUrl = "~/Antecedentes.aspx";
        }
    }
}