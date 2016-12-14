$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalEliminar").dialog({
        autoOpen: false,
        modal: true,
        width: 300,
        height: 'auto',
        title: "Eliminar víctima",
        hide: "explode",
        show: "fade"
    });




    $("#btnEliminar").click(function () {
        var id = $("#hdnId").text();

        $.ajax({
            url: "/Victimas/EliminarPV",
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
});