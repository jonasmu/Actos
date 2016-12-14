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
    public partial class AgresoresModificar : PaginaBase
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((HtmlGenericControl)Master.FindControl("menuAgresores")).Attributes.Add("class", "activado");

                hdnIdAgresor.Value = Request.QueryString["Id"];
                var agresor = servicioWeb.DevolverAgresorPorId(Convert.ToInt32(hdnIdAgresor.Value), true, true, true);

                lblNombre.Text = Lenguaje.Nombre;
                lblApellido.Text = Lenguaje.Apellido;
                lblApodo.Text = Lenguaje.Apodo;
                lblOcupacion.Text = Lenguaje.Ocupacion;
                lblCaracteristicas.Text = Lenguaje.Caracteristicas;
                lblMetodos.Text = Lenguaje.Metodos;

                txtNombre.Text = agresor.Nombre;
                txtApellido.Text = agresor.Apellido;
                txtApodo.Text = agresor.Apodo;
                txtOcupacion.Text = agresor.Ocupacion;
                txtCaracteristicas.Text = agresor.Caracteristicas;
                txtMetodos.Text = agresor.Metodos;

                //Localidad para direccion y telefono (con consulta)
                var localidad = servicioWeb.DevolverLocalidad();

                lblLocalidadDireccion.Text = Lenguaje.Localidad;
                ddlLocalidadDireccion.DataSource = localidad;
                ddlLocalidadDireccion.DataValueField = "Id";
                ddlLocalidadDireccion.DataTextField = "Nombre";
                ddlLocalidadDireccion.DataBind();
                lblTipoDIreccion.Text = Lenguaje.TipoDireccion;
                ddlTipoDireccion.DataSource = servicioWeb.DevolverTiposDirecciones();
                ddlTipoDireccion.DataValueField = "Id";
                ddlTipoDireccion.DataTextField = "Nombre";
                ddlTipoDireccion.DataBind();
                lblCalle.Text = Lenguaje.Calle;
                lblNumeroDireccion.Text = Lenguaje.Numero;
                lblPiso.Text = Lenguaje.Piso;
                lblDepartamento.Text = Lenguaje.Departamento;
                grdDirecciones.DataSource = agresor.Direcciones;
                grdDirecciones.DataBind();

                lblTipoRedSocial.Text = Lenguaje.TipoRedSocial;
                ddlTipoRedSocial.DataSource = servicioWeb.DevolverTiposRedesSociales();
                ddlTipoRedSocial.DataValueField = "Id";
                ddlTipoRedSocial.DataTextField = "Nombre";
                ddlTipoRedSocial.DataBind();
                lblNombreRedSocial.Text = Lenguaje.Nombre;
                grdRedesSociales.DataSource = agresor.RedesSociales;
                grdRedesSociales.DataBind();

                lblLocalidadTelefono.Text = Lenguaje.Localidad;
                var consultaLocalidadTelefono = localidad.Select(l => new { Id_CodigoArea = Convert.ToString(l.Id) + "_" + l.CodigoArea, l.Nombre });
                ddlLocalidadTelefono.DataSource = consultaLocalidadTelefono;
                ddlLocalidadTelefono.DataValueField = "Id_CodigoArea";
                ddlLocalidadTelefono.DataTextField = "Nombre";
                ddlLocalidadTelefono.DataBind();
                lblTipoTelefono.Text = Lenguaje.TipoTelefono;
                ddlTipoTelefono.DataSource = servicioWeb.DevolverTiposTelefonos();
                ddlTipoTelefono.DataValueField = "Id";
                ddlTipoTelefono.DataTextField = "Nombre";
                ddlTipoTelefono.DataBind();
                lblNumeroTelefono.Text = Lenguaje.Numero;
                grdTelefonos.DataSource = agresor.Telefonos;
                grdTelefonos.DataBind();

                lnkAplicarCambios.Text = Lenguaje.AplicarCambios;
            }

        }


        protected void btnAceptarNuevaDireccion_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hdnIdAgresor.Value);
            Agresor agresor = servicioWeb.DevolverAgresorPorId(id, true, true, true);

            Direccion direccion = new Direccion();
            direccion.Localidad = new Localidad();
            direccion.Localidad = servicioWeb.DevolverLocalidadPorId
                                  (Convert.ToInt32(ddlLocalidadDireccion.SelectedValue));
            direccion.Tipo = new TipoDireccion();
            direccion.Tipo.Id = Convert.ToByte(ddlTipoDireccion.SelectedValue);
            direccion.Tipo.Nombre = ddlTipoDireccion.SelectedItem.Text;
            direccion.Calle = txtCalle.Text;
            direccion.Numero = txtNumeroDireccion.Text;
            if (ddlTipoDireccion.SelectedValue == "2")
            {
                direccion.Piso = txtPiso.Text;
                direccion.Departamento = txtDepartamento.Text;
            }
            else
            {
                direccion.Piso = string.Empty;
                direccion.Departamento = string.Empty;
            }

            //var pepe = agresor.Direcciones.ToList();
            //pepe.Add(direccion);
            //agresor.Direcciones = pepe.ToArray();
            var listaDirecciones = agresor.Direcciones.ToList();
            listaDirecciones.Add(direccion);
            agresor.Direcciones = listaDirecciones.ToArray();

            servicioWeb.ModificarAgresor(agresor);

            //System.Threading.Thread.Sleep(3000);
            grdDirecciones.DataSource = (servicioWeb.DevolverAgresorPorId(id, false, true, false)).Direcciones;
            grdDirecciones.DataBind();
        }

        protected void btnAceptarNuevaRedSocial_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hdnIdAgresor.Value);
            Agresor agresor = servicioWeb.DevolverAgresorPorId(id, true, true, true);

            RedSocial redSocial = new RedSocial();
            redSocial.Tipo = new TipoRedSocial();
            redSocial.Tipo.Id = Convert.ToByte(ddlTipoRedSocial.SelectedValue);
            redSocial.Tipo.Nombre = ddlTipoRedSocial.SelectedItem.Text;
            redSocial.Nombre = txtNombreRedSocial.Text;

            var listaRedesSociales = agresor.RedesSociales.ToList();
            listaRedesSociales.Add(redSocial);
            agresor.RedesSociales = listaRedesSociales.ToArray();

            servicioWeb.ModificarAgresor(agresor);

            grdRedesSociales.DataSource = (servicioWeb.DevolverAgresorPorId(id, false, false, true)).RedesSociales;
            grdRedesSociales.DataBind();
        }

        protected void btnAceptarNuevoTelefono_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(hdnIdAgresor.Value);
            //Agresor agresor = servicioWeb.DevolverAgresorPorId(id, true, true, true);

            //Telefono telefono = new Telefono();
            //telefono.Tipo = new TipoTelefono();
            //telefono.Tipo.Id = Convert.ToByte(ddlTipoTelefono.SelectedValue);
            //telefono.Tipo.Nombre = ddlTipoTelefono.SelectedItem.Text;
            //telefono.Localidad = new Localidad();
            //telefono.Localidad.Id = Convert.ToByte(ddlLocalidadTelefono.SelectedValue);
            //telefono.Localidad.Nombre = ddlLocalidadTelefono.SelectedItem.Text;
            //telefono.Numero = txtNumeroTelefono.Text;

            //var listaTelefonos = agresor.Telefonos.ToList();
            //listaTelefonos.Add(telefono);
            //agresor.Telefonos = listaTelefonos.ToArray();

            //servicioWeb.ModificarAgresor(agresor);

            //grdTelefonos.DataSource = (servicioWeb.DevolverAgresorPorId(id, true, false, false)).Telefonos;
            //grdTelefonos.DataBind();
            //updTelefonos_Panel.Update();
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


        protected void grdDirecciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                row.Attributes["id"] = "direcciones_" + e.Row.RowIndex.ToString();
            }
        }

        protected void grdRedesSociales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                row.Attributes["id"] = "redesSociales_" + e.Row.RowIndex.ToString();
            }
        }

        protected void grdTelefonos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                row.Attributes["id"] = "telefonos_" + e.Row.RowIndex.ToString();
            }
        }



        protected void grdDirecciones_Load(object sender, EventArgs e)
        {
            hdnUltimaFila_Direcciones.Value = Convert.ToString(grdDirecciones.Rows.Count - 1);
        }

        protected void grdRedesSociales_Load(object sender, EventArgs e)
        {
            hdnUltimaFila_RedesSociales.Value = Convert.ToString(grdRedesSociales.Rows.Count - 1);
        }

        protected void grdTelefonos_Load(object sender, EventArgs e)
        {
            hdnUltimaFila_Telefonos.Value = Convert.ToString(grdTelefonos.Rows.Count - 1);
        }


        protected void lnkAplicarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                //CREA AGRESOR
                var agresor = new Agresor();
                agresor.Id = Convert.ToInt32(hdnIdAgresor.Value);
                agresor.Nombre = txtNombre.Text;
                agresor.Apellido = txtApellido.Text;
                agresor.Apodo = txtApodo.Text;
                agresor.Ocupacion = txtOcupacion.Text;
                agresor.Caracteristicas = txtCaracteristicas.Text;
                agresor.Metodos = txtMetodos.Text;

                //CREA DIRECCIONES DE AGRESOR
                var direcciones = new List<Direccion>();
                var vectorDirecciones = hdnDirecciones.Value.Split(',');
                var contadorDirecciones = 0;
                for (int i = 0; i < vectorDirecciones.Length / 6; i++)
                {
                    var direccion = new Direccion();
                    direccion.Tipo = new TipoDireccion() { Id = Convert.ToByte(vectorDirecciones[contadorDirecciones]) };
                    contadorDirecciones++;
                    direccion.Localidad = new Localidad() { Id = Convert.ToInt32(vectorDirecciones[contadorDirecciones]) };
                    contadorDirecciones++;
                    direccion.Calle = vectorDirecciones[contadorDirecciones];
                    contadorDirecciones++;
                    direccion.Numero = vectorDirecciones[contadorDirecciones];
                    contadorDirecciones++;
                    direccion.Piso = vectorDirecciones[contadorDirecciones];
                    contadorDirecciones++;
                    direccion.Departamento = vectorDirecciones[contadorDirecciones];
                    contadorDirecciones++;
                    direcciones.Add(direccion);
                }
                agresor.Direcciones = direcciones.ToArray();

                //CREA REDES SOCIALES DE AGRESOR
                var redesSociales = new List<RedSocial>();
                var vectorRedesSociales = hdnRedesSociales.Value.Split(',');
                var contadorRedesSociales = 0;
                for (int i = 0; i < vectorRedesSociales.Length / 2; i++)
                {
                    var redSocial = new RedSocial();
                    redSocial.Tipo = new TipoRedSocial() { Id = Convert.ToByte(vectorRedesSociales[contadorRedesSociales]) };
                    contadorRedesSociales++;
                    redSocial.Nombre = vectorRedesSociales[contadorRedesSociales];
                    contadorRedesSociales++;
                    redesSociales.Add(redSocial);
                }
                agresor.RedesSociales = redesSociales.ToArray();

                //CREA TELEFONOS DE AGRESOR
                var telefonos = new List<Telefono>();
                var vectorTelefonos = hdnTelefonos.Value.Split(',');
                var contador = 0;
                for (int i = 0; i < vectorTelefonos.Length / 3; i++)
                {
                    var telefono = new Telefono();
                    telefono.Tipo = new TipoTelefono() { Id = Convert.ToByte(vectorTelefonos[contador]) };
                    contador++;
                    telefono.Localidad = new Localidad() { Id = Convert.ToInt32(vectorTelefonos[contador]) };
                    contador++;
                    telefono.Numero = vectorTelefonos[contador];
                    contador++;
                    telefonos.Add(telefono);
                }
                agresor.Telefonos = telefonos.ToArray();

                servicioWeb.ModificarAgresor(agresor);
                Response.Redirect(QueryStrings_Url(urlAgresoresDetalle,"id=" + hdnIdAgresor.Value));
            }
            catch (Exception ex)
            {
                litMensaje.Visible = true;
                litMensaje.Text = ex.Message;
            }
        }

        #endregion
    }
}