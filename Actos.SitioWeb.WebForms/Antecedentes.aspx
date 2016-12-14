<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Antecedentes.aspx.cs" Inherits="Actos.SitioWeb.WebForms.Antecedentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="form-horizontal small">
        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblBuscar" runat="server" Text="Buscar" />
            <div class="col-sm-8">
                <asp:TextBox CssClass="form-control" ID="txtBuscar" runat="server" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label CssClass="col-sm-2 control-label" ID="lblEstado" runat="server" Text="" />
            <div class="col-sm-8">
                <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server" />
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
                <asp:HyperLink CssClass="btn btn-personal form-control" ID="lnkNuevoAntecedente" runat="server" />
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
                <asp:GridView ID="grdAntecedentes" CssClass="table table-personal" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnPreRender="grdAntecedentes_PreRender">
                    <Columns>
                        <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Id" ControlStyle-CssClass="btn btn-default" DataNavigateUrlFormatString="~/AntecedentesDetalle.aspx?id={0}" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado"></asp:BoundField>
                        <asp:TemplateField HeaderText="Victima">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Victima.Nombre") %>' ID="Label1" />
                                <asp:Label runat="server" Text='<%# Bind("Victima.Apellido") %>' ID="Label2" />
                                <asp:Label runat="server" Text='<%# Bind("Victima.Apodo") %>' ID="Label3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agresor">
                            <ItemTemplate>
                                <asp:Literal runat="server" Text='<%# Bind("Agresor.Nombre") %>' ID="Label1" />
                                <asp:Literal runat="server" Text='<%# Bind("Agresor.Apellido") %>' ID="Label2" />
                                <asp:Literal runat="server" Text='<%# Bind("Agresor.Apodo") %>' ID="Label3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yy}" />
                        <asp:BoundField DataField="Ubicacion" HeaderText="Ubicaci&#243;n" />
                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                        <asp:BoundField DataField="Perjuicios" HeaderText="Perjuicios" />
                        <asp:TemplateField HeaderText="Puntajes">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Puntajes.Length") %>' ID="Label4"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
