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
    public partial class VictimasModificar : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuVictimas")).Attributes.Add("class", "activado");

                hdnIdVictima.Value = Request.QueryString["Id"];
                var victima = servicioWeb.DevolverVictimaPorId(Convert.ToInt32(hdnIdVictima.Value));

                lblNombre.Text = Lenguaje.Nombre;
                lblApellido.Text = Lenguaje.Apellido;
                lblApodo.Text = Lenguaje.Apodo;

                lblClaveActual.Text = Lenguaje.ClaveActual;
                lblClaveNueva.Text = Lenguaje.ClaveNueva;
                lblClaveConfirmar.Text = Lenguaje.ConfirmarClave;

                txtNombre.Text = victima.Nombre;
                txtApellido.Text = victima.Apellido;
                txtApodo.Text = victima.Apodo;
                hdnClave.Value = victima.Clave;

                lnkAplicarCambiarClave.Text = "Aceptar";
                litMensajeClave.Text = "Aplicar cambios para aceptar el cambio de clave";
                lnkAplicarCambios.Text = Lenguaje.AplicarCambios;
            }
        }

        protected void lnkAplicarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                //CREA VICTIMA
                Victima victima = new Victima();
                victima.Id = Convert.ToInt32(hdnIdVictima.Value);
                victima.Nombre = txtNombre.Text;
                victima.Apellido = txtApellido.Text;
                victima.Apodo = txtApodo.Text;
                victima.Clave = hdnClave.Value;

                servicioWeb.ModificarVictima(victima);
                Response.Redirect(QueryStrings_Url(urlVictimasDetalle, "id=" + hdnIdVictima.Value));
            }
            catch (Exception ex)
            {
                litMensaje.Visible = true;
                litMensaje.Text = ex.Message;
            }
        }

        protected void lnkAplicarCambiarClave_Click(object sender, EventArgs e)
        {
            litMensajeClave.Visible = true;
            hdnClave.Value = txtClaveNueva.Text;
        }
    }
}