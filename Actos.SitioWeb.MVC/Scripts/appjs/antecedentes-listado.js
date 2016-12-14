$(document).ready(function () {
    $("#bg").fadeOut("fast", function () { 

        //CARGA TABLA
        $.ajax({
            url: "/Antecedentes/ListadoTablaPV",
            type: "GET"
        }).done(function(data){
            $("#divCargando").fadeOut("fast", function () {
                $("#contenedorTabla").hide().empty().append(data).fadeIn();
            });
        });


        //CONFIGURACION PREVIA
        $("#modalCrear").dialog({
            autoOpen: false,
            modal: true,
            width: 450,
            height: 460,
            title: "Nuevo antecedente",
            hide: "fade",
            show: "fade"
        });



        //
        //EVENTOS
        //

        //CREAR ANTECEDENTE
        $("#btnCrear").click(function () {
            $.ajax({
                url: "/Antecedentes/CrearPV",
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
                    var puntajePor = $("#ddlPuntajePor").val();
                    var estadoPor = $("#ddlEstadoPor").val();

                    $.ajax({
                        url: "/Antecedentes/ListadoTablaPV",
                        type: "GET",
                        data: {
                            queBuscar: queBuscar,
                            filtroPor: filtroPor,
                            puntajePor: puntajePor,
                            estadoPor: estadoPor
                        }
                    }).done(function(data){
                        $("#divCargando").fadeOut("fast", function () {
                            $("#contenedorTabla").empty().hide().append(data).fadeIn();
                        });
                    });
                });
            });
        });
    });
});