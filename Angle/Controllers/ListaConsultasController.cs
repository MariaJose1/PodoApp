using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class ListaConsultasController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: ListaConsultas
        public ActionResult Index(Guid idpaciente)
        {

            ViewBag.paciente = new SelectList(db.paciente.ToList().Where(i => i.idPaciente == idpaciente), "idPaciente", "idPaciente");

            return View(db.consulta.Where(p=>p.id_paciente == idpaciente).ToList());
        }

        
    }
}