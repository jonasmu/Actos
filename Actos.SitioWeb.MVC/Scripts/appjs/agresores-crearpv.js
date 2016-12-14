$(document).ready(function () {

    $("#btnCrearPV").click(function () {

        //VALORES A VARIABLES
        var nombre = $("#Nombre").val();
        var apellido = $("#Apellido").val();
        var apodo = $("#Apodo").val();
        var ocupacion = $("#Ocupacion").val();
        var caracteristicas = $("#Caracteristicas").val();
        var metodos = $("#Metodos").val();


        if ((nombre == "" & apellido == "" & apodo == "") |
            ocupacion == "" |
            caracteristicas == "" |
            metodos == "") {

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
                Agresor: {
                    Nombre: nombre,
                    Apellido: apellido,
                    Apodo: apodo,
                    Ocupacion: ocupacion,
                    Caracteristicas: caracteristicas,
                    Metodos: metodos
                }
            };

            //console.log("Por cargar xml");
            //var xmlPepe = '<agresorLoco>' +
            //    '<Nombre>nomb</Nombre>' +
            //    '<Apellido>ape</Apellido>' +
            //    '<Apodo>apo</Apodo>' +
            //    '<Ocupacion>ocupa</Ocupacion>' +
            //    '<Caracteristicas>carac</Caracteristicas>' +
            //    '<Metodos>met</Metodos></agresorLoco>';

            //var agresorLoco = $.parseXML(xmlPepe);
            //console.log("ya cargado434");
            //console.log(agresorLoco);

            //SOLICITUD DE ENVIO POST
            $.post("/Agresores/Crear",
                    dataEnvio,
                    function () {
                        $.ajax({
                            url: "/Agresores/ListadoTablaPV",
                            type: "GET"
                        }).done(function (data) {
                            $("#contenedorTabla").empty().append(data);
                        });
                    });
        }
    });
});