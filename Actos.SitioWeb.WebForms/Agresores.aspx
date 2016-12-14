<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Agresores.aspx.cs" Inherits="Actos.SitioWeb.WebForms.Agresores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="form-horizontal small">
        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblBuscar" runat="server" Text="Buscar" />
            <div class="col-sm-8">
                <asp:TextBox CssClass="form-control" ID="txtBuscar" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblFiltros" runat="server" Text="" />
            <div class="col-sm-8">
                <asp:DropDownList CssClass="form-control" ID="ddlFiltro" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblPuntajes" runat="server" Text="" />
            <div class="col-sm-8">
                <asp:DropDownList CssClass="form-control" ID="ddlPuntajes" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-3 col-sm-offset-2">
                <asp:LinkButton CssClass="btn btn-personal form-control" ID="lnkBuscar" runat="server" OnClick="lnkBuscar_Click">
                <span class="glyphicon glyphicon-search"></span>
                </asp:LinkButton>
            </div>
            <br class="visible-xs" />
            <div class="col-sm-3 col-sm-offset-2">
                <asp:HyperLink CssClass="btn btn-personal form-control" ID="lnkNuevoAgresor" runat="server" />
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1000">
        <ProgressTemplate>
            CARGANDO
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="table-responsive">
                <asp:GridView ID="grdAgresores" CssClass="table table-personal" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnPreRender="grdAgresores_PreRender">
                    <Columns>
                        <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/AgresoresDetalle.aspx?id={0}">
                            <ControlStyle CssClass="btn btn-default" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Apodo" HeaderText="Apodo" />
                        <asp:BoundField DataField="Ocupacion" HeaderText="Ocupación" />
                        <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


</asp:Content>
