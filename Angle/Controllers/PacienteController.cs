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
            return View(db.paciente.ToList()); //vista de paciente
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
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(id);
            persona persona = db.persona.Find(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }
            FormPaciente form = FormPaciente.Rellenar(paciente, persona);

            return View(form);
        }

        // POST: /Paciente/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ([Bind(Include = "idPaciente, medicacionHabitual, observacion, numeroHistoriaClinica")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: /Paciente/Delete
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }


        // POST: /Paciente/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(paciente);
        }


        // GET: /Paciente/Details
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            paciente paciente = db.paciente.Find(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }


        // POST: /Paciente/Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(FormPaciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = System.Data.Entity.EntityState.Detached;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

    }




}