$(document).ready(function () {

    //CREAR ANTECEDENTE
    $("#btnCrearPV").click(function () {

        //VALORES A VARIABLES
        var nombre = $("#Nombre").val();
        var victimaId = $("#hdnVictimaId").val();
        var agresorId = $("#hdnAgresorId").val();
        var fecha = $("#dtpFecha").val();
        var ubicacion = $("#Ubicacion").val();
        var observaciones = $("#Observaciones").val();
        var perjuicios = $("#Perjuicios").val();



        if (nombre == "" |
            victimaId == "" |
            agresorId == "" |
            fecha == "" |
            ubicacion == "" |
            observaciones == "" |
            perjuicios == "") {

            $("#modalCrear").effect("shake");
            $("#error").text("CAMPOS INCOMPLETOS!");
            $("#error").effect("puff", function () {
                $("#error").text("");
            });
        }
        else {

            //CERRAR VENTANA MODAL
            $("#modalCrear").dialog("close");

            //VOLCAR VALORES A VARIABLE DATA (solo por legibilidad)
            var dataEnvio = {
                Antecedente: {
                    Nombre: nombre,
                    Victima: { Id: victimaId },
                    Agresor: { Id: agresorId },
                    Fecha: fecha,
                    Ubicacion: ubicacion,
                    Observaciones: observaciones,
                    Perjuicios: perjuicios
                }
            };

            //SOLICITUD DE ENVIO POST
            $.post("/Antecedentes/Crear",
                dataEnvio,
                function () {
                    $.ajax({
                        url: "/Antecedentes/ListadoTablaPV",
                        type: "GET"
                    }).done(function (data) {
                        $("#contenedorTabla").empty().append(data);
                    });
                });
        }
    });

});