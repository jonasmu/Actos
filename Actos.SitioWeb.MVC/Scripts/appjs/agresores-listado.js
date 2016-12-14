$(document).ready(function () {
    $("#bg").fadeOut("fast", function () {

        //CARGA TABLA
        $.ajax({
            url: "/Agresores/ListadoTablaPV",
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
            height: 450,
            title: "Nuevo agresor",
            hide: "fade",
            show: "fade"
        });


        //
        //EVENTOS
        //

        //CREAR AGRESOR
        $("#btnCrear").click(function () {
            $.ajax({
                url: "/Agresores/CrearPV",
                type: "GET"
            }).done(function (data) {
                $("#modalCrear").dialog('open');
                $("#modalCrear").empty().append(data);
            });
        });



        //BUSCAR EN TABLA
        $("#btnBuscar").click(function () {

            //IMAGEN CARGANDO
            $("#contenedorTabla").fadeOut("fast", function () {
                $("#divCargando").fadeIn("fast", function () {

                    //BUSQUEDA
                    var queBuscar = $("#txtBuscar").val();
                    var filtroPor = $("#ddlFiltroPor").val();
                    var puntajePor = $("#ddlPuntajePor").val();

                    $.ajax({
                        url: "/Agresores/ListadoTablaPV",
                        type: "GET",
                        data: {
                            queBuscar: queBuscar,
                            filtroPor: filtroPor,
                            puntajePor: puntajePor
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
