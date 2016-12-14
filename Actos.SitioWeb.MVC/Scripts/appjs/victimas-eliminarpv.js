﻿$(document).ready(function () {

    $("#btnEliminarPV").click(function () {

        //CERRAR VENTANA MODAL
        $("#modalEliminar").dialog("close");
        $("#modalDetalle").dialog("close");


        //VALORES A VARIABLES
        var id = $("#hdnId").text();

        //VOLCAR VALORES A VARIABLE DATA (solo por legibilidad)
        var dataEnvio = {
            Victima: {
                Id: id
            }
        };

        //SOLICITUD DE ENVIO POST
        $.post("/Victimas/Eliminar",
            dataEnvio,
            function () {
                $.ajax({
                    url: "/Victimas/ListadoTablaPV",
                    type: "GET"
                }).done(function (data) {
                    $("#contenedorTabla").empty().append(data);
                });
            });
    });

});