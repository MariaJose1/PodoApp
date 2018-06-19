using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class ConsultaController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Consulta/Create
        public ActionResult Create(Guid idpaciente)
        {
            List<podologo> podologos = db.podologo.ToList();

            paciente paciente = db.paciente.Find(idpaciente);
            FormConsulta form = new FormConsulta();

            if (paciente != null)
            {
                form.IdPaciente = idpaciente;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            List<Guid?> lista = podologos.Select(i => i.id_persona).ToList();

            ViewBag.Podologos = new SelectList(db.persona.ToList().Where(i => lista.Contains(i.idPersona)), "nombre", "idPersona");

            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(FormConsulta form)
        {
            if (ModelState.IsValid)
            {
                paciente paciente = db.paciente.Find(form.IdPaciente);
                form.InsertarEn(db, paciente);
                return RedirectToAction("Index", "ListaPacientes");
            }
            return View(form);
        }

        // GET: /Consulta/Edit
        public ActionResult Edit(Guid? idpaciente)
        {
            List<podologo> podologos = db.podologo.ToList();

            if (idpaciente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(idpaciente);
            consulta consulta = paciente.consulta.FirstOrDefault();

            if (consulta == null)
            {
                return HttpNotFound();
            }
            FormConsulta form = FormConsulta.Rellenar(consulta);
            List<Guid?> lista = podologos.Select(i => i.id_persona).ToList();

            ViewBag.Podologos = new SelectList(db.persona.ToList().Where(i => lista.Contains(i.idPersona)), "nombre", "idPersona");

            return View(form);
        }

        // POST: /Consulta/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormConsulta form)
        {
            if (ModelState.IsValid)
            {
                form.GuardarEn(db);
                return RedirectToAction("Index", "ListaPacientes");
            }
            return View(form);
        }


        // GET: /Consulta/Select
        public ActionResult Select(Guid idpaciente)
        {
            paciente paciente = db.paciente.Find(idpaciente);
            FormConsulta form = new FormConsulta();

            if (paciente != null)
            {
                form.IdPaciente = idpaciente;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Select(FormConsulta form)
        {
            if (ModelState.IsValid)
            {
                paciente paciente = db.paciente.Find(form.IdPaciente);
                form.Seleccionar(db, paciente);
                return RedirectToAction("Select", "Consulta");
            }
            return View(form);
        }

    }
}