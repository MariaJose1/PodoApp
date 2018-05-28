using Angle.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class SubirArchivoController : Controller
    {
        // GET: SubirArchivo
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        // POST: SubirArchivo
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            SubirArchivosModel modelo = new SubirArchivosModel();
            if (file != null)
            {
            
                String ruta = Server.MapPath("~/Temp/");
                ruta += file.FileName;
                modelo.SubirArchivo(ruta, file);
                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;

            }

            return View();
        }

    }
}