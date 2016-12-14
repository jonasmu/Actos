using Actos.SitioWeb.MVC.Models.Agresores;
using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actos.SitioWeb.MVC.Controllers
{
    public class AgresoresController : _ControladorBase
    {
        public ActionResult Listado()
        {
            return View();
        }

        public ActionResult ListadoTablaPV(string queBuscar = "", string filtroPor = "Todos", string puntajePor = "Todos")
        {
            Agresor[] listadoAgresores = servicioWeb.DevolverAgresores(false, false, false);

            queBuscar = queBuscar.ToLower().Trim();

            switch (filtroPor)
            {
                case "Todos":
                    listadoAgresores = listadoAgresores
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apodo.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Nombre":
                    listadoAgresores = listadoAgresores
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Apellido":
                    listadoAgresores = listadoAgresores
                        .Where(x => x.Apellido.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();

                    break;
                case "Apodo":
                    listadoAgresores = listadoAgresores
                        .Where(x => x.Apodo.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();
                    break;
                default:
                    break;
            }

            switch (puntajePor)
            {
                case "Todos":
                    listadoAgresores = listadoAgresores
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apodo.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "SinPuntos":
                    listadoAgresores = listadoAgresores
                       .Where(x => x.Puntaje == 0)
                       .ToArray();
                    break;
                case "Bajos":
                    listadoAgresores = listadoAgresores
                       .Where(x => x.Puntaje > 0 &
                                   x.Puntaje <= 15)
                       .ToArray();
                    break;
                case "Medios":
                    listadoAgresores = listadoAgresores
                        .Where(x => x.Puntaje > 15 &
                                    x.Puntaje <= 50)
                        .ToArray();

                    break;
                case "Altos":
                    listadoAgresores = listadoAgresores
                        .Where(x => x.Puntaje > 50)
                        .ToArray();
                    break;
                default:
                    break;
            }

            return PartialView("ListadoTablaPV", listadoAgresores);
        }

        public ActionResult CrearPV()
        {
            return PartialView("CrearPV");
        }

        [HttpPost]
        public void Crear(Agresor agresor)
        {
            agresor.EstaBorrado = false;
            servicioWeb.CrearAgresor(agresor);
        }

        public ActionResult DetallePV(string id)
        {
            int _id = Convert.ToInt32(id);
            Agresor agresor = servicioWeb.DevolverAgresorPorId(_id, false, false, false);
            return PartialView("DetallePV", agresor);
        }

        public ActionResult DireccionesPV(string id)
        {
            int _id = Convert.ToInt32(id);
            Direccion[] direcciones = servicioWeb.DevolverAgresorPorId(_id, false, true, false).Direcciones;
            return PartialView("DireccionesPV", direcciones);
        }

        public ActionResult RedesSocialesPV(string id)
        {
            int _id = Convert.ToInt32(id);
            RedSocial[] redesSociales = servicioWeb.DevolverAgresorPorId(_id, false, false, true).RedesSociales;
            return PartialView("RedesSocialesPV", redesSociales);
        }

        public ActionResult TelefonosPV(string id)
        {
            int _id = Convert.ToInt32(id);
            Telefono[] telefonos = servicioWeb.DevolverAgresorPorId(_id, true, false, false).Telefonos;
            return PartialView("TelefonosPV", telefonos);
        }

        public ActionResult EliminarPV(string id)
        {
            int _id = Convert.ToInt32(id);
            Agresor agresor = servicioWeb.DevolverAgresorPorId(_id, false, false, false);
            return PartialView("EliminarPV", agresor);
        }

        [HttpPost]
        public void Eliminar(Agresor agresor)
        {
            servicioWeb.EliminarAgresor(agresor);
        }

        public ActionResult Modificar(int id)
        {
            var modelo = new ModificarViewModel();
            modelo.Agresor = servicioWeb.DevolverAgresorPorId(id, true, true, true);
            modelo.Localidades = servicioWeb.DevolverLocalidad();
            modelo.TiposDirecciones = servicioWeb.DevolverTiposDirecciones();
            modelo.TiposRedesSociales = servicioWeb.DevolverTiposRedesSociales();
            modelo.TiposTelefonos = servicioWeb.DevolverTiposTelefonos();
            return View(modelo);
        }

        [HttpPost]
        public void Modificar(Agresor agresor, string[][] arrayDirecciones, string[][] arrayRedesSociales, string[][] arrayTelefonos)
        {
            if (ModelState.IsValid)
            {

            }

            //DIRECCIONES ARRAY A OBJETO
            List<Direccion> listaDirecciones = new List<Direccion>();
            if (arrayDirecciones != null)
            {
                foreach (var item in arrayDirecciones)
                {
                    var direccion = new Direccion();
                    direccion.Tipo = new TipoDireccion() { Id = Convert.ToByte(item[0]) };
                    direccion.Localidad = new Localidad() { Id = Convert.ToInt32(item[1]) };
                    direccion.Calle = item[2];
                    direccion.Numero = item[3];
                    direccion.Piso = item[4];
                    direccion.Departamento = item[5];
                    listaDirecciones.Add(direccion);
                }
            }


            //REDES SOCIALES ARRAY A OBJETO
            List<RedSocial> listaRedesSociales = new List<RedSocial>();
            if (arrayRedesSociales != null)
            {
                foreach (var item in arrayRedesSociales)
                {
                    var redSocial = new RedSocial();
                    redSocial.Tipo = new TipoRedSocial() { Id = Convert.ToByte(item[0]) };
                    redSocial.Nombre = item[1];
                    listaRedesSociales.Add(redSocial);
                }
            }

            //TELEFONOS ARRAY A OBJETO
            List<Telefono> listaTelefonos = new List<Telefono>();
            if (arrayTelefonos != null)
            {
                foreach (var item in arrayTelefonos)
                {
                    var telefono = new Telefono();
                    telefono.Tipo = new TipoTelefono() { Id = Convert.ToByte(item[0]) };
                    telefono.Localidad = new Localidad() { Id = Convert.ToInt32(item[1]) };
                    telefono.Numero = item[2];
                    listaTelefonos.Add(telefono);
                }
            }

            //AGREGO LISTAS A AGRESOR (transformo a array)
            agresor.Direcciones = listaDirecciones.ToArray();
            agresor.RedesSociales = listaRedesSociales.ToArray();
            agresor.Telefonos = listaTelefonos.ToArray();

            //CHECK AGRESOR
            agresor.EstaBorrado = false;
            if (agresor.Nombre == null) { agresor.Nombre = ""; }
            if (agresor.Apellido == null) { agresor.Apellido = ""; }
            if (agresor.Apodo == null) { agresor.Apodo = ""; }

            //SERVICIOWEB A BASE DE DATOS
            servicioWeb.ModificarAgresor(agresor);
        }
    }
}