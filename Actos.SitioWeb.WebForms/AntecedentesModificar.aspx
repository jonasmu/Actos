<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AntecedentesModificar.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AntecedentesModificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/antecedentes.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdnIdAntecedente" runat="server" />
    <asp:HiddenField ID="hdnIdVictima" runat="server" />
    <asp:HiddenField ID="hdnIdAgresor" runat="server" />
    <asp:HiddenField ID="hdnIsGrdVictimasLoad" runat="server" />
    <asp:HiddenField ID="hdnIsGrdAgresoresLoad" runat="server" />


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
        <div class="col-sm-4">
            <input type="button" id="btnInformacion" value="Información" class="btn btn-warning form-control" onclick="Panel_Informacion(this)" />
        </div>
        <div class="col-sm-4">
            <asp:Button ID="btnVictima" runat="server" CssClass="btn btn-default form-control" Text="Víctima" OnClick="btnVictima_Click" OnClientClick="Panel_Victima(this)" />
        </div>

        <div class="col-sm-4">
            <asp:Button ID="btnAgresor" runat="server" CssClass="btn btn-default form-control" Text="Agresor" OnClick="btnAgresor_Click" OnClientClick="Panel_Agresor(this)" />
        </div>
    </div>







    <!-- INFORMACION DEL ANTECEDENTE -->
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
                <asp:Label CssClass="col-sm-3 control-label" for="ddlEstado" ID="lblEstado" runat="server" Text="" />
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server"></asp:DropDownList>
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
    </div>







    <!-- VICTIMA -->
    <div id="panelVictima" style="display: none">

         <div class="separador"></div>

        <div class="modulosDetalle text-center">
            <asp:Label ID="litVictima" runat="server" Text=""></asp:Label>
        </div>

        <div class="separador"></div>

        <asp:UpdatePanel ID="updVictimas" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdVictimas" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <input type="button" class="btn btn-success" id="btnElegirVictima" value="Elegir" onclick="Elegir_Victima(this.parentNode.parentNode)" />
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
                <asp:AsyncPostBackTrigger ControlID="btnVictima" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>




    <!-- AGRESOR -->
    <div id="panelAgresor" style="display: none">

         <div class="separador"></div>

          <div class="modulosDetalle text-center">
            <asp:Label ID="litAgresor" runat="server" Text=""></asp:Label>
        </div>

        <div class="separador"></div>

        <asp:UpdatePanel ID="updAgresores" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView CssClass="table table-condensed table-personal" ID="grdAgresores" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <input type="button" class="btn btn-success" id="btnElegirAgresor" value="Elegir" onclick="Elegir_Agresor(this.parentNode.parentNode)" />
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
                <asp:AsyncPostBackTrigger ControlID="btnAgresor" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
