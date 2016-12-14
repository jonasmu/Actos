$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalDetalle").dialog({
        autoOpen: false,
        modal: true,
        width: 500,
        height: 500,
        title: "Detalle de antecedente",
        hide: "fade",
        show: "fade"
    });

    //EVENTOS
    $(".btnDetalle").click(function () {
        var idSeleccionado = $(this).parents("tr").children(".IdClass").children().text();

        $.ajax({
            url: "/Antecedentes/DetallePV",
            data: { id: idSeleccionado },
            type: "GET"
        }).done(function (data) {
            $("#modalDetalle").dialog("open");
            $("#modalDetalle").empty().append(data);
        });
    });
});