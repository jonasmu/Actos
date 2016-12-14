$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalDetalle").dialog({
        autoOpen: false,
        modal: true,
        width: 400,
        height: 'auto',
        title: "Detalle de víctima",
        hide: "fade",
        show: "fade"
    });

    //EVENTOS
    $(".btnDetalle").click(function () {
        var idSeleccionado = $(this).parents("tr").children(".IdClass").children().text();

        $.ajax({
            url: "/Victimas/DetallePV",
            data: { id: idSeleccionado },
            type: "GET"
        }).done(function (data) {
            $("#modalDetalle").dialog("open");
            $("#modalDetalle").empty().append(data);
        });
    });
});