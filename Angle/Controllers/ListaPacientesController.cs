using Angle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class ListaPacientesController : Controller
    {
        podologiaEntities db = new podologiaEntities();

        // GET: Tabla
        public ActionResult Index()
        {
            return View(db.paciente.ToList());
        }
    }
}