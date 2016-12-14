using Actos.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Actos.SitioWeb.WebForms
{
    public partial class VictimasDetalle : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnIdVictima.Value = Request.QueryString["Id"];
                    int id = Convert.ToInt32(hdnIdVictima.Value);

                    lnkModificar.Text = Lenguaje.Modificar;
                    lnkModificar.NavigateUrl = QueryStrings_Url(urlVictimasModificar, string.Format("id={0}", hdnIdVictima.Value));
                    lnkEliminar.Text = Lenguaje.Eliminar;

                    imgFoto.ImageUrl = "http://www.canaldiabetes.com/wp-content/uploads/2015/02/image-e1424967473629-537x350.png";
                    lblNombre.Text = Lenguaje.Nombre;
                    lblApellido.Text = Lenguaje.Apellido;
                    lblApodo.Text = Lenguaje.Apodo;
                    lblClave.Text = Lenguaje.Clave;

                    var victima = servicioWeb.DevolverVictimaPorId(id);
                    litNombre.Text = victima.Nombre;
                    litApellido.Text = victima.Apellido;
                    litApodo.Text = victima.Apodo;

                    hdnClave.Value = victima.Clave;

                    grdAntecedentes.DataSource = servicioWeb.DevolverAntecedentes(true).Where(x => x.Victima.Id == id);
                    grdAntecedentes.DataBind();
                }
                catch (Exception ex)
                {
                    litMensaje.Visible = true;
                    litMensaje.Text = ex.Message;
                }

            }
        }

        protected void grdAntecedentes_PreRender(object sender, EventArgs e)
        {
            grdAntecedentes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var victima = servicioWeb.DevolverVictimaPorId(Convert.ToInt32(hdnIdVictima.Value));
                servicioWeb.EliminarVictima(victima);
                Response.Redirect(urlVictimas);
            }
            catch (Exception ex)
            {
                litMensaje.Text = ex.Message;
                litMensaje.Visible = true;
            }
        }
    }
}