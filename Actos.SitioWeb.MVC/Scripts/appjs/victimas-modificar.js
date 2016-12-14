$(document).ready(function () {
    $("#bg").fadeOut("fast", function () {

        $("#btnAplicarCambios").click(function () {


            //VALORES A VARIABLES
            var id = $("#hdnId").val();
            var nombre = $("#txtNombre").val();
            var apellido = $("#txtApellido").val();
            var apodo = $("#txtApodo").val();
            var clave = $("#txtClave").val();



            if (nombre == "" |
                apellido == "" |
                apodo == "" |
                clave == "") {
                $(".modulo").effect("shake");
                $("#error").text("CAMPOS INCOMPLETOS!");
                $("#error").effect("puff", function () {
                    $("#error").text("");
                });
            }
            else {
                $("#bg").fadeIn("fast", function () {
                    //AGRESOR A OBJETO
                    var victima = {
                        Id: id,
                        Nombre: nombre,
                        Apellido: apellido,
                        Apodo: apodo,
                        Clave: clave
                    }

                    //AJAX
                    $.ajax({
                        url: "/Victimas/Modificar",
                        type: "POST",
                        data: {
                            victima: victima,
                        }
                    }).done(function () {
                        window.location = "/Victimas/Listado"
                    });
                });
            }
        });
    });
});