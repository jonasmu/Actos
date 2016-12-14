<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="AntecedentesDetalle.aspx.cs" Inherits="Actos.SitioWeb.WebForms.AntecedentesDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="conEncabezado" runat="server">
    <script type="text/javascript" src="Scripts/antecedentes.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conCuerpo" runat="server">
    <asp:HiddenField ID="hdnIdAntecedente" runat="server" />


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
                            <asp:LinkButton ID="lnkEliminar" runat="server" CssClass="btn btn-danger form-control" OnClick="lnkEliminar_Click" OnClientClick="return Eliminar_Antecedente()" />
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
                    <asp:Label CssClass="small" ID="lblFecha" runat="server" Text="" />
                    <asp:Literal ID="litFecha" runat="server" />
                </div>

                <div class="form-inline form-control-static">
                    <asp:Label CssClass="small" ID="lblEstado" runat="server" Text="" />
                    <asp:Literal ID="litEstado" runat="server" />
                </div>

                <div class="separador"></div>
            </div>
        </div>

        <br class="visible-xs" />

        <div class="col-md-8">
            <br class="visible-sm visible-xs" />
            <div class="modulosDetalle">

                <div class="row hidden-xs">
                    <div class="col-sm-4">
                        <button id="btnUbicacion" type="button" class="btn btn-warning form-control" onclick="Panel_Ubicacion(this)">Ubicación</button>
                    </div>
                    <div class="col-sm-4">
                        <button id="btnObservaciones" type="button" class="btn btn-default form-control" onclick="Panel_Observaciones(this)">Observaciones</button>
                    </div>
                    <div class="col-sm-4">
                        <button id="btnPerjuicios" type="button" class="btn btn-default form-control" onclick="Panel_Perjuicios(this)">Perjuicios</button>
                    </div>
                </div>

                <div class="visible-xs">
                    <button id="btnUbicacion-sm" type="button" class="btn btn-default form-control" onclick="Panel_Ubicacion()">Ubicación</button>
                </div>

                <div id="panelUbicacion">
                    <div class="separador"></div>
                    <p class="pager">
                        <asp:Literal ID="litUbicacion" runat="server" />
                    </p>
                </div>

                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnObservaciones-sm" type="button" class="btn btn-default form-control" onclick="Panel_Observaciones()">Observaciones</button>
                </div>

                <div id="panelObservaciones" style="display: none">
                    <div class="separador"></div>
                    <asp:Literal ID="litObservaciones" runat="server" />
                </div>



                <div class="visible-xs">
                    <div class="separador"></div>
                    <button id="btnPerjuicios-sm" type="button" class="btn btn-default form-control" onclick="Panel_Perjuicios()">Perjuicios</button>
                </div>

                <div id="panelPerjuicios" style="display: none">
                    <div class="separador"></div>
                    <asp:Literal ID="litPerjuicios" runat="server" />
                </div>
            </div>

            <div class="separador"></div>

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblVictima" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litVictima" runat="server" />
                </p>
            </div>

            <div class="separador"></div>

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblAgresor" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litAgresor" runat="server" />
                </p>
            </div>
        </div>
    </div>






































    <%--<div class="text-center bg-danger">
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
                            <asp:LinkButton ID="lnkEliminar" runat="server" CssClass="btn btn-danger form-control" OnClick="lnkEliminar_Click" OnClientClick="return Eliminar_Antecedente()" />
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
                    <asp:Label CssClass="small" ID="lblVictima" runat="server" Text="" />
                    <asp:Literal ID="litVictima" runat="server" />
                </div>

                <div class="form-inline form-control-static">
                    <asp:Label CssClass="small" ID="lblAgresor" runat="server" Text="" />
                    <asp:Literal ID="litAgresor" runat="server" />
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
    </div>--%>





























    <%--   <div class="row">
        <div class="col-sm-4">
            <div class="modulosDetalle">
                <div class="modulosDetalle">
                    <asp:Label CssClass="small" ID="lblNombre" runat="server" Text="" />
                    <asp:Literal ID="litNombre" runat="server" />
                </div>

                <br />

                <div class="modulosDetalle">
                    <asp:Label CssClass="small" ID="lblVictima" runat="server" Text="" />
                    <asp:Literal ID="litVictima" runat="server" />
                </div>

                <br />

                <div class="modulosDetalle">
                    <asp:Label CssClass="small" ID="lblAgresor" runat="server" Text="" />
                    <asp:Literal ID="litAgresor" runat="server" />
                </div>

                <br />

                <div class="modulosDetalle">
                    <asp:Label CssClass="small" ID="lblFecha" runat="server" Text="" />
                    <asp:Literal ID="litFecha" runat="server" />
                </div>
            </div>
        </div>

        <div class="col-sm-8">
            <br class="visible-sm visible-xs" />
            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblObservaciones" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litObservaciones" runat="server" />
                </p>
            </div>

            <br />

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblPerjuicios" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litPerjuicios" runat="server" />
                </p>
            </div>

            <br />

            <div class="modulosDetalle">
                <h2>
                    <asp:Label ID="lblUbicacion" runat="server" Text="" />
                </h2>
                <p class="small">
                    <asp:Literal ID="litUbicacion" runat="server" />
                </p>
                <div>
                    <asp:ImageMap ID="imgMapa" runat="server">
                    </asp:ImageMap>
                </div>
            </div>
        </div>

    </div>--%>
</asp:Content>
