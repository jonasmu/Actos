$(document).ready(function () {

    //CONFIGURACION PREVIA
    $("#modalEliminar").dialog({
        autoOpen: false,
        modal: true,
        width: 400,
        height: 'auto',
        title: "Eliminar antecedente",
        hide: "explode",
        show: "fade"
    });


    $("#btnModificar").click(function () {
        $("#bg").fadeIn("fast", function () {
            window.location.href = "Modificar/" + $("#hdnId").text();
        });
    });

    $("#btnEliminar").click(function () {
        var id = $("#hdnId").text();

        $.ajax({
            url: "/Antecedentes/EliminarPV",
            data: {id: id},
            type: "GET"
        }).done(function (data) {
            $("#modalEliminar").dialog("open");
            $("#modalEliminar").empty().append(data);
        });
    });
});