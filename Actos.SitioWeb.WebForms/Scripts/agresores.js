//PANELES
function Panel_Metodos(boton) {

    document.getElementById("panelDirecciones").style.display = "none";
    document.getElementById("panelRedesSociales").style.display = "none";
    document.getElementById("panelTelefonos").style.display = "none";
    document.getElementById("btnDirecciones").className = "btn btn-default form-control";
    document.getElementById("btnRedesSociales").className = "btn btn-default form-control";
    document.getElementById("btnTelefonos").className = "btn btn-default form-control";

    var panelMetodos = document.getElementById("panelMetodos");
    if (panelMetodos.style.display == "none") {
        panelMetodos.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelMetodos.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Direcciones(boton) {

    document.getElementById("panelMetodos").style.display = "none";
    document.getElementById("panelRedesSociales").style.display = "none";
    document.getElementById("panelTelefonos").style.display = "none";
    document.getElementById("btnMetodos").className = "btn btn-default form-control";
    document.getElementById("btnRedesSociales").className = "btn btn-default form-control";
    document.getElementById("btnTelefonos").className = "btn btn-default form-control";

    //var boton = document.getElementById("btnDirecciones");
    var panelDirecciones = document.getElementById("panelDirecciones");
    if (panelDirecciones.style.display == "none") {
        panelDirecciones.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelDirecciones.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_RedesSociales(boton) {

    document.getElementById("panelMetodos").style.display = "none";
    document.getElementById("panelDirecciones").style.display = "none";
    document.getElementById("panelTelefonos").style.display = "none";
    document.getElementById("btnMetodos").className = "btn btn-default form-control";
    document.getElementById("btnDirecciones").className = "btn btn-default form-control";
    document.getElementById("btnTelefonos").className = "btn btn-default form-control";

    var panelRedesSociales = document.getElementById("panelRedesSociales");
    if (panelRedesSociales.style.display == "none") {
        panelRedesSociales.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelRedesSociales.style.display = "none";
        boton.className = "btn btn-default form-control"
    }
}

function Panel_Telefonos(boton) {

    document.getElementById("panelMetodos").style.display = "none";
    document.getElementById("panelDirecciones").style.display = "none";
    document.getElementById("panelRedesSociales").style.display = "none";
    document.getElementById("btnMetodos").className = "btn btn-default form-control";
    document.getElementById("btnDirecciones").className = "btn btn-default form-control";
    document.getElementById("btnRedesSociales").className = "btn btn-default form-control";

    var panelTelefonos = document.getElementById("panelTelefonos");
    if (panelTelefonos.style.display == "none") {
        panelTelefonos.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelTelefonos.style.display = "none";
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

function Panel_AgregarDireccion() {
    var panelAgregarDireccion = document.getElementById("panelAgregarDireccion");
    var botonAgregar = document.getElementById("btnAgregarDireccion");
    if (panelAgregarDireccion.style.display == 'none') {
        panelAgregarDireccion.style.display = 'block';
        botonAgregar.value = "Cancelar";
    }
    else {
        document.getElementById("conCuerpo_ddlTipoDireccion").selectedIndex = 0;
        document.getElementById("conCuerpo_txtCalle").value = "";
        document.getElementById("conCuerpo_txtNumeroDireccion").value = "";
        document.getElementById("panelDepartamento").style.display = 'none';
        botonAgregar.value = "Agregar dirección";

        panelAgregarDireccion.style.display = 'none';
    }
}

function Panel_EsDepartamento() {
    var tipoDireccion = document.getElementById("conCuerpo_ddlTipoDireccion");
    if (tipoDireccion.options[tipoDireccion.selectedIndex].text == 'Departamento') {
        document.getElementById("panelDepartamento").style.display = 'block';
    }
    else {
        document.getElementById("conCuerpo_txtPiso").value = "";
        document.getElementById("conCuerpo_txtDepartamento").value = "";

        document.getElementById("panelDepartamento").style.display = 'none';
    }
}

function Panel_AgregarRedSocial() {
    var panelAgregarRedSocial = document.getElementById("panelAgregarRedSocial");
    var botonAgregar = document.getElementById("btnAgregarRedSocial");
    if (panelAgregarRedSocial.style.display == 'none') {
        panelAgregarRedSocial.style.display = 'block';
        botonAgregar.value = "Cancelar";
    }
    else {
        document.getElementById("conCuerpo_ddlTipoRedSocial").selectedIndex = 0;
        document.getElementById("conCuerpo_txtNombreRedSocial").value = "";
        botonAgregar.value = "Agregar red social";

        panelAgregarRedSocial.style.display = 'none';
        
    }
}

function Panel_AgregarTelefono() {
    var panelAgregarTelefono = document.getElementById("panelAgregarTelefono");
    var botonAgregar = document.getElementById("btnAgregarTelefono");
    if (panelAgregarTelefono.style.display == 'none') {
        panelAgregarTelefono.style.display = 'block';
        botonAgregar.value = "Cancelar";
    }
    else {
        document.getElementById("conCuerpo_ddlTipoTelefono").selectedIndex = 0;
        document.getElementById("conCuerpo_ddlLocalidadTelefono").selectedIndex = 0;
        document.getElementById("conCuerpo_txtNumeroTelefono").value = "";
        botonAgregar.value = "Agregar teléfono";

        panelAgregarTelefono.style.display = 'none';
    }
}



//AGREGAR
function Agregar_Direccion() {
    var boolCalle = true;
    var boolNumero = true;
    var boolPiso = true;
    var boolDepartamento = true;

    var calle = document.getElementById("conCuerpo_txtCalle").value;
    var numero = document.getElementById("conCuerpo_txtNumeroDireccion").value;
    var piso = document.getElementById("conCuerpo_txtPiso").value;
    var departamento = document.getElementById("conCuerpo_txtDepartamento").value;

    if (calle == null || calle.length == 0 || /^\s+$/.test(calle)) {
        document.getElementById("conCuerpo_txtCalle").style = 'background-color:#ffbfbf';
        boolCalle = false;
    }
    if (numero == null || numero.length == 0 || /^\s+$/.test(numero)) {
        document.getElementById("conCuerpo_txtNumeroDireccion").style = 'background-color:#ffbfbf';
        boolNumero = false;
    }

    var tipoDireccion = document.getElementById("conCuerpo_ddlTipoDireccion");
    if (tipoDireccion.options[tipoDireccion.selectedIndex].text == 'Departamento') {
        if (piso == null || piso.length == 0 || /^\s+$/.test(piso)) {
            document.getElementById("conCuerpo_txtPiso").style = 'background-color:#ffbfbf';
            boolPiso = false;
        }

        if (departamento == null || departamento.length == 0 || /^\s+$/.test(departamento)) {
            document.getElementById("conCuerpo_txtDepartamento").style = 'background-color:#ffbfbf';
            boolDepartamento = false;
        }
    }
    else{
        document.getElementById("conCuerpo_txtPiso").value = "";
        document.getElementById("conCuerpo_txtDepartamento").value = "";
    }

    if (boolCalle == true &&
        boolNumero == true &&
        boolPiso == true &&
        boolDepartamento == true) {

        var boton = document.createElement('input');
        var ultimaFila = parseInt(document.getElementById('conCuerpo_hdnUltimaFila_Direcciones').value);
        ultimaFila = (ultimaFila + 1).toString();
        document.getElementById('conCuerpo_hdnUltimaFila_Direcciones').value = ultimaFila;
        boton.setAttribute('type', 'button');
        boton.setAttribute('value', 'Eliminar');
        boton.setAttribute('class', 'btn btn-danger');
        boton.setAttribute('onclick', 'Eliminar_Direccion(' + ultimaFila + ')');

        //CREA TIPO ID Y NOMBRE
        var tipo = document.getElementById('conCuerpo_ddlTipoDireccion');
        var tipoId = document.createTextNode(tipo.options[tipo.selectedIndex].value);
        var tipoNombre = document.createTextNode(tipo.options[tipo.selectedIndex].text);

        //CREA LOCALIDAD ID
        var localidad = document.getElementById('conCuerpo_ddlLocalidadDireccion');
        var localidadId = document.createTextNode(localidad.options[localidad.selectedIndex].value);
        var localidadNombre = document.createTextNode(localidad.options[localidad.selectedIndex].text);

        //CREA CALLE
        var calle = document.createTextNode(document.getElementById('conCuerpo_txtCalle').value);

        //CREA NUMERO
        var numero = document.createTextNode(document.getElementById('conCuerpo_txtNumeroDireccion').value);

        //CREA PISO
        var piso = document.createTextNode(document.getElementById('conCuerpo_txtPiso').value);

        //CREA DEPARTAMENTO
        var departamento = document.createTextNode(document.getElementById('conCuerpo_txtDepartamento').value);

        //ASIGNA VALORES A TABLA (append)
        //id de fila
        var gridView = document.getElementById('conCuerpo_grdDirecciones');
        var nuevaFila = gridView.insertRow();
        nuevaFila.setAttribute('id', 'direcciones_' + ultimaFila);
        //boton eliminar
        (nuevaFila.insertCell()).appendChild(boton);
        //tipo de direccion
        (nuevaFila.insertCell()).appendChild(tipoNombre);
        var celdaOculta = nuevaFila.insertCell();
        celdaOculta.setAttribute('class', 'hide');
        celdaOculta.appendChild(tipoId);
        //localidad
        (nuevaFila.insertCell()).appendChild(localidadNombre);
        celdaOculta = nuevaFila.insertCell();
        celdaOculta.setAttribute('class', 'hide');
        celdaOculta.appendChild(localidadId);
        //calle
        (nuevaFila.insertCell()).appendChild(calle);
        //numero
        (nuevaFila.insertCell()).appendChild(numero);
        //piso
        (nuevaFila.insertCell()).appendChild(piso);
        //departamento
        (nuevaFila.insertCell()).appendChild(departamento);

        //RESETEA VALORES
        Panel_AgregarDireccion();
        return true;
    }
    else {
        if (boolCalle == true) {
            document.getElementById("conCuerpo_txtCalle").style = 'background-color:white';
        }
        if (boolNumero == true) {
            document.getElementById("conCuerpo_txtNumeroDireccion").style = 'background-color:white';
        }
        if (boolPiso == true) {
            document.getElementById("conCuerpo_txtPiso").style = 'background-color:white';
        }
        if (boolDepartamento == true) {
            document.getElementById("conCuerpo_txtDepartamento").style = 'background-color:white';
        }
    }
}

function Agregar_RedSocial() {
    var boolNombre = true;
    var nombre = document.getElementById("conCuerpo_txtNombreRedSocial").value;
    if (nombre == null || nombre.length == 0 || /^\s+$/.test(nombre)) {
        document.getElementById("conCuerpo_txtNombreRedSocial").style = 'background-color:#ffbfbf';
        boolNombre = false;
    }

    if (boolNombre == true) {
        var boton = document.createElement('input');
        var ultimaFila = parseInt(document.getElementById('conCuerpo_hdnUltimaFila_RedesSociales').value);
        ultimaFila = (ultimaFila + 1).toString();
        document.getElementById('conCuerpo_hdnUltimaFila_RedesSociales').value = ultimaFila;
        boton.setAttribute('type', 'button');
        boton.setAttribute('value', 'Eliminar');
        boton.setAttribute('class', 'btn btn-danger');
        boton.setAttribute('onclick', 'Eliminar_RedSocial(' + ultimaFila + ')');

        //CREA TIPO ID Y NOMBRE
        var tipo = document.getElementById('conCuerpo_ddlTipoRedSocial');
        var tipoId = document.createTextNode(tipo.options[tipo.selectedIndex].value);
        var tipoNombre = document.createTextNode(tipo.options[tipo.selectedIndex].text);

        //CREA NOMBRE
        var nombre = document.createTextNode(document.getElementById('conCuerpo_txtNombreRedSocial').value);

        //ASIGNA VALORES A TABLA (append)
        //id de fila
        var gridView = document.getElementById('conCuerpo_grdRedesSociales');
        var nuevaFila = gridView.insertRow();
        nuevaFila.setAttribute('id', 'redesSociales_' + ultimaFila);
        //boton eliminar
        (nuevaFila.insertCell()).appendChild(boton);
        //tipo de tel
        (nuevaFila.insertCell()).appendChild(tipoNombre);
        var celdaOculta = nuevaFila.insertCell();
        celdaOculta.setAttribute('class', 'hide');
        celdaOculta.appendChild(tipoId);
        //nombre
        (nuevaFila.insertCell()).appendChild(nombre);

        //RESETEA VALORES
        Panel_AgregarRedSocial();
    }
}

function Agregar_Telefono() {
    var boolNumeroTelefono = true;
    var numeroTelefono = document.getElementById("conCuerpo_txtNumeroTelefono").value;
    if (numeroTelefono == null || numeroTelefono.length == 0 || /^\s+$/.test(numeroTelefono)) {
        document.getElementById("conCuerpo_txtNumeroTelefono").style = 'background-color:#ffbfbf';
        boolNumeroTelefono = false;
    }

    if (boolNumeroTelefono == true) {

        //CREA BOTON ELIMINAR
        var boton = document.createElement('input');
        var ultimaFila = parseInt(document.getElementById('conCuerpo_hdnUltimaFila_Telefonos').value);
        ultimaFila = (ultimaFila + 1).toString();
        document.getElementById('conCuerpo_hdnUltimaFila_Telefonos').value = ultimaFila;
        boton.setAttribute('type', 'button');
        boton.setAttribute('value', 'Eliminar');
        boton.setAttribute('class', 'btn btn-danger');
        boton.setAttribute('onclick', 'Eliminar_Telefono(' + ultimaFila + ')');

        //CREA TIPO ID Y NOMBRE
        var tipo = document.getElementById('conCuerpo_ddlTipoTelefono');
        var tipoId = document.createTextNode(tipo.options[tipo.selectedIndex].value);
        var tipoNombre = document.createTextNode(tipo.options[tipo.selectedIndex].text);

        //CREA LOCALIDAD ID Y CODIGO DE AREA
        var localidad = document.getElementById('conCuerpo_ddlLocalidadTelefono');
        var localidad_Id_CodigoArea = (localidad.options[localidad.selectedIndex].value).split("_");
        var localidadId = localidad_Id_CodigoArea[0]
        var localidadCodigo = localidad_Id_CodigoArea[1];

        //CREA NUMERO
        var numero = document.createTextNode(document.getElementById('conCuerpo_txtNumeroTelefono').value);

        //ASIGNA VALORES A TABLA (append)
        //id de fila
        var gridView = document.getElementById('conCuerpo_grdTelefonos');
        var nuevaFila = gridView.insertRow();
        nuevaFila.setAttribute('id', 'telefonos_' + ultimaFila);
        //boton eliminar
        (nuevaFila.insertCell()).appendChild(boton);
        //tipo de tel
        (nuevaFila.insertCell()).appendChild(tipoNombre);
        var celdaOculta = nuevaFila.insertCell();
        celdaOculta.setAttribute('class', 'hide');
        celdaOculta.appendChild(tipoId);
        //localidad
        (nuevaFila.insertCell()).appendChild(document.createTextNode(localidadCodigo));
        celdaOculta = nuevaFila.insertCell();
        celdaOculta.setAttribute('class', 'hide');
        celdaOculta.appendChild(document.createTextNode(localidadId));
        //numero
        (nuevaFila.insertCell()).appendChild(numero);

        //RESETEA VALORES
        Panel_AgregarTelefono();
    }
}



//ELIMINAR
function Eliminar_Agresor() {
    if (confirm('¿Seguro que desea eliminar al agresor?')) {
        return true;
    }
    
}

function Eliminar_Direccion(indice) {
    var resultado = confirm("¿Está seguro que desea eliminar la dirección?");
    if (resultado) {
        var fila = document.getElementById('direcciones_' + indice);
        fila.style.display = 'none';
    }
}

function Eliminar_RedSocial(indice) {
    var resultado = confirm("¿Está seguro que desea eliminar la red social?");
    if (resultado) {
        var fila = document.getElementById('redesSociales_' + indice);
        fila.style.display = 'none';
    }
}

function Eliminar_Telefono(indice) {
    var resultado = confirm("¿Está seguro que desea eliminar el teléfono?");
    if (resultado) {
        //document.getElementById('conCuerpo_grdTelefonos').deleteRow(indice + 1);
        var fila = document.getElementById('telefonos_' + indice);
        fila.style.display = 'none';
    }
}



//APLICAR
function Aplicar_Agresor() {
    return Prueba();

    //RESETEA LISTA
    ulMensajes = document.getElementById("ulMensajes");
    while (ulMensajes.firstChild) {
        ulMensajes.removeChild(ulMensajes.firstChild);
    }


    //VALIDACIONES
    var boolNombreApellidoApodo = true;
    var boolOcupacion = true;
    var boolCaracteristicas = true;
    var boolMetodos = true;


    //VALIDA NOMBRE, APELLIDO, APODO
    var nombre = document.getElementById('conCuerpo_txtNombre').value;
    var apellido = document.getElementById('conCuerpo_txtApellido').value;
    var apodo = document.getElementById('conCuerpo_txtApodo').value;

    if ((nombre == null || nombre.length == 0 || /^\s+$/.test(nombre)) &
        (apellido == null || apellido.length == 0 || /^\s+$/.test(apellido)) &
        (apodo == null || apodo.length == 0 || /^\s+$/.test(apodo))) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("El nombre y/o apellido y/o apodo deben ser completados JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolNombreApellidoApodo = false;
    }



    //VALIDA OCUPACION
    var ocupacion = document.getElementById('conCuerpo_txtOcupacion').value;

    if (ocupacion == null || ocupacion.length == 0 || /^\s+$/.test(ocupacion)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("La ocupación no puede quedar vacia JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolOcupacion = false;
    }



    //VALIDA CARACTERISTICAS
    var caracteristicas = document.getElementById('conCuerpo_txtCaracteristicas').value;

    if (caracteristicas == null || caracteristicas.length == 0 || /^\s+$/.test(caracteristicas)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("Las características no pueden quedar vacias JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolCaracteristicas = false;
    }



    //VALIDA METODOS
    var metodos = document.getElementById('conCuerpo_txtMetodos').value;

    if (metodos == null || metodos.length == 0 || /^\s+$/.test(metodos)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("Los métodos no pueden quedar vacios JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolMetodos = false;
    }



    //RESULTADO
    if (boolNombreApellidoApodo == true &&
        boolOcupacion == true &&
        boolCaracteristicas == true &&
        boolMetodos == true) {
        document.getElementById("mensajes").style.display = 'none';
        return true;
    }
    else {
        document.getElementById("mensajes").style.display = 'block';
        return false;
    }
}

function Aplicar_Direcciones() {

    var tablaDeMierda = document.getElementById('conCuerpo_grdDirecciones').rows;
    var cantidadFilas = tablaDeMierda.length - 1;

    var cantidadFilasVisibles = 0;
    for (var i = 1; i <= cantidadFilas; i++) {
        var atributosDeFila = tablaDeMierda[i].attributes.getNamedItem("style");
        if (atributosDeFila == null) {
            cantidadFilasVisibles++;
        }
    }

    ////var matrix = new Array(cantidadFilasVisibles);
    var matrix = [];
    for (i = 0; i < cantidadFilasVisibles; i++) {
        //matrix[i] = new Array(6);
        matrix[i] = [];
    }

    var sumar = 0;
    for (var i = 0; i < cantidadFilas; i++) {
        var atributosDeFila = tablaDeMierda[i + 1].attributes.getNamedItem("style");
        if (atributosDeFila == null) {
            matrix[sumar][0] = tablaDeMierda[i + 1].cells[2].innerText;
            matrix[sumar][1] = tablaDeMierda[i + 1].cells[4].innerText;
            matrix[sumar][2] = tablaDeMierda[i + 1].cells[5].innerText;
            matrix[sumar][3] = tablaDeMierda[i + 1].cells[6].innerText;
            matrix[sumar][4] = tablaDeMierda[i + 1].cells[7].innerText;
            matrix[sumar][5] = tablaDeMierda[i + 1].cells[8].innerText;
            sumar++;
        }
    }

    document.getElementById('conCuerpo_hdnDirecciones').value = matrix;
    return true;
}

function Aplicar_RedesSociales() {

    var tablaDeMierda = document.getElementById('conCuerpo_grdRedesSociales').rows;
    var cantidadFilas = tablaDeMierda.length - 1;

    var cantidadFilasVisibles = 0;
    for (var i = 1; i <= cantidadFilas; i++) {
        var atributosDeFila = tablaDeMierda[i].attributes.getNamedItem("style");
        if (atributosDeFila == null) {
            cantidadFilasVisibles++;
        }
    }

    ////var matrix = new Array(cantidadFilasVisibles);
    var matrix = [];
    for (i = 0; i < cantidadFilasVisibles; i++) {
        //matrix[i] = new Array(2);
        matrix[i] = [];
    }

    var sumar = 0;
    for (var i = 0; i < cantidadFilas; i++) {
        var atributosDeFila = tablaDeMierda[i + 1].attributes.getNamedItem("style");
        if (atributosDeFila == null) {
            matrix[sumar][0] = tablaDeMierda[i + 1].cells[2].innerText;
            matrix[sumar][1] = tablaDeMierda[i + 1].cells[3].innerText;
            sumar++;
        }
    }

    document.getElementById('conCuerpo_hdnRedesSociales').value = matrix;
    return true;
}

function Aplicar_Telefonos() {

    var tablaDeMierda = document.getElementById('conCuerpo_grdTelefonos').rows;
    var cantidadFilas = tablaDeMierda.length - 1;


    var cantidadFilasVisibles = 0;
    for (var i = 1; i <= cantidadFilas; i++) {
        if (tablaDeMierda[i].style.display != 'none') {
            cantidadFilasVisibles++;
        }
    }

    //var cantidadFilasVisibles = 0;
    //for (var i = 1; i <= cantidadFilas; i++) {
    //    //var atributosDeFila = tablaDeMierda[i].attributes.getNamedItem("style");
    //    //if (atributosDeFila == null) {
    //    //    cantidadFilasVisibles++;
    //    //}
    //}

    ////var matrix = new Array(cantidadFilasVisibles);
    var matrix = [];
    for (i = 0; i < cantidadFilasVisibles; i++) {
        //matrix[i] = new Array(3);
        matrix[i] = [];
    }

    var sumar = 0;
    for (var i = 0; i < cantidadFilas; i++) {
        //var atributosDeFila = tablaDeMierda[i + 1].attributes.getNamedItem("style");
        //if (atributosDeFila == null) {
        //    matrix[sumar][0] = tablaDeMierda[i + 1].cells[2].innerText;
        //    matrix[sumar][1] = tablaDeMierda[i + 1].cells[4].innerText;
        //    matrix[sumar][2] = tablaDeMierda[i + 1].cells[5].innerText;
        //    sumar++;
        //}

        if (tablaDeMierda[i + 1].style.display != 'none') {
            matrix[sumar][0] = tablaDeMierda[i + 1].cells[2].innerText;
            matrix[sumar][1] = tablaDeMierda[i + 1].cells[4].innerText;
            matrix[sumar][2] = tablaDeMierda[i + 1].cells[5].innerText;
            sumar++;
        }
    }

    document.getElementById('conCuerpo_hdnTelefonos').value = matrix;
    return true;
}

function Aplicar_CambiosModificar() {
    //Aplicar_Agresor();
    Aplicar_Direcciones();
    Aplicar_RedesSociales();
    Aplicar_Telefonos();
}






