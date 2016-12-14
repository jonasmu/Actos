//PANELES
function Panel_ElegirAgresores(fila) {
    var panelAgresores = document.getElementById('panelAgresores');
    var panelDatos = document.getElementById('panelDatos');

    if (panelAgresores.className == 'hidden') {
        panelAgresores.className = 'show';
        panelDatos.className = 'hidden';
    }
    else {
        panelAgresores.className = 'hidden';
        panelDatos.className = 'show';
        document.getElementById('conCuerpo_hdnIdAgresor').value = fila.cells[1].innerText;
        document.getElementById('conCuerpo_btnElegirAgresor').value = fila.cells[2].innerText;
        document.getElementById('conCuerpo_btnElegirAgresor').className = 'btn btn-success form-control';
    }
}

function Panel_ElegirVictimas(fila) {
    var panelVictimas = document.getElementById('panelVictimas');
    var panelDatos = document.getElementById('panelDatos');

    if (panelVictimas.className == 'hidden') {
        panelVictimas.className = 'show';
        panelDatos.className = 'hidden';
    }
    else {
        panelVictimas.className = 'hidden';
        panelDatos.className = 'show';

        document.getElementById('conCuerpo_hdnIdVictima').value = fila.cells[1].innerText;
        document.getElementById('conCuerpo_btnElegirVictima').value = fila.cells[2].innerText;
        document.getElementById('conCuerpo_btnElegirVictima').className = 'btn btn-success form-control';
    }
}

function Panel_Ubicacion(boton) {
    document.getElementById("panelObservaciones").style.display = "none";
    document.getElementById("panelPerjuicios").style.display = "none";
    document.getElementById("btnObservaciones").className = "btn btn-default form-control";
    document.getElementById("btnPerjuicios").className = "btn btn-default form-control";

    var panelUbicacion= document.getElementById("panelUbicacion");
    if (panelUbicacion.style.display == "none") {
        panelUbicacion.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelUbicacion.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Observaciones(boton) {
    document.getElementById("panelUbicacion").style.display = "none";
    document.getElementById("panelPerjuicios").style.display = "none";
    document.getElementById("btnUbicacion").className = "btn btn-default form-control";
    document.getElementById("btnPerjuicios").className = "btn btn-default form-control";

    var panelObservaciones = document.getElementById("panelObservaciones");
    if (panelObservaciones.style.display == "none") {
        panelObservaciones.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelObservaciones.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Perjuicios(boton) {
    document.getElementById("panelObservaciones").style.display = "none";
    document.getElementById("panelUbicacion").style.display = "none";
    document.getElementById("btnObservaciones").className = "btn btn-default form-control";
    document.getElementById("btnUbicacion").className = "btn btn-default form-control";

    var panelPerjuicios = document.getElementById("panelPerjuicios");
    if (panelPerjuicios.style.display == "none") {
        panelPerjuicios.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelPerjuicios.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Editar(boton) {
    panelEditar = document.getElementById('panelEditar');
    if (panelEditar.style.display == 'none') {
        panelEditar.style.display = 'block';
        boton.value = '*';
    }
    else {
        panelEditar.style.display = 'none';
        boton.value = '^';
    }
}

function Panel_Informacion(boton) {
    document.getElementById("panelVictima").style.display = "none";
    document.getElementById("panelAgresor").style.display = "none";
    document.getElementById("conCuerpo_btnVictima").className = "btn btn-default form-control";
    document.getElementById("conCuerpo_btnAgresor").className = "btn btn-default form-control";

    var panelInformacion = document.getElementById("panelInformacion");
    if (panelInformacion.style.display == "none") {
        panelInformacion.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelInformacion.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Victima(boton) {
    document.getElementById("panelInformacion").style.display = "none";
    document.getElementById("panelAgresor").style.display = "none";
    document.getElementById("btnInformacion").className = "btn btn-default form-control";
    document.getElementById("conCuerpo_btnAgresor").className = "btn btn-default form-control";

    var panelVictima = document.getElementById("panelVictima");
    if (panelVictima.style.display == "none") {
        panelVictima.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelVictima.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Agresor(boton) {
    document.getElementById("panelInformacion").style.display = "none";
    document.getElementById("panelVictima").style.display = "none";
    document.getElementById("btnInformacion").className = "btn btn-default form-control";
    document.getElementById("conCuerpo_btnVictima").className = "btn btn-default form-control";

    var panelAgresor = document.getElementById("panelAgresor");
    if (panelAgresor.style.display == "none") {
        panelAgresor.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelAgresor.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}




//ELEGIR
function Elegir_Agresor(fila) {
    document.getElementById('conCuerpo_hdnIdAgresor').value = fila.cells[1].innerText;
    document.getElementById('conCuerpo_litAgresor').innerHTML = fila.cells[2].innerText;
}

function Elegir_Victima(fila) {
    document.getElementById('conCuerpo_hdnIdVictima').value = fila.cells[1].innerText;
    document.getElementById('conCuerpo_litVictima').innerHTML = fila.cells[2].innerText;
}



















//CODIGO OBSOLETO
function VerPanel(elem) {
    document.getElementById('panel1').style.display = 'none';
    document.getElementById('panel2').style.display = 'none';
    document.getElementById('panel3').style.display = 'none';

    elem.style.display = 'block';
}

function VerVictimas(boton) {
    var panel = document.getElementById('conCuerpo_panelVictimas');

    if (panel.style.display == 'none') {
        document.getElementById('formAgresores').style.display = 'none';
        panel.style.display = 'block';
        boton.value = 'Cancelar';
        document.getElementById('botones1').style.display = 'none';
    }
    else {
        document.getElementById('formAgresores').style.display = 'block';
        panel.style.display = 'none';
        boton.value = 'Elegir';
        document.getElementById('botones1').style.display = 'block';
    }
}

function VerAgresores(boton) {
    var panel = document.getElementById('conCuerpo_panelAgresores');

    if (panel.style.display == 'none') {
        document.getElementById('formVictimas').style.display = 'none';
        panel.style.display = 'block';
        boton.value = 'Cancelar';
        document.getElementById('botones1').style.display = 'none';
    }
    else {
        document.getElementById('formVictimas').style.display = 'block';
        panel.style.display = 'none';
        boton.value = 'Elegir';
        document.getElementById('botones1').style.display = 'block';
    }
}


function ValidarPanel1(elem) {
    var nombre = document.getElementById('conCuerpo_txtNombre').value;
    var victima = document.getElementById('conCuerpo_hdnIdVictima').value;
    var agresor = document.getElementById('conCuerpo_hdnIdAgresor').value;

    if ((nombre == null || nombre.length == 0 || /^\s+$/.test(nombre)) ||
      (victima == null || victima.length == 0 || /^\s+$/.test(victima)) ||
      (agresor == null || agresor.length == 0 || /^\s+$/.test(agresor))) {
        document.getElementById('mensaje').style.display = 'block';
    }
    else {
        document.getElementById('mensaje').style.display = 'none';
        VerPanel(elem);
    }
}

function ValidarPanel2(elem) {
    var fecha = document.getElementById('conCuerpo_txtFecha').value;
    var observaciones = document.getElementById('conCuerpo_txtObservaciones').value;
    var perjuicios = document.getElementById('conCuerpo_txtPerjuicios').value;

    if ((fecha == null || fecha.length == 0 || /^\s+$/.test(fecha)) ||
      (observaciones == null || observaciones.length == 0 || /^\s+$/.test(observaciones)) ||
      (perjuicios == null || perjuicios.length == 0 || /^\s+$/.test(perjuicios))) {
        document.getElementById('mensaje').style.display = 'block';
    }
    else {
        document.getElementById('mensaje').style.display = 'none';
        VerPanel(elem);
    }
}

function ValidarPanel3() {
    var ubicacion = document.getElementById('conCuerpo_txtUbicacion').value;

    if ((ubicacion == null || ubicacion.length == 0 || /^\s+$/.test(ubicacion))) {
        document.getElementById('mensaje').style.display = 'block';
        return false;
    }
    else {
        document.getElementById('mensaje').style.display = 'none';
        return true;
    }
}