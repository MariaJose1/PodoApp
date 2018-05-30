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
            consulta consulta = db.consulta.Find(idpaciente);
            return View(consulta);
        }

        // POST: ListaConsultas
        public ActionResult Index(FormConsulta cons)
        {
            consulta consulta = db.consulta.Find(cons.IdPaciente);
            return View(cons);
        }
    }
}