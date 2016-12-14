<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AgresoresModificar.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AgresoresModificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/agresores.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">

    <!-- ATRIBUTOS -->
    <asp:HiddenField ID="hdnIdAgresor" runat="server" />
    <asp:HiddenField ID="hdnUltimaFila_Direcciones" runat="server" />
    <asp:HiddenField ID="hdnUltimaFila_RedesSociales" runat="server" />
    <asp:HiddenField ID="hdnUltimaFila_Telefonos" runat="server" />
    <asp:HiddenField ID="hdnDirecciones" runat="server" />
    <asp:HiddenField ID="hdnRedesSociales" runat="server" />
    <asp:HiddenField ID="hdnTelefonos" runat="server" />





    <!-- MENSAJES -->
    <div>
        <asp:Literal ID="litMensaje" runat="server" Visible="false" />
    </div>





    <!-- BOTONES -->
    <div class="form-inline text-center">
        <asp:LinkButton ID="lnkAplicarCambios" CssClass="btn btn btn-personal" runat="server" OnClick="lnkAplicarCambios_Click" OnClientClick="return Aplicar_CambiosModificar()" />
    </div>

    <div class="separador"></div>

    <div class="row modulosDetalle">
        <div class="col-sm-3">
            <input type="button" id="btnMetodos" value="Información" class="btn btn-warning form-control" onclick="Panel_Metodos(this)" />
        </div>
        <div class="col-sm-3">
            <input type="button" id="btnDirecciones" value="Direcciones" class="btn btn-default form-control" onclick="Panel_Direcciones(this)" />
        </div>
        <div class="col-sm-3">
            <input type="button" id="btnRedesSociales" value="Redes sociales" class="btn btn-default form-control" onclick="Panel_RedesSociales(this)" />
        </div>
        <div class="col-sm-3">
            <input type="button" id="btnTelefonos" value="Teléfonos" class="btn btn-default form-control" onclick="Panel_Telefonos(this)" />
        </div>
    </div>






    <!-- INFORMACION DEL AGRESOR (Reutiliza las funciones de "Metodos" en Javascript -->
    <div id="panelMetodos">
        <br />

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtNombre" ID="lblNombre" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtNombre" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtApellido" ID="lblApellido" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtApellido" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtApodo" ID="lblApodo" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtApodo" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtOcupacion" ID="lblOcupacion" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtOcupacion" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtCaracteristicas" ID="lblCaracteristicas" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtCaracteristicas" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtMetodos" ID="lblMetodos" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" TextMode="multiline" Rows="10" ID="txtMetodos" runat="server" />
                </div>
            </div>
        </div>
    </div>







    <!-- DIRECCIONES DEL AGRESOR -->
    <div id="panelDirecciones" style="display: none">
        <div style="margin: 10px 10px 10px 10px"></div>
        <div class="row">
            <div class="col-sm-4">
                <div class="modulosDetalle">
                    <input id="btnAgregarDireccion" class="btn btn-personal form-control" type="button" value="Agregar dirección" onclick="Panel_AgregarDireccion()" />

                    <div id="panelAgregarDireccion" class="small" style="display: none">


                        <div class="form-group" style="margin-top: 20px">
                            <asp:Label CssClass="control-label" ID="lblLocalidadDireccion" runat="server" Text="" />
                            <asp:DropDownList CssClass="form-control" ID="ddlLocalidadDireccion" runat="server" />
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblTipoDIreccion" runat="server" Text="" />
                            <asp:DropDownList CssClass="form-control" ID="ddlTipoDireccion" runat="server" onchange="Panel_EsDepartamento()" />
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblCalle" runat="server" Text="" />
                            <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" />
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblNumeroDireccion" runat="server" Text="" />
                            <asp:TextBox ID="txtNumeroDireccion" CssClass="form-control" runat="server" />
                        </div>

                        <div id="panelDepartamento" style="display: none">
                            <div class="form-group">
                                <asp:Label CssClass="control-label" ID="lblPiso" runat="server" Text="" />
                                <asp:TextBox ID="txtPiso" CssClass="form-control" runat="server" />
                            </div>

                            <div class="form-group">
                                <asp:Label CssClass="control-label" ID="lblDepartamento" runat="server" Text="" />
                                <asp:TextBox ID="txtDepartamento" CssClass="form-control" runat="server" />
                            </div>
                        </div>

                        <input type="button" class="btn btn-personal form-control" value="Aceptar" style="margin-top: 10px" onclick="Agregar_Direccion()" />
                        <br />
                    </div>
                </div>
            </div>

            <div class="col-sm-8">
                <br class="visible-xs" />
                <div class="small">
                    <div class="table-responsive">
                        <asp:GridView CssClass="table table-condensed table-personal" ID="grdDirecciones" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdDirecciones_PreRender" OnRowDataBound="grdDirecciones_RowDataBound" OnLoad="grdDirecciones_Load">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <input type="button" value="Eliminar" class="btn btn-danger" onclick='<%# string.Format("Eliminar_Direccion({0})", Container.DataItemIndex) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                                <asp:BoundField DataField="Tipo.Id" HeaderText="Tipo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:BoundField DataField="Localidad.Nombre" HeaderText="Localidad" />
                                <asp:BoundField DataField="Localidad.Id" HeaderText="Codigo de area (id)" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                <asp:BoundField DataField="Calle" HeaderText="Calle" />
                                <asp:BoundField DataField="Numero" HeaderText="Número" />
                                <asp:BoundField DataField="Piso" HeaderText="Piso" />
                                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>







    <!-- REDES SOCIALES DEL AGRESOR -->
    <div id="panelRedesSociales" style="display: none">
        <div style="margin: 10px 10px 10px 10px"></div>
        <div class="row">
            <div class="col-sm-4">
                <div class="modulosDetalle">
                    <input id="btnAgregarRedSocial" class="btn btn-personal form-control" type="button" value="Agregar red social" onclick="Panel_AgregarRedSocial()" />

                    <div id="panelAgregarRedSocial" class="small" style="display: none">
                        <div class="form-group" style="margin-top: 20px">
                            <asp:Label CssClass="control-label" ID="lblTipoRedSocial" runat="server" Text="" />
                            <asp:DropDownList CssClass="form-control" ID="ddlTipoRedSocial" runat="server" />
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblNombreRedSocial" runat="server" Text="" />
                            <asp:TextBox ID="txtNombreRedSocial" CssClass="form-control" runat="server" />
                        </div>

                        <input type="button" class="btn btn-personal form-control" value="Aceptar" style="margin-top: 10px" onclick="Agregar_RedSocial()" />
                        <br />
                    </div>
                </div>
            </div>

            <div class="col-sm-8">
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdRedesSociales" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdRedesSociales_PreRender" OnRowDataBound="grdRedesSociales_RowDataBound" OnLoad="grdRedesSociales_Load">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="button" value="Eliminar" class="btn btn-danger" onclick='<%# string.Format("Eliminar_RedSocial({0})", Container.DataItemIndex) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                            <asp:BoundField DataField="Tipo.Id" HeaderText="Tipo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>







    <!-- TELEFONOS DEL AGRESOR -->
    <div id="panelTelefonos" style="display: none">
        <div style="margin: 10px 10px 10px 10px"></div>
        <div class="row">
            <div class="col-sm-4">
                <div class="modulosDetalle">
                    <input id="btnAgregarTelefono" class="btn btn-personal form-control" type="button" value="Agregar teléfono" onclick="Panel_AgregarTelefono()" />

                    <div id="panelAgregarTelefono" class="small" style="display: none">

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblTipoTelefono" runat="server" Text="" />
                            <asp:DropDownList CssClass="form-control" ID="ddlTipoTelefono" runat="server" />
                        </div>

                        <div class="form-group" style="margin-top: 20px">
                            <asp:Label CssClass="control-label" ID="lblLocalidadTelefono" runat="server" Text="" />
                            <asp:DropDownList CssClass="form-control" ID="ddlLocalidadTelefono" runat="server" />
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label" ID="lblNumeroTelefono" runat="server" Text="" />
                            <asp:TextBox ID="txtNumeroTelefono" CssClass="form-control" runat="server" />
                        </div>

                        <input type="button" class="btn btn-personal form-control" value="Aceptar" style="margin-top: 10px" onclick="Agregar_Telefono()" />
                        <br />
                    </div>
                </div>
            </div>

            <div class="col-sm-8">
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdTelefonos" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdTelefonos_PreRender" OnRowDataBound="grdTelefonos_RowDataBound" OnLoad="grdTelefonos_Load">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="button" value="Eliminar" class="btn btn-danger" onclick='<%# string.Format("Eliminar_Telefono({0})", Container.DataItemIndex) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                            <asp:BoundField DataField="Tipo.Id" HeaderText="Tipo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:BoundField DataField="Localidad.CodigoArea" HeaderText="Codigo de &#225;rea" />
                            <asp:BoundField DataField="Localidad.Id" HeaderText="Codigo de area (id)" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:BoundField DataField="Numero" HeaderText="N&#250;mero"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
