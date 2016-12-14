$(document).ready(function () {
    $("#bg").fadeOut("fast", function () {

        //CARGA TABLA
        $.ajax({
            url: "/Victimas/ListadoTablaPV",
            type: "GET"
        }).done(function (data) {
            $("#divCargando").fadeOut("fast", function () {
                $("#contenedorTabla").hide().empty().append(data).fadeIn();
            });
        });


        //CONFIGURACION PREVIA
        $("#modalCrear").dialog({
            autoOpen: false,
            modal: true,
            width: 400,
            height: 320,
            title: "Nueva víctima",
            hide: "fade",
            show: "fade"
        });


        //
        //EVENTOS
        //

        //CREAR VICTIMA
        $("#btnCrear").click(function () {
            $.ajax({
                url: "/Victimas/CrearPV",
                type: "GET"
            }).done(function (data) {
                $("#modalCrear").dialog("open");
                $("#modalCrear").empty().append(data);
            });
        });

        $("#btnBuscar").click(function () {

            //IMAGEN CARGANDO
            $("#contenedorTabla").fadeOut("fast", function () {
                $("#divCargando").fadeIn("fast", function () {


                    //BUSQUEDA
                    var queBuscar = $("#txtBuscar").val();
                    var filtroPor = $("#ddlFiltroPor").val();

                    $.ajax({
                        url: "/Victimas/ListadoTablaPV",
                        type: "GET",
                        data: {
                            queBuscar: queBuscar,
                            filtroPor: filtroPor
                        }
                    }).done(function (data) {
                        $("#divCargando").fadeOut("fast", function () {
                            $("#contenedorTabla").empty().hide().append(data).fadeIn();
                        });
                    });
                });
            });
        });
    });
});
