using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actos.SitioWeb.MVC.Controllers
{
    public class VictimasController : _ControladorBase
    {
        public ActionResult Listado()
        {
            return View();
        }

        public ActionResult CrearPV()
        {
            return PartialView("CrearPV");
        }

        [HttpPost]
        public void Crear(Victima victima)
        {
            victima.EstaBorrado = false;
            servicioWeb.CrearVictima(victima);
        }

        public ActionResult DetallePV(string id)
        {
            int _id = Convert.ToInt32(id);
            Victima victima = servicioWeb.DevolverVictimaPorId(_id);
            return PartialView("DetallePV", victima);
        }

        public ActionResult EliminarPV(string id)
        {
            int _id = Convert.ToInt32(id);
            Victima victima = servicioWeb.DevolverVictimaPorId(_id);
            return PartialView("EliminarPV", victima);
        }

        [HttpPost]
        public void Eliminar(Victima victima)
        {
            servicioWeb.EliminarVictima(victima);
        }

        public ActionResult Modificar(int id)
        {
            var modelo = servicioWeb.DevolverVictimaPorId(id);
            return View(modelo);
        }

        [HttpPost]
        public void Modificar(Victima victima)
        {
            victima.EstaBorrado = false;
            servicioWeb.ModificarVictima(victima);
        }

        public ActionResult ListadoTablaPV(string queBuscar = "", string filtroPor = "Todos")
        {
            Victima[] listadoVictimas = servicioWeb.DevolverVictimas();

            queBuscar = queBuscar.ToLower().Trim();

            switch (filtroPor)
            {
                case "Todos":
                    listadoVictimas = listadoVictimas
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Apodo.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Nombre":
                    listadoVictimas = listadoVictimas
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Apellido":
                    listadoVictimas = listadoVictimas
                        .Where(x => x.Apellido.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();

                    break;
                case "Apodo":
                    listadoVictimas = listadoVictimas
                        .Where(x => x.Apodo.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();
                    break;
                default:
                    break;
            }

            return PartialView("ListadoTablaPV", listadoVictimas);
        }
    }
}