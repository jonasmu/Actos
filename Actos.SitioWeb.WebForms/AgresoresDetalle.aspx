<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AgresoresDetalle.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AgresoresDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/agresores.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdnIdAgresor" runat="server" />

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
                            <asp:LinkButton ID="lnkEliminar" runat="server" CssClass="btn btn-danger form-control" OnClick="lnkEliminar_Click" OnClientClick="return Eliminar_Agresor()" />
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
                        <button id="btnMetodos" type="button" class="btn btn-warning form-control" onclick="Panel_Metodos(this)">Métodos</button>
                    </div>
                    <div class="col-sm-3">
                        <button id="btnDirecciones" type="button" class="btn btn-default form-control" onclick="Panel_Direcciones(this)">Direcciones</button>
                    </div>
                    <div class="col-sm-3">
                        <button id="btnRedesSociales" type="button" class="btn btn-default form-control" onclick="Panel_RedesSociales(this)">Redes sociales</button>
                    </div>
                    <div class="col-sm-3">
                        <button id="btnTelefonos" type="button" class="btn btn-default form-control" onclick="Panel_Telefonos(this)">Telefonos</button>
                    </div>
                </div>

                <div class="visible-xs">
                    <button id="btnMetodos-sm" type="button" class="btn btn-default form-control" onclick="Panel_Metodos()">Métodos</button>
                </div>

                <div id="panelMetodos">
                    <div class="separador"></div>
                    <p class="pager">
                        <asp:Literal ID="litMetodos" runat="server" />
                    </p>
                </div>

                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnDirecciones-sm" type="button" class="btn btn-default form-control" onclick="Panel_Direcciones()">Direcciones</button>
                </div>

                <div id="panelDirecciones" style="display: none">
                    <div class="separador"></div>

                    <div class="small">
                        <div class="table-responsive">
                            <asp:GridView CssClass="table table-condensed table-personal" ID="grdDirecciones" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdDirecciones_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="Localidad.Nombre" HeaderText="Localidad" />
                                    <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Calle" HeaderText="Calle" />
                                    <asp:BoundField DataField="Numero" HeaderText="Número" />
                                    <asp:BoundField DataField="Piso" HeaderText="Piso" />
                                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>



                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnRedesSociales-sm" type="button" class="btn btn-default form-control" onclick="Panel_RedesSociales()">Redes sociales</button>
                </div>

                <div id="panelRedesSociales" style="display: none">
                    <div class="separador"></div>

                    <div class="table-responsive">
                        <asp:GridView CssClass="table table-condensed table-personal" ID="grdRedesSociales" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdRedesSociales_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnTelefonos-sm" type="button" class="btn btn-default form-control" onclick="Panel_Telefonos()">Telefonos</button>
                </div>

                <div id="panelTelefonos" style="display: none">
                    <div class="separador"></div>

                    <div class="table-responsive">
                        <asp:GridView CssClass="table table-condensed table-personal" ID="grdTelefonos" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnPreRender="grdTelefonos_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                                <asp:BoundField DataField="Localidad.CodigoArea" HeaderText="Codigo de área" />
                                <asp:BoundField DataField="Numero" HeaderText="Número" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div class="separador"></div>

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblOcupacion" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litOcupacion" runat="server" />
                </p>
            </div>

            <div class="separador"></div>

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblCaracteristicas" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litCaracteristicas" runat="server" />
                </p>
            </div>

        </div>
    </div>

</asp:Content>
