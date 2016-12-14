$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalElegirVictima").dialog({
        autoOpen: false,
        modal: true,
        width: 400,
        height: 500,
        title: "Elegir víctima",
        hide: "fade",
        show: "fade"
    });

    $("#modalElegirAgresor").dialog({
        autoOpen: false,
        modal: true,
        width: 400,
        height: 500,
        title: "Elegir agresor",
        hide: "fade",
        show: "fade"
    });

    $(function () {
        $("#dtpFecha").datepicker({
            maxDate: '0' //Fecha maxima hoy
        });
    });



    //
    // EVENTOS
    //

    $("#btnElegirVictima").click(function () {
        $.ajax({
            url: "/Antecedentes/ElegirVictimaPV",
            type: "GET"
        }).done(function (data) {
            $("#modalElegirVictima").dialog("open");
            $("#modalElegirVictima").empty().append(data);
        });
    });

    $("#btnElegirAgresor").click(function () {
        $.ajax({
            url: "/Antecedentes/ElegirAgresorPV",
            type: "GET"
        }).done(function (data) {
            $("#modalElegirAgresor").dialog("open");
            $("#modalElegirAgresor").empty().append(data);
        });
    });


    $(document).on("click", ".classElegirVictima", function () {
        //$(".classElegirVictima").click(function () {

        $("#modalElegirVictima").dialog("close");

        var idSeleccionado = $(this).parents("tr").children(".IdClass").children().text();
        var nombre = $(this).parents("tr").children(".nombreClass").children().text();
        $("#hdnVictimaId").val(idSeleccionado);
        $("#spanVictimaElegida").text(nombre);
    });

    $(document).on("click", ".classElegirAgresor", function () {
        //$(".classElegirAgresor").click(function () {

        $("#modalElegirAgresor").dialog("close");

        var idSeleccionado = $(this).parents("tr").children(".IdClass").children().text();
        var nombre = $(this).parents("tr").children(".nombreClass").children().text();
        $("#hdnAgresorId").val(idSeleccionado);
        $("#spanAgresorElegido").text(nombre);
    });

});