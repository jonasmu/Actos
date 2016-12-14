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
    public partial class Victimas : PaginaBase
    {
        #region Enumeradores

        enum Enum_DdlFiltro
        {
            Todos,
            PorNombre,
            PorApellido,
            PorApodo
        }

        #endregion

        #region Metodos
        private void Buscar()
        {
            var queBuscar = txtBuscar.Text.ToLower().Trim();
            var dondeBuscar = servicioWeb.DevolverVictimas().ToList();
            var resultado = new List<Victima>();

            switch (ddlFiltro.SelectedIndex)
            {
                case (int)Enum_DdlFiltro.Todos:
                    resultado = (from item in dondeBuscar
                                 where item.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Apodo.ToLower().Trim().Contains(queBuscar)
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
            }

            grdVictimas.DataSource = resultado;
            grdVictimas.DataBind();
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuVictimas")).Attributes.Add("class", "activado");

                lnkNuevaVictima.Text = Lenguaje.Nuevo;
                lnkNuevaVictima.NavigateUrl = urlVictimasNuevo;

                lblFiltros.Text = Lenguaje.Filtros;

                ddlFiltro.Items.Add(new ListItem(Lenguaje.Todos, "0"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorNombre, "1"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorApellido, "2"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorApodo, "3"));
                ddlFiltro.SelectedValue = "0";

                grdVictimas.DataSource = servicioWeb.DevolverVictimas();
                grdVictimas.DataBind();
            }
        }

        protected void grdVictimas_PreRender(object sender, EventArgs e)
        {
            grdVictimas.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion

        protected void lnkBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            UpdatePanel1.Update();
        }
    }
}