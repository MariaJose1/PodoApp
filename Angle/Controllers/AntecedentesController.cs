using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}