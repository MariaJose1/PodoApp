using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class PacienteController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: /Paciente/Index
        public ActionResult Index() //luego pasar id paciente para buscarlo y leer los datos
        {
            FormPaciente form = (FormPaciente)TempData["paciente"];
            return View(form); //vista de paciente
        }

        // GET: /Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(FormPaciente form)
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


        // GET: /Paciente/Edit
        public ActionResult Edit(Guid? idpaciente)
        {
            if (idpaciente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(idpaciente);

            if (paciente == null)
            {
                return HttpNotFound();
            }
            FormPaciente form = FormPaciente.Rellenar(paciente);

            return View(form);
        }

        // POST: /Paciente/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormPaciente form)
        {
            if (ModelState.IsValid)
            {
                form.GuardarEn(db);
                return RedirectToAction("Create");
            }
            return View(form);
        }


        // GET: /Paciente/Details
        public ActionResult Details(Guid? idpaciente)
        {
            if (idpaciente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(idpaciente);

            if (paciente == null)
            {
                return HttpNotFound();
            }

            FormPaciente form = FormPaciente.Rellenar(paciente);

            return View(form);
        }


        // POST: /Paciente/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(FormPaciente form)
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