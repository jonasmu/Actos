<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AntecedentesNuevo.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AntecedentesNuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/antecedentes.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdnIdVictima" runat="server" />
    <asp:HiddenField ID="hdnIdAgresor" runat="server" />
    <asp:HiddenField ID="hdnIsGrdVictimasLoad" runat="server" />
    <asp:HiddenField ID="hdnIsGrdAgresoresLoad" runat="server" />




    <div class="text-center" style="color: indianred">
        <asp:Label ID="lblMensaje" runat="server" Visible="false" Text=""></asp:Label>
    </div>

    <div id="mensajes" class="mensaje-error alert alert-danger" style="display: none">
        <ul id="ulMensajes"></ul>
        <button class="btn btn-default" type="button" onclick="AceptarValidacionesIncompletas()">Aceptar</button>
    </div>


    <div id="panelDatos">
        <div class="text-center">
            <asp:Image ID="imgAntecedente" CssClass="imagenPerfil" runat="server" />
            <h2 class="page-header">NUEVO ANTECEDENTE
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
                <asp:Label CssClass="col-sm-3 control-label" for="btnElegirVictima" ID="lblElegirVictima" runat="server" Text="" />
                <div class="col-sm-4">
                    <asp:Button ID="btnElegirVictima" CssClass="btn btn-default form-control" runat="server" Text="" OnClick="btnElegirVictima_Click" OnClientClick="Panel_ElegirVictimas()" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="btnElegirAgresor" ID="lblElegirAgresor" runat="server" Text="" />
                <div class="col-sm-4">
                    <asp:Button ID="btnElegirAgresor" CssClass="btn btn-default form-control" runat="server" Text="" OnClick="btnElegirAgresor_Click" OnClientClick="Panel_ElegirAgresores()" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtFecha" ID="lblFecha" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" TextMode="Date" ID="txtFecha" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtObservaciones" ID="lblObservaciones" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtObservaciones" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtPerjuicios" ID="lblPerjuicios" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtPerjuicios" runat="server" />
                </div>
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label CssClass="col-sm-3 control-label" for="txtUbicacion" ID="lblUbicacion" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:TextBox class="form-control" ID="txtUbicacion" runat="server" />
                </div>
            </div>
        </div>


        <div class="form-inline text-center">
            <asp:LinkButton ID="btnAceptar" CssClass="btn btn-personal" runat="server" OnClick="btnAceptar_Click" OnClientClick="return Validar_AgresorNuevo()" />
        </div>
    </div>





    <!-- ELEGIR VICTIMA -->
    <div id="panelVictimas" class="hidden">
        <asp:UpdatePanel ID="updVictimas" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdVictimas" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <input type="button" class="btn btn-success" id="btnElegirVictima" value="Elegir" onclick="Panel_ElegirVictimas(this.parentNode.parentNode)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="VictimaId" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:TemplateField HeaderText="Victima">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("Nombre") %>' ID="Label1"></asp:Label>
                                    <asp:Label runat="server" Text='<%# Bind("Apellido") %>' ID="Label2"></asp:Label>
                                    <asp:Label runat="server" Text='<%# Bind("Apodo") %>' ID="Label3"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnElegirVictima" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>


    <!-- ELEGIR AGRESOR -->
    <div id="panelAgresores" class="hidden">
        <asp:UpdatePanel ID="updAgresores" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdAgresores" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <input type="button" class="btn btn-success" id="btnElegirAgresor" value="Elegir" onclick="Panel_ElegirAgresores(this.parentNode.parentNode)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="AgresorId" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                            <asp:TemplateField HeaderText="Agresor">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("Nombre") %>' ID="Label1"></asp:Label>
                                    <asp:Label runat="server" Text='<%# Bind("Apellido") %>' ID="Label2"></asp:Label>
                                    <asp:Label runat="server" Text='<%# Bind("Apodo") %>' ID="Label3"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnElegirAgresor" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
