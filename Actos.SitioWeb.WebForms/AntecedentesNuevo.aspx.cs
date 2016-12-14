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
    public partial class AntecedentesNuevo : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PANEL 1
                imgAntecedente.ImageUrl = "http://boletines.actualidadpenal.com.pe/imagenes/2014_10_31-15_10_26.jpg";

                lblNombre.Text = Lenguaje.Nombre;
                lblElegirAgresor.Text = Lenguaje.Agresor;
                btnElegirAgresor.Text = "Elegir";
                lblElegirVictima.Text = Lenguaje.Victima;
                btnElegirVictima.Text = "Elegir";

                hdnIsGrdAgresoresLoad.Value = "false";
                hdnIsGrdVictimasLoad.Value = "false";
                
                //PANEL 2
                lblFecha.Text = Lenguaje.Fecha;
                lblObservaciones.Text = Lenguaje.Observaciones;
                lblPerjuicios.Text = Lenguaje.Perjuicios;

                //PANEL 3
                lblUbicacion.Text = Lenguaje.Ubicacion;
                lblNombre.Text = Lenguaje.Nombre;

                btnElegirVictima.Text = Lenguaje.ElegirVictima;
                btnElegirAgresor.Text = Lenguaje.ElegirAgresor;

                btnAceptar.Text = Lenguaje.Aceptar;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var antecedente = new Antecedente();
                antecedente.Estado = new Estado { Id = 1 };
                antecedente.Nombre = txtNombre.Text;
                antecedente.Victima = servicioWeb.DevolverVictimaPorId(Convert.ToInt32(hdnIdVictima.Value));
                antecedente.Agresor = servicioWeb.DevolverAgresorPorId(Convert.ToInt32(hdnIdAgresor.Value), false, false, false);
                antecedente.Fecha = Convert.ToDateTime(txtFecha.Text);
                antecedente.Observaciones = txtObservaciones.Text;
                antecedente.Perjuicios = txtPerjuicios.Text;
                antecedente.Ubicacion = txtUbicacion.Text;
                antecedente.Latitud = 0;
                antecedente.Longitud = 0;
                servicioWeb.CrearAntecedente(antecedente);
                Response.Redirect("Antecedentes.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnElegirVictima_Click(object sender, EventArgs e)
        {
            if (hdnIsGrdVictimasLoad.Value == "false")
            {
                grdVictimas.DataSource = servicioWeb.DevolverVictimas();
                grdVictimas.DataBind();
                updVictimas.Update();
                hdnIsGrdVictimasLoad.Value = "true";
            }
        }

        protected void btnElegirAgresor_Click(object sender, EventArgs e)
        {
            if (hdnIsGrdAgresoresLoad.Value == "false")
            {
                grdAgresores.DataSource = servicioWeb.DevolverAgresores(false, false, false);
                grdAgresores.DataBind();
                updAgresores.Update();
                hdnIsGrdAgresoresLoad.Value = "true";
            }
        }
    }
}