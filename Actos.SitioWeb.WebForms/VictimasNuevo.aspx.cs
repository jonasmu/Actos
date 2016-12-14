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
    public partial class VictimasNuevo : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuVictimas")).Attributes.Add("class", "activado");

                imgVictima.ImageUrl = "http://4.bp.blogspot.com/-U3cOmqyo-6o/UWcuHjtN3hI/AAAAAAAABAk/CHL2_u6bgEo/s1600/timthumb+(1).jpg";

                lblNombre.Text = Lenguaje.Nombre;
                lblApellido.Text = Lenguaje.Apellido;
                lblApodo.Text = Lenguaje.Apodo;
                lblClave.Text = Lenguaje.Clave;

                lnkAceptar.Text = Lenguaje.Aceptar;
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var victima = new Victima();
                victima.Nombre = txtNombre.Text;
                victima.Apellido = txtApellido.Text;
                victima.Apodo = txtApodo.Text;
                victima.Clave = txtClave.Text;
                servicioWeb.CrearVictima(victima);
                Response.Redirect("Victimas.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
        }
    }
}