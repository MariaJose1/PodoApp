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
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(FormAntecedentes form)
        {
            if (ModelState.IsValid)
            {
                form.InsertarEn(db);
                return RedirectToAction("Create");
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
        public ActionResult Edit(Guid? idhistorial)
        {
            if (idhistorial == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            historialClinico historial = db.historialClinico.Find(idhistorial);

            if (historial == null)
            {
                return HttpNotFound();
            }
            FormAntecedentes form = FormAntecedentes.Rellenar(historial);

            return View(form);
        }

        // POST: /Paciente/Edit
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


        // GET: /Paciente/Details
        public ActionResult Details(Guid? idhistorial)
        {
            if (idhistorial == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            historialClinico historial = db.historialClinico.Find(idhistorial);

            if (historial == null)
            {
                return HttpNotFound();
            }

            FormAntecedentes form = FormAntecedentes.Rellenar(historial);

            return View(form);
        }


        // POST: /Paciente/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(FormAntecedentes form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = System.Data.Entity.EntityState.Detached;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(form);
        }
        
    }


}
