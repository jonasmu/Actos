using Actos.SitioWeb.MVC.Models.Antecedentes;
using Actos.SitioWeb.MVC.ServicioWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Actos.SitioWeb.MVC.Controllers
{
    public class AntecedentesController : _ControladorBase
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
        public void Crear(Antecedente antecedente)
        {
            antecedente.Estado = new Estado() { Id = 1 };
            servicioWeb.CrearAntecedente(antecedente);
        }

        public ActionResult ElegirVictimaPV()
        {
            var modelo = servicioWeb.DevolverVictimas();
            return PartialView("ElegirVictimaPV", modelo);
        }

        public ActionResult ElegirAgresorPV()
        {
            var modelo = servicioWeb.DevolverAgresores(false, false, false);
            return PartialView("ElegirAgresorPV", modelo);
        }

        public ActionResult DetallePV(string id)
        {
            int _id = Convert.ToInt32(id);
            Antecedente antecedente = servicioWeb.DevolverAntecedentePorId(_id, true);
            return PartialView("DetallePV", antecedente);
        }

        public ActionResult EliminarPV(string id)
        {
            int _id = Convert.ToInt32(id);
            Antecedente antecedente = servicioWeb.DevolverAntecedentePorId(_id, false);
            return PartialView("EliminarPV", antecedente);
        }

        [HttpPost]
        public void Eliminar(Antecedente antecedente)
        {
            servicioWeb.EliminarAntecedente(antecedente);
        }

        public ActionResult Modificar(int id)
        {
            var modelo = new ModificarViewModel();
            modelo.Antecedente = servicioWeb.DevolverAntecedentePorId(id, false);
            modelo.Estados = servicioWeb.DevolverEstados();
            return View(modelo);
        }

        [HttpPost]
        public void Modificar(Antecedente antecedente)
        {
            servicioWeb.ModificarAntecedente(antecedente);
        }

        public ActionResult ListadoTablaPV(string queBuscar = "", string filtroPor = "Todos", string puntajePor = "Todos", string estadoPor = "Todos")
        {
            Antecedente[] listadoAntecentes = servicioWeb.DevolverAntecedentes(true);

            queBuscar = queBuscar.ToLower().Trim();
               

            switch (filtroPor)
            {
                case "Todos":
                    listadoAntecentes = listadoAntecentes
                       .Where(x => x.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Victima.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Victima.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Victima.Apodo.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Agresor.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Agresor.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Agresor.Apodo.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Victima":
                    listadoAntecentes = listadoAntecentes
                       .Where(x => x.Victima.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Victima.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                   x.Victima.Apodo.ToLower().Trim().StartsWith(queBuscar))
                       .ToArray();
                    break;
                case "Agresor":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Agresor.Nombre.ToLower().Trim().StartsWith(queBuscar) |
                                    x.Agresor.Apellido.ToLower().Trim().StartsWith(queBuscar) |
                                    x.Agresor.Apodo.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();
                    break;
                case "Ubicacion":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Ubicacion.ToLower().Trim().StartsWith(queBuscar))
                        .ToArray();
                    break;
                default:
                    break;
            }

            switch (puntajePor)
            {
                case "Todos":
                    //listadoAntecentes = listadoAntecentes.ToArray();
                    break;
                case "SinPuntos":
                    listadoAntecentes = listadoAntecentes
                       .Where(x => x.Puntajes.Count() == 0)
                       .ToArray();
                    break;
                case "Bajos":
                    listadoAntecentes = listadoAntecentes
                       .Where(x => x.Puntajes.Count() > 0 &
                                   x.Puntajes.Count() <= 15)
                       .ToArray();
                    break;
                case "Medios":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Puntajes.Count() > 15 &
                                    x.Puntajes.Count() <= 50)
                        .ToArray();

                    break;
                case "Altos":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Puntajes.Count() > 50)
                        .ToArray();
                    break;
                default:
                    break;
            }

            switch (estadoPor)
            {
                case "Todos":
                    //listadoAntecentes = listadoAntecentes.ToArray();
                    break;
                case "Activo":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Estado.Id == 1).ToArray();
                    break;
                case "Inactivo":
                    listadoAntecentes = listadoAntecentes
                        .Where(x => x.Estado.Id == 2).ToArray();
                    break;
                default:
                    break;
            }

            return PartialView("ListadoTablaPV", listadoAntecentes);
        }
    }
}