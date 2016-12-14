$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalDetalle").dialog({
        autoOpen: false,
        modal: true,
        width: 600,
        height: 370,
        title: "Detalle de agresor",
        hide: "fade",
        show: "fade"
    });

    //EVENTOS
    $(".btnDetalle").click(function () {
        var idSeleccionado = $(this).parents("tr").children(".IdClass").children().text();

        $.ajax({
            url: "/Agresores/DetallePV",
            data: { id: idSeleccionado },
            type: "GET"
        }).done(function (data) {
            $("#modalDetalle").dialog("open");
            $("#modalDetalle").empty().append(data);
        });
    });
});