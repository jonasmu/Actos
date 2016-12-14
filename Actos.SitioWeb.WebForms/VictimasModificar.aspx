<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="VictimasModificar.aspx.cs" Inherits="Actos.SitioWeb.WebForms.VictimasModificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/victimas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:HiddenField ID="hdnIdVictima" runat="server" />
    <asp:HiddenField ID="hdnClave" runat="server" />


    <!-- MENSAJES -->
    <div class="text-center">
        <asp:Literal ID="litMensaje" runat="server" Visible="false" />
    </div>

    <div class="text-center">
        <asp:Literal ID="litMensajeClave" runat="server" Visible="false" />
    </div>






    <!-- BOTONES -->
    <div class="form-inline text-center">
        <asp:LinkButton ID="lnkAplicarCambios" CssClass="btn btn btn-personal" runat="server" OnClick="lnkAplicarCambios_Click" OnClientClick="return Aplicar_CambiosModificar()" />
    </div>

    <div class="separador"></div>

    <div class="row modulosDetalle">
        <div class="col-sm-6">
            <input type="button" id="btnInformacion" value="Información" class="btn btn-warning form-control" onclick="Panel_Informacion(this)" />
        </div>
        <div class="col-sm-6">
            <input type="button" id="btnClave" value="Clave" class="btn btn-default form-control" onclick="Panel_Clave(this)" />
        </div>
    </div>







    <!-- INFORMACION DE LA VICTIMA -->
    <div id="panelInformacion">
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
    </div>










    <!-- CLAVE DE VICTIMA -->
    <div id="panelClave" style="display: none">
        <br />

        <!-- CAMBIO DE CLAVE -->
        <div class="modulosDetalle">
            <div class="form-inline text-center">
                <input id="btnCambiarClave" type="button" class="btn btn-personal" value="Cambiar clave" onclick="Panel_CambiarClave()" />
            </div>


            <div id="panelCambiarClave" style="display: none">
                <div class="form-horizontal" style="margin-top: 20px">
                    <div class="form-group">
                        <asp:Label CssClass="col-sm-3 control-label" for="txtClaveActual" ID="lblClaveActual" runat="server" Text="" />
                        <div class="col-sm-6">
                            <asp:TextBox class="form-control" ID="txtClaveActual" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="form-horizontal" style="margin-top: 40px">
                    <div class="form-group">
                        <asp:Label CssClass="col-sm-3 control-label" for="txtClaveNueva" ID="lblClaveNueva" runat="server" Text="" />
                        <div class="col-sm-6">
                            <asp:TextBox class="form-control" ID="txtClaveNueva" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label CssClass="col-sm-3 control-label" for="txtClaveConfirmar" ID="lblClaveConfirmar" runat="server" Text="" />
                        <div class="col-sm-6">
                            <asp:TextBox class="form-control" ID="txtClaveConfirmar" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="form-inline text-center">
                    <asp:LinkButton ID="lnkAplicarCambiarClave" runat="server" CssClass="btn btn-personal" OnClick="lnkAplicarCambiarClave_Click" OnClientClick="return Aplicar_CambiarClave()" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
