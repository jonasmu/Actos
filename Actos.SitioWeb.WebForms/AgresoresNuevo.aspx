<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AgresoresNuevo.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AgresoresNuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">

    <div class="text-center" style="color:indianred">
        <asp:Label ID="lblMensaje" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div id="mensajes" class="mensaje-error alert alert-danger" style="display: none">
        <ul id="ulMensajes"> </ul>
        <button class="btn btn-default" type="button" onclick="AceptarValidacionesIncompletas()">Aceptar</button> 
    </div>


        <div class="text-center">
        <asp:Image ID="imgAgresor" CssClass="imagenPerfil" runat="server" />
                    <h2 class="page-header">
            NUEVO AGRESOR
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


    <div class="form-inline text-center">
        <asp:LinkButton ID="lnkAceptar" CssClass="btn btn-personal" runat="server" OnClick="lnkAceptar_Click" OnClientClick="return Validar_AgresorNuevo()" />
    </div>

</asp:Content>
