using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class SubirArchivosModel
    {
        public String Confirmacion { get; set; }
        public Exception error { get; set; }
        public void SubirArchivo(String ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                this.Confirmacion = "Fichero Guardado";
               
            }
            catch(Exception ex)
            {
                this.error = ex;
            }
        }
        [DisplayName("Pedigrafía")]
        public byte[] Pedigrafia { get; set; }

        [DisplayName("Rayos X")]
        public byte[] RayosX { get; set; }

        [DisplayName("Análisis Sanguíneo")]
        public byte[] AnalisisSanguineo { get; set; }

        [DisplayName("Cultivo")]
        public byte[] Cultivo { get; set; }

        [DisplayName("Doppler")]
        public byte[] Doppler { get; set; }

        [DisplayName("Ecografía")]
        public byte[] Ecografia { get; set; }

        [DisplayName("Fotos")]
        public byte[] Fotos { get; set; }

        [DisplayName("Fecha de la prueba")]
        public DateTime Fecha { get; set; }

        
    }
}