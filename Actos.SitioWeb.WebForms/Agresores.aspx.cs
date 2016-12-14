using Actos.SitioWeb.WebForms.ServicioWeb;
using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class Agresores : PaginaBase
    {
        #region Enumeradores
        enum Enum_DdlFiltro
        {
            Todos,
            PorNombre,
            PorApellido,
            PorApodo,
            PorOcupacion
        }

        enum Enum_DdlPuntajes
        {
            Todos,
            SinPuntos,
            Bajos,
            Medios,
            Altos
        }
        #endregion

        #region Metodos
        private void Buscar()
        {
            var dondeBuscar = servicioWeb.DevolverAgresores(false, false, false).ToList();
            /*FILTRO PUNTAJES*/

            switch (ddlPuntajes.SelectedIndex)
            {
                case (int)Enum_DdlPuntajes.Todos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntaje >= 0
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.SinPuntos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntaje == 0
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Bajos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntaje > 1
                                   && item.Puntaje < 15
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Medios:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntaje > 15
                                   && item.Puntaje < 30
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Altos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntaje > 30
                                   select item).ToList();
                    break;
            }


            /*FILTRO TEXTO*/
            var queBuscar = txtBuscar.Text.ToLower().Trim();
            var resultado = new List<Agresor>();

            switch (ddlFiltro.SelectedIndex)
            {
                case (int)Enum_DdlFiltro.Todos:
                    resultado = (from item in dondeBuscar
                                 where item.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Apodo.ToLower().Trim().Contains(queBuscar)
                                 || item.Ocupacion.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorNombre:
                    resultado = (from item in dondeBuscar
                                 where item.Nombre.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorApellido:
                    resultado = (from item in dondeBuscar
                                 where item.Apellido.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorApodo:
                    resultado = (from item in dondeBuscar
                                 where item.Apodo.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorOcupacion:
                    resultado = (from item in dondeBuscar
                                 where item.Ocupacion.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
            }

            grdAgresores.DataSource = resultado;
            grdAgresores.DataBind();
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuAgresores")).Attributes.Add("class", "activado");

                lnkNuevoAgresor.Text = Lenguaje.Nuevo;
                lnkNuevoAgresor.NavigateUrl = urlAgresoresNuevo;

                lblFiltros.Text = Lenguaje.Filtros;
                lblPuntajes.Text = Lenguaje.Puntajes;

                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Todos, "0"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.SinPuntos, "1"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Bajos, "2"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Medios, "3"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Altos, "4"));
                ddlPuntajes.SelectedValue = "0";

                ddlFiltro.Items.Add(new ListItem(Lenguaje.Todos, "0"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorNombre, "1"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorApellido, "2"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorApodo, "3"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorOcupacion, "4"));
                ddlFiltro.SelectedValue = "0";

                grdAgresores.DataSource = servicioWeb.DevolverAgresores(false, false, false);
                grdAgresores.DataBind();
            }
        }

        protected void lnkBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            UpdatePanel1.Update();
        }

        protected void grdAgresores_PreRender(object sender, EventArgs e)
        {
            grdAgresores.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion
    }
}