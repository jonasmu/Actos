using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class AntecedentesDetalle : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnIdAntecedente.Value = Request.QueryString["id"];
                int id = Convert.ToInt32(hdnIdAntecedente.Value);
                var antecedente = servicioWeb.DevolverAntecedentePorId(id, true);

                imgFoto.ImageUrl = "http://www.andrewhays.net/img/posts/too-long-didnt-read/stack-of-paper.jpg";

                lblNombre.Text = Lenguaje.Nombre;
                lblVictima.Text = Lenguaje.Victima;
                lblAgresor.Text = Lenguaje.Agresor;
                lblFecha.Text = Lenguaje.Fecha;
                //lblObservaciones.Text = Lenguaje.Observaciones;
                //lblPerjuicios.Text = Lenguaje.Perjuicios;
                //lblUbicacion.Text = Lenguaje.Ubicacion;

                litNombre.Text = antecedente.Nombre;
                litVictima.Text = 
                    string.Format("{0} {1} {2}", 
                    antecedente.Victima.Nombre, 
                    antecedente.Victima.Apellido, 
                    antecedente.Victima.Apodo).Trim();
                litAgresor.Text =
                    string.Format("{0} {1} {2}",
                    antecedente.Agresor.Nombre,
                    antecedente.Agresor.Apellido,
                    antecedente.Agresor.Apodo).Trim();
                litFecha.Text = antecedente.Fecha.ToString("dd/MM/yyyy");
                litObservaciones.Text = antecedente.Observaciones;
                litPerjuicios.Text = antecedente.Perjuicios;
                litUbicacion.Text = antecedente.Ubicacion;

                lnkEliminar.Text = Lenguaje.Eliminar;
                lnkModificar.Text = Lenguaje.Modificar;
                lnkModificar.NavigateUrl = QueryStrings_Url(urlAntecedentesModificar, "id=" + hdnIdAntecedente.Value);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var antecedente = servicioWeb.DevolverAntecedentePorId(Convert.ToInt32(hdnIdAntecedente.Value), false);
                servicioWeb.EliminarAntecedente(antecedente);
                Response.Redirect(urlAntecedentes);
            }
            catch (Exception ex)
            {
                litMensaje.Text = ex.Message;
                litMensaje.Visible = true;
            }
        }
    }
}