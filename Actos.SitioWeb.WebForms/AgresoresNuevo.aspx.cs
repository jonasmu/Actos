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
    public partial class AgresoresNuevo : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuAgresores")).Attributes.Add("class", "activado");

                imgAgresor.ImageUrl = "http://rec-end.gfrcdn.net/images/tn/0/332/3866/2257/900/447/2015/03/22/thinkstockphotos-180135142.jpg";


                lblNombre.Text = Lenguaje.Nombre;
                lblApellido.Text = Lenguaje.Apellido;
                lblApodo.Text = Lenguaje.Apodo;
                lblOcupacion.Text = Lenguaje.Ocupacion;
                lblCaracteristicas.Text = Lenguaje.Caracteristicas;
                lblMetodos.Text = Lenguaje.Metodos;

                lnkAceptar.Text = Lenguaje.Aceptar;
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var agresor = new Agresor();
                agresor.Nombre = txtNombre.Text;
                agresor.Apellido = txtApellido.Text;
                agresor.Apodo = txtApodo.Text;
                agresor.Ocupacion = txtOcupacion.Text;
                agresor.Caracteristicas = txtCaracteristicas.Text;
                agresor.Metodos = txtMetodos.Text;
                agresor.Foto = null;
                servicioWeb.CrearAgresor(agresor);
                Response.Redirect("Agresores.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
            
        }
    }
}