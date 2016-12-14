using Actos.Utiles;
using Actos.SitioWeb.WebForms.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class Antecedentes : PaginaBase
    {
        #region Enumeradores
        enum Enum_DdlFiltro
        {
            Todos,
            PorNombre,
            PorVictima,
            PorAgresor,
            PorUbicacion,
            PorPerjuicios
        }

        enum Enum_DdlPuntajes
        {
            Todos,
            SinPuntos,
            Bajos,
            Medios,
            Altos
        }

        enum Enum_DdlEstado
        {
            Activo,
            Inactivo
        }
        #endregion

        #region Metodos
        private void Buscar()
        {
            var dondeBuscar = servicioWeb.DevolverAntecedentes(true).ToList();
            /*FILTRO ESTADO*/
            switch (ddlEstado.SelectedIndex)
            {
                case (int)Enum_DdlEstado.Activo:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Estado.Id == 1
                                   select item).ToList();
                    break;
                case (int)Enum_DdlEstado.Inactivo:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Estado.Id == 2
                                   select item).ToList();
                    break;
            }


            /*FILTRO PUNTAJES*/
            switch (ddlPuntajes.SelectedIndex)
            {
                case (int)Enum_DdlPuntajes.Todos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntajes.Length >= 0
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.SinPuntos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntajes.Length == 0
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Bajos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntajes.Length > 1
                                   && item.Puntajes.Length < 15
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Medios:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntajes.Length > 15
                                   && item.Puntajes.Length < 30
                                   select item).ToList();
                    break;
                case (int)Enum_DdlPuntajes.Altos:
                    dondeBuscar = (from item in dondeBuscar
                                   where item.Puntajes.Length > 30
                                   select item).ToList();
                    break;
            }


            /*FILTRO TEXTO*/
            var queBuscar = txtBuscar.Text.ToLower().Trim();
            var resultado = new List<Antecedente>();

            switch (ddlFiltro.SelectedIndex)
            {
                case (int)Enum_DdlFiltro.Todos:
                    resultado = (from item in dondeBuscar
                                 where item.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Victima.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Victima.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Victima.Apodo.ToLower().Trim().Contains(queBuscar)
                                 || item.Agresor.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Agresor.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Agresor.Apodo.ToLower().Trim().Contains(queBuscar)
                                 || item.Ubicacion.ToLower().Trim().Contains(queBuscar)
                                  || item.Perjuicios.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorNombre:
                    resultado = (from item in dondeBuscar
                                 where item.Nombre.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorVictima:
                    resultado = (from item in dondeBuscar
                                 where item.Victima.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Victima.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Victima.Apodo.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorAgresor:
                    resultado = (from item in dondeBuscar
                                 where item.Agresor.Nombre.ToLower().Trim().Contains(queBuscar)
                                 || item.Agresor.Apellido.ToLower().Trim().Contains(queBuscar)
                                 || item.Agresor.Apodo.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorUbicacion:
                    resultado = (from item in dondeBuscar
                                 where item.Ubicacion.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
                case (int)Enum_DdlFiltro.PorPerjuicios:
                    resultado = (from item in dondeBuscar
                                 where item.Perjuicios.ToLower().Trim().Contains(queBuscar)
                                 select item).ToList();
                    break;
            }

            grdAntecedentes.DataSource = resultado;
            grdAntecedentes.DataBind();
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuAntecedentes")).Attributes.Add("class", "activado");

                lnkNuevoAntecedente.Text = Lenguaje.Nuevo;
                lnkNuevoAntecedente.NavigateUrl = urlAntecedentesNuevo;

                lblEstado.Text = Lenguaje.Estado;
                lblFiltros.Text = Lenguaje.Filtros;
                lblPuntajes.Text = Lenguaje.Puntajes;

                ddlEstado.Items.Add(new ListItem(Lenguaje.Activo, "0"));
                ddlEstado.Items.Add(new ListItem(Lenguaje.Inactivo, "1"));

                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Todos, "0"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.SinPuntos, "1"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Bajos, "2"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Medios, "3"));
                ddlPuntajes.Items.Add(new ListItem(Lenguaje.Altos, "4"));
                ddlPuntajes.SelectedValue = "0";

                ddlFiltro.Items.Add(new ListItem(Lenguaje.Todos, "0"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorNombre, "1"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorVictima, "2"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorAgresor, "3"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorUbicacion, "4"));
                ddlFiltro.Items.Add(new ListItem(Lenguaje.PorPerjuicios, "5"));
                ddlFiltro.SelectedValue = "0";

                grdAntecedentes.DataSource = servicioWeb.DevolverAntecedentes(true);
                grdAntecedentes.DataBind();
            }
        }

        protected void lnkBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            UpdatePanel1.Update();
        }

        protected void grdAntecedentes_PreRender(object sender, EventArgs e)
        {
            grdAntecedentes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion
    }
}