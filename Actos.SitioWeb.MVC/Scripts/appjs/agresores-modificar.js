$(document).ready(function () {

    //ANTES DE ABRIR EL TELON
    $("#divRedesSociales").hide();
    $("#divTelefonos").hide();


    function ResetearPantalla() {
        $("#divDirecciones").hide();
        $("#divRedesSociales").hide();
        $("#divTelefonos").hide();

        $("#btnDirecciones").attr("class", "btn btn-default form-control btn-xs");
        $("#btnRedesSociales").attr("class", "btn btn-default form-control btn-xs");
        $("#btnTelefonos").attr("class", "btn btn-default form-control btn-xs");
    }




    //SE ABRE EL TELON
    $("#bg").fadeOut("fast", function () {


        //DIRECCIONES
        $("#btnDirecciones").click(function () {
            if ($("#hdnDirRedTel").val() != "Direcciones") {

                ResetearPantalla();
                $("#hdnDirRedTel").val("Direcciones");
                $("#btnDirecciones").attr("class", "btn btn-warning form-control btn-xs");
                $("#divDirecciones").show();
            }
        });

        $(document).on("click", ".btnQuitarDireccion", function () {
            var fila = $(this).parents("tr");

            fila.fadeOut("fast", function () {
                fila.addClass("hidden");
            });
        });

        $("#btnAgregarDireccion").click(function () {

            var modal = $("#modalAgregarDireccion");

            $(modal).removeClass("hidden");

            $(modal).dialog({
                autoOpen: false,
                modal: true,
                width: 600,
                height: 'auto',
                title: "Agregar dirección",
                hide: "fade",
                show: "fade"
            });

            $(modal).dialog("open");
        });

        $("#btnAceptarDireccion").click(function () {

            $("#modalAgregarDireccion").dialog("close");

            //ELEMENTOS CON VALORES INGRESADOS A VARIABLES
            var tipoVal = $("#ddlTipoDireccion").find("option:selected").val();
            var tipoText = $("#ddlTipoDireccion").find("option:selected").text();
            var localidadVal = $("#ddlLocalidadDireccion").find("option:selected").val();
            var localidadText = $("#ddlLocalidadDireccion").find("option:selected").text();
            var calle = $("#txtCalle").val();
            var numero = $("#txtNumeroDireccion").val();
            var piso = $("#txtPiso").val();
            var departamento = $("#txtDepartamento").val();

            //CREACION DE BOTON DE ELIMINAR DE FILA
            var boton = document.createElement('input');
            boton.setAttribute('type', 'button');
            boton.setAttribute('value', 'X');
            boton.setAttribute('class', 'btnQuitarDireccion btn btn-danger');

            //INSERCION DE FILA EN TABLA
            $("#tablaDirecciones").append(
                "<tr>" +
                "<td class=\"hidden\">" + tipoVal + "</td>" +
                "<td>" + tipoText + "</td>" +
                "<td class=\"hidden\">" + localidadVal + "</td>" +
                "<td>" + localidadText + "</td>" +
                "<td>" + calle + "</td>" +
                "<td>" + numero + "</td>" +
                "<td>" + piso + "</td>" +
                "<td>" + departamento + "</td>" +
                "<td><input type=\"button\" class=\"btnQuitarDireccion btn btn-danger\" value=\"X\" /></td>" +
                "</tr>"
                );
        });






        //REDES SOCIALES
        $("#btnRedesSociales").click(function () {
            if ($("#hdnDirRedTel").val() != "RedesSociales") {

                ResetearPantalla();
                $("#hdnDirRedTel").val("RedesSociales");
                $("#btnRedesSociales").attr("class", "btn btn-warning form-control btn-xs");
                $("#divRedesSociales").show();
            }
        });

        $(document).on("click", ".btnQuitarRedSocial", function () {
            var fila = $(this).parents("tr");

            fila.fadeOut("fast", function () {
                fila.addClass("hidden");
            });
        });

        $("#btnAgregarRedSocial").click(function () {

            var modal = $("#modalAgregarRedSocial");

            $(modal).removeClass("hidden");

            $(modal).dialog({
                autoOpen: false,
                modal: true,
                width: 600,
                height: 'auto',
                title: "Agregar red social",
                hide: "fade",
                show: "fade"
            });

            $(modal).dialog("open");
        });

        $("#btnAceptarRedSocial").click(function () {

            $("#modalAgregarRedSocial").dialog("close");

            //ELEMENTOS CON VALORES INGRESADOS A VARIABLES
            var tipoVal = $("#ddlTipoRedSocial").find("option:selected").val();
            var tipoText = $("#ddlTipoRedSocial").find("option:selected").text();
            var redSocial = $("#txtRedSocial").val();

            //CREACION DE BOTON DE ELIMINAR DE FILA
            var boton = document.createElement('input');
            boton.setAttribute('type', 'button');
            boton.setAttribute('value', 'X');
            boton.setAttribute('class', 'btnQuitarRedSocial btn btn-danger');

            //INSERCION DE FILA EN TABLA
            $("#tablaRedesSociales").append(
                "<tr>" +
                "<td class=\"hidden\">" + tipoVal + "</td>" +
                "<td>" + tipoText + "</td>" +
                "<td>" + redSocial + "</td>" +
                "<td><input type=\"button\" class=\"btnQuitarRedSocial btn btn-danger\" value=\"X\" /></td>" +
                "</tr>"
                );
        });






        //TELEFONOS
        $("#btnTelefonos").click(function () {
            if ($("#hdnDirRedTel").val() != "Telefonos") {

                ResetearPantalla();
                $("#hdnDirRedTel").val("Telefonos");
                $("#btnTelefonos").attr("class", "btn btn-warning form-control btn-xs");
                $("#divTelefonos").show();
            }
        });

        $(document).on("click", ".btnQuitarTelefono", function () {
            var fila = $(this).parents("tr");

            fila.fadeOut("fast", function () {
                fila.addClass("hidden");
            });
        });

        $("#btnAgregarTelefono").click(function () {

            var modal = $("#modalAgregarTelefono");

            $(modal).removeClass("hidden");

            $(modal).dialog({
                autoOpen: false,
                modal: true,
                width: 600,
                height: 'auto',
                title: "Agregar teléfono",
                hide: "fade",
                show: "fade"
            });

            $(modal).dialog("open");
        });

        $("#btnAceptarTelefono").click(function () {

            $("#modalAgregarTelefono").dialog("close");

            //ELEMENTOS CON VALORES INGRESADOS A VARIABLES
            var tipoVal = $("#ddlTipoTelefono").find("option:selected").val();
            var tipoText = $("#ddlTipoTelefono").find("option:selected").text();
            var localidadVal = $("#ddlLocalidadTelefono").find("option:selected").val().split("_");
            var localidadId = localidadVal[0];
            var localidadCodigoArea = localidadVal[1];
            var numero = $("#txtNumeroTelefono").val();

            //CREACION DE BOTON DE ELIMINAR DE FILA
            var boton = document.createElement('input');
            boton.setAttribute('type', 'button');
            boton.setAttribute('value', 'X');
            boton.setAttribute('class', 'btnQuitarTelefono btn btn-danger');

            //INSERCION DE FILA EN TABLA
            $("#tablaTelefonos").append(
                "<tr>" +
                "<td class=\"hidden\">" + tipoVal + "</td>" +
                "<td>" + tipoText + "</td>" +
                "<td class=\"hidden\">" + localidadId + "</td>" +
                "<td>" + localidadCodigoArea + "</td>" +
                "<td>" + numero + "</td>" +
                "<td><input type=\"button\" class=\"btnQuitarTelefono btn btn-danger\" value=\"X\" /></td>" +
                "</tr>"
                );
        });





        //APLICAR CAMBIOS
        $("#btnAplicarCambios").click(function () {



            //VALORES A VARIABLES
            var id = $("#hdnId").val();
            var nombre = $("#txtNombre").val();
            var apellido = $("#txtApellido").val();
            var apodo = $("#txtApodo").val();
            var ocupacion = $("#txtOcupacion").val();
            var caracteristicas = $("#txtCaracteristicas").val();
            var metodos = $("#txtMetodos").val();


            if ((nombre == "" & apellido == "" & apodo == "") |
                ocupacion == "" |
                caracteristicas == "" |
                metodos == "") {
                $(".modulo").effect("shake");
                $("#error").text("CAMPOS INCOMPLETOS!");
                $("#error").effect("puff", function () {
                    $("#error").text("");
                });
            }
            else {
                $("#bg").fadeIn("fast", function () {
                    //AGRESOR A OBJETO
                    var agresor = {
                        Id: id,
                        Nombre: nombre,
                        Apellido: apellido,
                        Apodo: apodo,
                        Ocupacion: ocupacion,
                        Caracteristicas: caracteristicas,
                        Metodos: metodos
                    }


                    //
                    // IMPORTANTE: Solo mantengo los valores necesarios
                    //             de cada fila. Es decir, [id] [entradas] etc...
                    //             que hagan falta para modificar agresor.

                    //DIRECCIONES A OBJETO ARRAY
                    var arrayDirecciones = [];
                    $("#tablaDirecciones tr").each(function () {
                        if (this.className != "hidden") {
                            var arrayFila = [];
                            var contenido = $(this).find('td');
                            if (contenido.length > 0) {
                                contenido.each(function () {
                                    if (this == contenido[0] | // Id tipo direccion
                                        this == contenido[2] | // Id localidad
                                        this == contenido[4] | // Calle
                                        this == contenido[5] | // Numero
                                        this == contenido[6] | // Piso
                                        this == contenido[7]) { // Depto
                                        arrayFila.push($(this).text());
                                    }
                                });
                                arrayDirecciones.push(arrayFila);
                            }
                        }
                    });

                    //REDES SOCIALES A OBJETO ARRAY
                    var arrayRedesSociales = [];
                    $("#tablaRedesSociales tr").each(function () {
                        if (this.className != "hidden") {
                            var arrayFila = [];
                            var contenido = $(this).find('td');
                            if (contenido.length > 0) {
                                contenido.each(function () {
                                    if (this == contenido[0] | // Id tipo red social
                                        this == contenido[2]) { // Nombre
                                        arrayFila.push($(this).text());
                                    }
                                });
                                arrayRedesSociales.push(arrayFila);
                            }
                        }
                    });

                    //TELEFONOS A OBJETO ARRAY
                    var arrayTelefonos = [];
                    $("#tablaTelefonos tr").each(function () {
                        if (this.className != "hidden") {
                            var arrayFila = [];
                            var contenido = $(this).find('td');
                            if (contenido.length > 0) {
                                contenido.each(function () {
                                    if (this == contenido[0] | // Id tipo red social
                                        this == contenido[2] | // Id Localidad
                                        this == contenido[4]) { // Numero tel
                                        arrayFila.push($(this).text());
                                    }
                                });
                                arrayTelefonos.push(arrayFila);
                            }
                        }
                    });


                    //AJAX
                    $.ajax({
                        url: "/Agresores/Modificar",
                        type: "POST",
                        data: {
                            agresor: agresor,
                            arrayDirecciones: arrayDirecciones,
                            arrayRedesSociales: arrayRedesSociales,
                            arrayTelefonos: arrayTelefonos
                        }
                    }).done(function () {
                        window.location = "/Agresores/Listado"
                    });

                });
            }
        });
    });
});