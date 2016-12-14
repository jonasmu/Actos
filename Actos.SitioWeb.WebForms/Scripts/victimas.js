//PANELES
function Panel_Antecedentes(boton) {
    //document.getElementById("panelDirecciones").style.display = "none";
    //document.getElementById("btnDirecciones").className = "btn btn-default form-control";

    var panelAntecedentes = document.getElementById("panelAntecedentes");
    if (panelAntecedentes.style.display == "none") {
        panelAntecedentes.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelAntecedentes.style.display = "none";
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
    document.getElementById("panelClave").style.display = "none";
    document.getElementById("btnClave").className = "btn btn-default form-control";
    document.getElementById("panelCambiarClave").style.display = 'none';
    document.getElementById("btnCambiarClave").value = "Cambiar clave";

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

function Panel_Clave(boton) {
    document.getElementById("panelInformacion").style.display = "none";
    document.getElementById("btnInformacion").className = "btn btn-default form-control";

    var panelClave = document.getElementById("panelClave");
    if (panelClave.style.display == "none") {
        panelClave.style.display = "block";
        boton.className = "btn btn-warning form-control"
    }
    else {
        panelClave.style.display = "none";
        boton.className = "btn btn-default form-control"
        document.getElementById("panelCambiarClave").style.display = 'none';
        document.getElementById("btnCambiarClave").value = "Cambiar clave";
    }
}

function Panel_CambiarClave() {
    var panelCambiarClave = document.getElementById("panelCambiarClave");
    var botonCambiar = document.getElementById("btnCambiarClave");
    if (panelCambiarClave.style.display == 'none') {
        panelCambiarClave.style.display = 'block';
        botonCambiar.value = "Cancelar";
    }
    else {
        document.getElementById("conCuerpo_txtClaveActual").value = "";
        document.getElementById("conCuerpo_txtClaveNueva").value = "";
        document.getElementById("conCuerpo_txtClaveConfirmar").value = "";
        botonCambiar.value = "Cambiar clave";

        panelCambiarClave.style.display = 'none';
    }
}



//MOSTRAR - OCULTAR
function Mostrar_Clave() {
    var clave = document.getElementById("conCuerpo_hdnClave").value;
    var elem = document.getElementById("spanClave");
    elem.innerHTML = "Hola";
    var x = 1;

    function cuadro() {
        switch (x) {
            case 1:
                elem.innerHTML = "¿Así que queres saber la clave?";
                x++;
                break;
            case 2:
                elem.innerHTML = "Bueno... vas a tener que esperar un cacho";
                x++;
                break;
            case 3:
                elem.innerHTML = "Porque, no se si quiero que la sepas";
                x++;
                break;
            case 4:
                elem.innerHTML = "Esta bien";
                x++;
                break;
            case 5:
                elem.innerHTML = "La clave es";
                x++;
                break;
            case 6:
                elem.innerHTML = "es...";
                x++;
                break;
            case 7:
                elem.innerHTML = "ES.....";
                x++;
                break;
            case 8:
                elem.innerHTML = ".........";
                x++;
                break;
            case 9:
                elem.style.color = 'red';
                elem.innerHTML = clave;
                clearInterval(timer)
                break;
        }
    }
    timer = setInterval(cuadro, 2000);
}

function Ocultar_Clave() {
    clearInterval(timer)
    var elem = document.getElementById("spanClave");
    elem.style.color = 'black';
    elem.innerHTML = "**********";
}



//ELIMINAR
function Eliminar_Victima() {
    if (confirm('¿Seguro que desea eliminar la víctima?')) {
        return true;
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

function Aplicar_CambiarClave() {
    var claveActual = document.getElementById('conCuerpo_txtClaveActual').value;
    var claveNueva = document.getElementById('conCuerpo_txtClaveNueva').value;
    var claveConfirmar = document.getElementById('conCuerpo_txtClaveConfirmar').value;

    if (claveActual == document.getElementById('conCuerpo_hdnClave').value) {
        if (claveActual != claveNueva) {
            if (claveNueva == claveConfirmar) {
                return true;
            }
            else {
                alert("Clave sin confirmar!");
            }
        }
        else {
            alert("La clave nueva no puede ser la misma que la actual!");
        }
    }
    else {
        alert("Clave actual incorrecta!");
    }
    return false;
}

function Aplicar_CambiosModificar() {
    //Aplicar_Agresor();
    Aplicar_Direcciones();
    Aplicar_RedesSociales();
    Aplicar_Telefonos();
}


















