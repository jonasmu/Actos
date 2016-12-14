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
    public partial class AgresoresDetalle : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(updDirecciones_Panel, updDirecciones_Panel.GetType(), "updDir", "AgregarDireccion()", true);
            //ScriptManager.RegisterStartupScript(updRedesSociales_Panel, updRedesSociales_Panel.GetType(), "updRed", "AgregarRedSocial()", true);
            //ScriptManager.RegisterStartupScript(updTelefonos_Panel, updTelefonos_Panel.GetType(), "updTel", "AgregarTelefono()", true);


            if (!IsPostBack)
            {
                try
                {
                    hdnIdAgresor.Value = Request.QueryString["Id"];
                    int id = Convert.ToInt32(hdnIdAgresor.Value);

                    lnkModificar.Text = Lenguaje.Modificar;
                    lnkModificar.NavigateUrl = QueryStrings_Url(urlAgresoresModificar, string.Format("id={0}", hdnIdAgresor.Value));
                    lnkEliminar.Text = Lenguaje.Eliminar;

                    lblNombre.Text = Lenguaje.Nombre;
                    lblApellido.Text = Lenguaje.Apellido;
                    lblApodo.Text = Lenguaje.Apodo;
                    lblOcupacion.Text = Lenguaje.Ocupacion;
                    lblCaracteristicas.Text = Lenguaje.Caracteristicas;

                    var agresor = servicioWeb.DevolverAgresorPorId(id, true, true, true);
                    imgFoto.ImageUrl = "https://static.iris.net.co/semana/upload/images/2015/6/11/430890_101646_1.jpg";
                    //imgFoto.ImageUrl = agresor.Foto;
                    litNombre.Text = agresor.Nombre;
                    litApellido.Text = agresor.Apellido;
                    litApodo.Text = agresor.Apodo;
                    litOcupacion.Text = agresor.Ocupacion;
                    litCaracteristicas.Text = agresor.Caracteristicas;
                    litMetodos.Text = agresor.Metodos;

                    if (litNombre.Text == string.Empty)
                    {
                        lblNombre.Visible = false;
                    }
                    if (litApellido.Text == string.Empty)
                    {
                        lblApellido.Visible = false;
                    }
                    if (litApodo.Text == string.Empty)
                    {
                        lblApodo.Visible = false;
                    }


                    grdDirecciones.DataSource = agresor.Direcciones;
                    grdDirecciones.DataBind();

                    grdRedesSociales.DataSource = agresor.RedesSociales;
                    grdRedesSociales.DataBind();

                    grdTelefonos.DataSource = agresor.Telefonos;
                    grdTelefonos.DataBind();
                }
                catch (Exception ex)
                {
                    litMensaje.Visible = true;
                    litMensaje.Text = ex.Message;
                }

            }
        }

        protected void grdDirecciones_PreRender(object sender, EventArgs e)
        {
            grdDirecciones.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grdRedesSociales_PreRender(object sender, EventArgs e)
        {
            grdRedesSociales.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grdTelefonos_PreRender(object sender, EventArgs e)
        {
            grdTelefonos.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var agresor = servicioWeb.DevolverAgresorPorId(Convert.ToInt32(hdnIdAgresor.Value), false, false, false);
                servicioWeb.EliminarAgresor(agresor);
                Response.Redirect(urlAgresores);
            }
            catch (Exception ex)
            {
                litMensaje.Text = ex.Message;
                litMensaje.Visible = true;
            }
        }
    }
}