function AnimarR1() {
    var elem = document.getElementById("r1");
    var width = 0;

    function cuadro() {
        width++;
        elem.style.width = width + '%';

        if (width == 70) {
            clearInterval(id)
        }
    }
    var id = setInterval(cuadro, 15);
}

function AnimarR2() {
    var elem = document.getElementById("r2");
    var bottom = -100;

    function cuadro() {
        bottom++;
        elem.style.bottom = bottom + '%';

        if (bottom == -50) {
            clearInterval(id)
        }
    }
    var id = setInterval(cuadro, 20);
}