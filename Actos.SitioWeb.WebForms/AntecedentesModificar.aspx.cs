using Actos.SitioWeb.WebForms.ServicioWeb;
using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class AntecedentesModificar : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnIdAntecedente.Value = Request.QueryString["id"];
                var id = Convert.ToInt32(hdnIdAntecedente.Value);

                ddlEstado.DataSource = servicioWeb.DevolverEstados();
                ddlEstado.DataValueField = "Id";
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataBind();

                var antecedente = servicioWeb.DevolverAntecedentePorId(id, false);
                txtNombre.Text = antecedente.Nombre;
                ddlEstado.SelectedValue = Convert.ToString(antecedente.Estado.Id);
                txtFecha.Text = antecedente.Fecha.ToString("yyyy-MM-dd");
                txtObservaciones.Text = antecedente.Observaciones;
                txtPerjuicios.Text = antecedente.Perjuicios;
                txtUbicacion.Text = antecedente.Ubicacion;

                var victima = antecedente.Victima;
                hdnIdVictima.Value = Convert.ToString(victima.Id);
                litVictima.Text = string.Format("{0} {1} {2}", victima.Nombre, victima.Apellido, victima.Apodo).Trim();

                var agresor = antecedente.Agresor;
                hdnIdAgresor.Value = Convert.ToString(agresor.Id);
                litAgresor.Text = string.Format("{0} {1} {2}", agresor.Nombre, agresor.Apellido, agresor.Apodo).Trim();

                lblNombre.Text = Lenguaje.Nombre;
                lblEstado.Text = Lenguaje.Estado;
                lblFecha.Text = Lenguaje.Fecha;
                lblObservaciones.Text = Lenguaje.Observaciones;
                lblPerjuicios.Text = Lenguaje.Perjuicios;
                lblUbicacion.Text = Lenguaje.Ubicacion;

                hdnIsGrdVictimasLoad.Value = "false";
                hdnIsGrdAgresoresLoad.Value = "false";

                lnkAplicarCambios.Text = Lenguaje.AplicarCambios;
            }
        }

        protected void btnVictima_Click(object sender, EventArgs e)
        {
            if (hdnIsGrdVictimasLoad.Value == "false")
            {
                grdVictimas.DataSource = servicioWeb.DevolverVictimas();
                grdVictimas.DataBind();
                updVictimas.Update();
                hdnIsGrdVictimasLoad.Value = "true";
            }
        }

        protected void btnAgresor_Click(object sender, EventArgs e)
        {
            if (hdnIsGrdAgresoresLoad.Value == "false")
            {
                grdAgresores.DataSource = servicioWeb.DevolverAgresores(false, false, false);
                grdAgresores.DataBind();
                updAgresores.Update();
                hdnIsGrdAgresoresLoad.Value = "true";
            }
        }

        protected void lnkAplicarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                var antecedente = new Antecedente();
                antecedente.Id = Convert.ToInt32(hdnIdAntecedente.Value);
                antecedente.Estado = new Estado { Id = Convert.ToByte(ddlEstado.SelectedValue) };
                antecedente.Nombre = txtNombre.Text;
                antecedente.Fecha = Convert.ToDateTime(txtFecha.Text);
                antecedente.Observaciones = txtObservaciones.Text;
                antecedente.Perjuicios = txtPerjuicios.Text;
                antecedente.Ubicacion = txtUbicacion.Text;
                antecedente.Latitud = 0;
                antecedente.Longitud = 0;

                antecedente.Victima = new Victima { Id = Convert.ToInt32(hdnIdVictima.Value) };
                antecedente.Agresor = new Agresor { Id = Convert.ToInt32(hdnIdAgresor.Value) };

                servicioWeb.ModificarAntecedente(antecedente);
                Response.Redirect(QueryStrings_Url(urlAntecedentesDetalle, "id=" + hdnIdAntecedente.Value));
            }
            catch (Exception ex)
            {
                litMensaje.Visible = true;
                litMensaje.Text = ex.Message;
            }
        }
    }
}