$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalEliminar").dialog({
        autoOpen: false,
        modal: true,
        width: 300,
        height: 'auto',
        title: "Eliminar agresor",
        hide: "explode",
        show: "fade"
    });



    //ELIMINAR
    $("#btnEliminar").click(function () {
        var id = $("#hdnId").text();

        $.ajax({
            url: "/Agresores/EliminarPV",
            data: { id: id },
            type: "GET"
        }).done(function (data) {
            $("#modalEliminar").dialog("open");
            $("#modalEliminar").empty().append(data);
        });
    });


    $("#btnModificar").click(function () {
        $("#bg").fadeIn("fast", function () {
            window.location.href = "Modificar/" + $("#hdnId").text();
        });
    });



    //RESETEAR VALORES DE DETALLE
    function ResetearPantalla() {
        $("#divInformacion").hide();
        $("#divDirecciones").hide();
        $("#divRedesSociales").hide();
        $("#divTelefonos").hide();

        $("#btnInformacion").attr("class", "btn btn-default btn-xs");
        $("#btnDirecciones").attr("class", "btn btn-default btn-xs");
        $("#btnRedesSociales").attr("class", "btn btn-default btn-xs");
        $("#btnTelefonos").attr("class", "btn btn-default btn-xs");
    };





    //INFORMACION
    $("#btnInformacion").click(function () {
        ResetearPantalla();
        $("#btnInformacion").attr("class", "btn btn-warning btn-xs");
        $("#divInformacion").fadeIn();
    });


    //DIRECCIONES
    $("#btnDirecciones").click(function () {
        var direccionesCargadas = $("#hdnDireccionesCargadas").val();

        if (direccionesCargadas == "false") {
            var id = $("#hdnId").text();

            $.ajax({
                url: "/Agresores/DireccionesPV",
                data: { id: id },
                type: "GET"
            }).done(function (data) {
                $("#divDirecciones").empty().append(data);
            });

            $("#hdnDireccionesCargadas").val("true");
        }

        ResetearPantalla();
        $("#btnDirecciones").attr("class", "btn btn-warning btn-xs");
        $("#divDirecciones").fadeIn();
    });


    //REDES SOCIALES
    $("#btnRedesSociales").click(function () {

        if ($("#hdnRedesSocialesCargadas").val() == "false") {
            var id = $("#hdnId").text();

            $.ajax({
                url: "/Agresores/RedesSocialesPV",
                data: { id: id },
                type: "GET"
            }).done(function (data) {
                $("#divRedesSociales").empty().append(data);
            });

            $("#hdnRedesSocialesCargadas").val("true");
        }

        ResetearPantalla();
        $("#btnRedesSociales").attr("class", "btn btn-warning btn-xs");
        $("#divRedesSociales").fadeIn();
    });


    //TELEFONOS
    $("#btnTelefonos").click(function () {

        if ($("#hdnTelefonosCargados").val() == "false") {
            var id = $("#hdnId").text();

            $.ajax({
                url: "/Agresores/TelefonosPV",
                data: { id: id },
                type: "GET"
            }).done(function (data) {
                $("#divTelefonos").empty().append(data);
            });

            $("#hdnTelefonosCargados").val("true");
        }

        ResetearPantalla();
        $("#btnTelefonos").attr("class", "btn btn-warning btn-xs");
        $("#divTelefonos").fadeIn();
    });
});