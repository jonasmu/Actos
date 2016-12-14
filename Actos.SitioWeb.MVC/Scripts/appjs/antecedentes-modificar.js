$(document).ready(function () {
    $("#bg").fadeOut("fast", function () {

        //APLICAR CAMBIOS
        $("#btnAplicarCambios").click(function () {
            


            //VALORES A VARIABLES
            var id = $("#hdnId").val();
            var estadoId = $("#ddlTipoEstado").find("option:selected").val();
            var nombre = $("#txtNombre").val();
            var victimaId = $("#hdnVictimaId").val();
            var agresorId = $("#hdnAgresorId").val();
            var fecha = $("#dtpFecha").val();
            var ubicacion = $("#txtUbicacion").val();
            var observaciones = $("#txtObservaciones").val();
            var perjuicios = $("#txtPerjuicios").val();


            if (nombre == "" |
                estadoId == "" |
                victimaId == "" |
                agresorId == "" |
                fecha == "" |
                ubicacion == "" |
                observaciones == "" |
                perjuicios == "") {
                $(".modulo").effect("shake");
                $("#error").text("CAMPOS INCOMPLETOS!");
                $("#error").effect("puff", function () {
                    $("#error").text("");
                });
            }
            else {
                $("#bg").fadeIn("fast", function () {
                    //AGRESOR A OBJETO
                    var antecedente = {
                        Id: $("#hdnId").val(),
                        Nombre: nombre,
                        Estado: { Id: estadoId  },
                        Victima: { Id: victimaId  },
                        Agresor: { Id: agresorId },
                        Fecha: fecha,
                        Ubicacion: ubicacion,
                        Observaciones: observaciones,
                        Perjuicios: perjuicios
                        }

                    //AJAX
                    $.ajax({
                        url: "/Antecedentes/Modificar",
                        type: "POST",
                        data: {
                            antecedente: antecedente,
                        }
                    }).done(function () {
                        window.location = "/Antecedentes/Listado"
                    });
                });
            }
        });

    });
});