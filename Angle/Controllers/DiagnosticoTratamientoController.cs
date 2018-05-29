using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class DiagnosticoTratamientoController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: DiagnosticoTratamiento
        public ActionResult Index()
        {
            return View();
        }

        // GET: /DiagnosticoTratamiento/Create
        public ActionResult Create(Guid idpaciente)
        {
            paciente paciente = db.paciente.Find(idpaciente);
            FormDiagnosticoTratamiento form = new FormDiagnosticoTratamiento();

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
        public ActionResult Create(FormDiagnosticoTratamiento form)
        {
            if (ModelState.IsValid)
            {
                paciente paciente = db.paciente.Find(form.IdPaciente);
                form.InsertarEn(db, paciente);
                return RedirectToAction("Index", "ListaPacientes");
            }
            return View(form);
        }

        // GET: /DiagnosticoTratamiento/Edit
        public ActionResult Edit(Guid? iddiagnostico)
        {
            if (iddiagnostico == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            diagnostico diagnostico = db.diagnostico.Find(iddiagnostico);

            if (iddiagnostico == null)
            {
                return HttpNotFound();
            }
            FormDiagnosticoTratamiento form = FormDiagnosticoTratamiento.Rellenar(diagnostico);

            return View(form);
        }

        // POST: /DiagnosticoTratamiento/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormDiagnosticoTratamiento form)
        {
            if (ModelState.IsValid)
            {
                form.GuardarEn(db);
                return RedirectToAction("Index", "ListaPacientes");
            }
            return View(form);
        }



    }
}