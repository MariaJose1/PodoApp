using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class AntecedentesController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: Antecedentes
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Antecedentes/Create
        public ActionResult Create(Guid idpaciente)
        {
            paciente paciente = db.paciente.Find(idpaciente);
            FormAntecedentes form = new FormAntecedentes();

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
        public ActionResult Create(FormAntecedentes form)
        {
            if (ModelState.IsValid)
            {
                paciente paciente = db.paciente.Find(form.IdPaciente);
                form.InsertarEn(db, paciente);
                return RedirectToAction("Edit");
            }
            return View(form);
        }


        public ActionResult Error_404()
        {
            return View();
        }
        public ActionResult Lock()
        {
            return View();
        }

        // GET: /Antecedentes/Edit

        public ActionResult Edit(Guid? idpaciente)
        {
            if (idpaciente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(idpaciente);
            historialClinico historial = paciente.historialClinico;

            if (historial == null)
            {
                return HttpNotFound();
            }
            FormAntecedentes form = FormAntecedentes.Rellenar(historial);

            return View(form);
        }

        // POST: /Antecedentes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormAntecedentes form)
        {
            if (ModelState.IsValid)
            {
                form.GuardarEn(db);
                return RedirectToAction("Create");
            }
            return View(form);
        }

        
    }


}
