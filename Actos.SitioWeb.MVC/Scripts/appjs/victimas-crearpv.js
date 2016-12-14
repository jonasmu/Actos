$(document).ready(function () {

    $("#btnCrearPV").click(function () {

        //VALORES A VARIABLES
        var nombre = $("#Nombre").val();
        var apellido = $("#Apellido").val();
        var apodo = $("#Apodo").val();
        var clave = $("#Clave").val();

        if (nombre == "" |
             apellido == "" |
             apodo == "" |
             clave == "") {

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
                Victima: {
                    Nombre: nombre,
                    Apellido: apellido,
                    Apodo: apodo,
                    Clave: clave
                }
            };

            //SOLICITUD DE ENVIO POST
            $.post("/Victimas/Crear",
                dataEnvio,
                function () {
                    $.ajax({
                        url: "/Victimas/ListadoTablaPV",
                        type: "GET"
                    }).done(function (data) {
                        $("#contenedorTabla").empty().append(data);
                    });
                });
        }
    });
});