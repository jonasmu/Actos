<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="VictimasNuevo.aspx.cs" Inherits="Actos.SitioWeb.WebForms.VictimasNuevo" %>

<asp:Content ContentPlaceHolderID="conEncabezado" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="conCuerpo" runat="server">

    <div class="text-center" style="color: indianred">
        <asp:Label ID="lblMensaje" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div id="mensajes" class="mensaje-error alert alert-danger" style="display: none">
        <ul id="ulMensajes"></ul>
        <button class="btn btn-default" type="button" onclick="AceptarValidacionesIncompletas()">Aceptar</button>
    </div>



    <div class="text-center">
        <asp:Image ID="imgVictima" CssClass="imagenPerfil" runat="server" />
        <h2 class="page-header">NUEVA VICTIMA
        </h2>
    </div>




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
            <asp:Label CssClass="col-sm-3 control-label" for="txtClave" ID="lblClave" runat="server" Text="" />
            <div class="col-sm-6">
                <asp:TextBox class="form-control" ID="txtClave" runat="server" />
            </div>
        </div>
    </div>

    <div class="form-inline text-center">
        <asp:LinkButton ID="lnkAceptar" CssClass="btn btn-personal" runat="server" OnClick="lnkAceptar_Click" OnClientClick="return Validar_VictimaNuevo()" />
    </div>

</asp:Content>
