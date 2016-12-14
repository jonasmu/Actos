
//VALIDACIONES
function Validar_AgresorNuevo() {

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

function Validar_VictimaNuevo() {

    //RESETEA LISTA
    ulMensajes = document.getElementById("ulMensajes");
    while (ulMensajes.firstChild) {
        ulMensajes.removeChild(ulMensajes.firstChild);
    }


    //VALIDACIONES
    var boolNombre = true;
    var boolApellido = true;
    var boolApodo = true;
    var boolClave = true;

    //VALIDA NOMBRE
    var nombre = document.getElementById('conCuerpo_txtNombre').value;

    if (nombre == null || nombre.length == 0 || /^\s+$/.test(nombre)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("El nombre debe ser completado JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolNombre = false;
    }

    //VALIDA APELLIDO
    var apellido = document.getElementById('conCuerpo_txtApellido').value;

    if (apellido == null || apellido.length == 0 || /^\s+$/.test(apellido)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("El apellido debe ser completado JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolApellido = false;
    }

    //VALIDA APODO
    var apodo = document.getElementById('conCuerpo_txtApodo').value;

    if (apodo == null || apodo.length == 0 || /^\s+$/.test(apodo)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("El apodo debe ser completado JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolApodo = false;
    }

    //VALIDA CLAVE
    var clave = document.getElementById('conCuerpo_txtClave').value;

    if (clave == null || clave.length == 0 || /^\s+$/.test(clave)) {
        var li = document.createElement("li");
        var contenido = document.createTextNode("La clave no puede quedar vacía JAVASCRIPT");
        li.appendChild(contenido);
        ulMensajes.appendChild(li);
        boolClave = false;
    }


    //RESULTADO
    if (boolNombre == true &&
        boolApellido == true &&
        boolApodo == true &&
        boolClave == true) {
        document.getElementById("mensajes").style.display = 'none';
        return true;
    }
    else {
        document.getElementById("mensajes").style.display = 'block';
        return false;
    }
}

function AceptarValidacionesIncompletas() {
    document.getElementById("mensajes").style.display = 'none';
}


//BOTONES MOSTRAR OCULTAR
function Metodos(boton) {

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

function Direcciones(boton) {

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

function RedesSociales(boton) {

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

function Telefonos(boton) {

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


//AGREGAR DIRECCION
function AgregarDireccion() {
    var panelAgregarDireccion = document.getElementById("panelAgregarDireccion");
    var botonAgregar = document.getElementById("btnAgregarDireccion");
    if (panelAgregarDireccion.style.display == 'none') {
        panelAgregarDireccion.style.display = 'block';
        botonAgregar.value = "Cancelar";
        document.getElementById("conCuerpo_ddlTipoDIreccion").selectedIndex = 0;
        document.getElementById("panelDepartamento").style.display = 'none';
    }
    else {
        panelAgregarDireccion.style.display = 'none';
        botonAgregar.value = "Agregar dirección";
    }
}

function EsDepartamento() {
    var tipoDireccion = document.getElementById("conCuerpo_ddlTipoDIreccion");
    if (tipoDireccion.options[tipoDireccion.selectedIndex].text == 'Departamento') {
        document.getElementById("panelDepartamento").style.display = 'block';
    }
    else {
        document.getElementById("panelDepartamento").style.display = 'none';
    }
}

function Validar_AgregarDireccion() {
    var boolCalle = true;
    var boolNumero = true;
    var calle = document.getElementById("conCuerpo_txtCalle").value;
    var numero = document.getElementById("conCuerpo_txtNumeroDireccion").value;

    if (calle == null || calle.length == 0 || /^\s+$/.test(calle)) {
        document.getElementById("conCuerpo_txtCalle").style = 'background-color:#ffbfbf';
        boolCalle = false;
    }

    if (numero == null || numero.length == 0 || /^\s+$/.test(numero)) {
        document.getElementById("conCuerpo_txtNumeroDireccion").style = 'background-color:#ffbfbf';
        boolNumero = false;
    }




    var tipoDireccion = document.getElementById("conCuerpo_ddlTipoDIreccion");
    if (tipoDireccion.options[tipoDireccion.selectedIndex].text == 'Departamento') {
        var boolPiso = true;
        var boolDepartamento = true;
        var piso = document.getElementById("conCuerpo_txtPiso").value;
        var departamento = document.getElementById("conCuerpo_txtDepartamento").value;


        if (piso == null || piso.length == 0 || /^\s+$/.test(piso)) {
            document.getElementById("conCuerpo_txtPiso").style = 'background-color:#ffbfbf';
            boolPiso = false;
        }

        if (departamento == null || departamento.length == 0 || /^\s+$/.test(departamento)) {
            document.getElementById("conCuerpo_txtDepartamento").style = 'background-color:#ffbfbf';
            boolDepartamento = false;
        }

        if (boolCalle == true &&
            boolNumero == true &&
            boolPiso == true &&
            boolDepartamento == true) {
            alert("OK");
            return true;
        }
        else {
            alert("NO ES VALIDO");
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
            return false;
        }


    }
    else {
        if (boolCalle == true &&
            boolNumero == true) {
            alert("OK");
            return true;
        }
        else {
            alert("NO ES VALIDO");
            if (boolCalle == true) {
                document.getElementById("conCuerpo_txtCalle").style = 'background-color:white';
            }
            if (boolNumero == true) {
                document.getElementById("conCuerpo_txtNumeroDireccion").style = 'background-color:white';
            }
            return false;
        }
    }
}


//AGREGAR RED SOCIAL
function AgregarRedSocial() {
    var panelAgregarRedSocial = document.getElementById("panelAgregarRedSocial");
    var botonAgregar = document.getElementById("btnAgregarRedSocial");
    if (panelAgregarRedSocial.style.display == 'none') {
        panelAgregarRedSocial.style.display = 'block';
        botonAgregar.value = "Cancelar";
        document.getElementById("conCuerpo_ddlTipoRedSocial").selectedIndex = 0;
    }
    else {
        panelAgregarRedSocial.style.display = 'none';
        botonAgregar.value = "Agregar red social";
    }
}

function Validar_AgregarRedSocial() {
    var boolNombre = true;
    var nombre = document.getElementById("conCuerpo_txtNombreRedSocial").value;

    if (nombre == null || nombre.length == 0 || /^\s+$/.test(nombre)) {
        document.getElementById("conCuerpo_txtNombreRedSocial").style = 'background-color:#ffbfbf';
        boolNombre = false;
    }

    if (boolNombre == true) {
        alert("OK");
        return true;
    }
    else {
        alert("NO ES VALIDO");
        return false;
    }
}



//AGREGAR TELEFONO
function AgregarTelefono() {
    var panelAgregarTelefono = document.getElementById("panelAgregarTelefono");
    var botonAgregar = document.getElementById("btnAgregarTelefono");
    if (panelAgregarTelefono.style.display == 'none') {
        panelAgregarTelefono.style.display = 'block';
        botonAgregar.value = "Cancelar";
        document.getElementById("conCuerpo_ddlTipoTelefono").selectedIndex = 0;
    }
    else {
        panelAgregarTelefono.style.display = 'none';
        botonAgregar.value = "Agregar teléfono";
    }
}

function Validar_AgregarTelefono() {
    var boolNumeroTelefono = true;
    var numeroTelefono = document.getElementById("conCuerpo_txtNumeroTelefono").value;

    if (numeroTelefono == null || numeroTelefono.length == 0 || /^\s+$/.test(numeroTelefono)) {
        document.getElementById("conCuerpo_txtNumeroTelefono").style = 'background-color:#ffbfbf';
        boolNumeroTelefono = false;
    }

    if (boolNumeroTelefono == true) {
        alert("OK");
        return true;
    }
    else {
        alert("NO ES VALIDO");
        return false;
    }
}