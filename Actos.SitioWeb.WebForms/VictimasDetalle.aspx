<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="VictimasDetalle.aspx.cs" Inherits="Actos.SitioWeb.WebForms.VictimasDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/victimas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:HiddenField ID="hdnIdVictima" runat="server" />
    <asp:HiddenField ID="hdnClave" runat="server" />


    <div class="text-center bg-danger">
        <asp:Literal ID="litMensaje" runat="server" Visible="false" />
    </div>


    <div>
        <asp:Literal ID="litPuntaje" runat="server" />
    </div>


    <div class="row">
        <div class="col-md-4">
            <div id="panelEditar" style="display: none">
                <div class="modulosDetalle">
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:HyperLink CssClass="btn btn-success form-control" ID="lnkModificar" runat="server" />
                        </div>

                        <div class="col-sm-6">
                            <asp:LinkButton ID="lnkEliminar" runat="server" CssClass="btn btn-danger form-control" OnClick="lnkEliminar_Click" OnClientClick="return Eliminar_Victima()" />
                        </div>
                    </div>
                </div>

                <div>
                    <div class="separador"></div>
                </div>
            </div>


            <div class="text-center modulosDetalle">
                <input type="button" id="btnEditar" class="btn btn-default btn-block" value="^" onclick="Panel_Editar(this)" />

                <div class="text-center">
                    <asp:Image CssClass="text-center imagenPerfil" ID="imgFoto" runat="server" />
                </div>

                <div class="form-inline form-control-static">
                    <asp:Label CssClass="small" ID="lblNombre" runat="server" Text="" />
                    <asp:Literal ID="litNombre" runat="server" />
                </div>

                <div class="form-inline form-control-static">
                    <asp:Label CssClass="small" ID="lblApellido" runat="server" Text="" />
                    <asp:Literal ID="litApellido" runat="server" />
                </div>

                <div class="form-inline form-control-static">
                    <asp:Label CssClass="small" ID="lblApodo" runat="server" Text="" />
                    <asp:Literal ID="litApodo" runat="server" />
                </div>

                <div class="separador"></div>
            </div>
        </div>

        <br class="visible-xs" />

        <div class="col-md-8">
            <br class="visible-sm visible-xs" />
            <div class="modulosDetalle">

                <div class="row hidden-xs">
                    <div class="col-sm-3">
                        <button id="btnAntecedentes" type="button" class="btn btn-warning form-control" onclick="Panel_Antecedentes(this)">Antecedentes</button>
                    </div>
                </div>



                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnAntecedentes-sm" type="button" class="btn btn-default form-control" onclick="Panel_Antecedentes()">Antecedentes</button>
                </div>

                <div id="panelAntecedentes">
                    <div class="separador"></div>

                    <div class="table-responsive">
                        <asp:GridView CssClass="table table-condensed table-personal" ID="grdAntecedentes" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdAntecedentes_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Agresor">
                                    <ItemTemplate>
                                        <asp:Literal runat="server" Text='<%# Bind("Agresor.Nombre") %>' ID="Label1" />
                                        <asp:Literal runat="server" Text='<%# Bind("Agresor.Apellido") %>' ID="Label2" />
                                        <asp:Literal runat="server" Text='<%# Bind("Agresor.Apodo") %>' ID="Label3" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yy}" />
                                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" />
                                <asp:BoundField DataField="Perjuicios" HeaderText="Perjuicios" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

            </div>

            <div class="separador"></div>

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblClave" runat="server" Text="" />
                </h2>
                <p class="small">
                    <span id="spanClave">**********</span>
                </p>
                <div>
                    <input id="btnVerClave" value="Ver clave" class="btn btn-success" type="button" onmousedown="Mostrar_Clave()" onmouseup="Ocultar_Clave()" onmouseout="Ocultar_Clave()" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
