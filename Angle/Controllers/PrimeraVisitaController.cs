using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class PrimeraVisitaController : Controller
    {

        podologiaEntities db = new podologiaEntities();

        // GET: PrimeraVisita
        public ActionResult Index()
        {
            return View();
        }


        // GET: /PrimeraVisita/Create
        public ActionResult Create(Guid idpaciente)
        {
            paciente paciente = db.paciente.Find(idpaciente);
            FormPrimeraVisita form = new FormPrimeraVisita();

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
        public ActionResult Create(FormPrimeraVisita form)
        {
            if (ModelState.IsValid)
            {
                primeraVisita visita = db.primeraVisita.Find(form.IdPaciente);
                form.InsertarEn(db, visita);
                return RedirectToAction("Create");
            }
            return View(form);
        }


        // GET: /PrimeraVisita/Edit
        public ActionResult Edit(Guid? idvisita)
        {
            if (idvisita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            primeraVisita visita = db.primeraVisita.Find(idvisita);

            if (idvisita == null)
            {
                return HttpNotFound();
            }
            FormPrimeraVisita form = FormPrimeraVisita.Rellenar(visita);

            return View(form);
        }

        // POST: /PrimeraVisita/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormPrimeraVisita form)
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