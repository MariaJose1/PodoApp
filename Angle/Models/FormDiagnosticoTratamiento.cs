using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormDiagnosticoTratamiento
    {

        // Diagnostico

        public Guid IdDiagnostico { get; set; }

        [DisplayName("Anotaciones")]
        [Required()]
        public string Anotaciones { get; set; }

        // Tratamiento
        public Guid IdTratamiento { get; set; }

        [DisplayName("Físico")]
        public bool Fisico { get; set; }

        [DisplayName("Ejercicios Propioceptivos")]
        public string EjerciciosPropioceptivos { get; set; }

        [DisplayName("Farmacológico")]
        public bool Farmacologico { get; set; }

        [DisplayName("Quiropodológico")]
        public bool Quiropodologico { get; set; }

        [DisplayName("Ortosis Digital")]
        public bool Ortosis { get; set; }

        [DisplayName("Tipo Ortosis Digital")]
        public string TipoOrtosis { get; set; }

        [DisplayName("Soporte Plantar")]
        public bool SoportePlantar { get; set; }

        [DisplayName("Vendaje Funcional")]
        public bool VendajeFuncional { get; set; }

        [DisplayName("Preventivo")]
        public bool Preventivo { get; set; }

        [DisplayName("Preventivo Observaciones")]
        public string PreventivoObservaciones { get; set; }

        [DisplayName("Calzadoterapia")]
        public bool Calzadoterapia { get; set; }

        [DisplayName("Otros")]
        public bool Otros { get; set; }

        // Material Soporte Plantar

        [DisplayName("TAD")]
        public bool Tad { get; set; }

        [DisplayName("Resinas")]
        public bool Resinas { get; set; }

        [DisplayName("EVA")]
        public bool Eva { get; set; }

        [DisplayName("Propileno")]
        public bool Propileno { get; set; }

        [DisplayName("Componentes")]
        public string Componentes { get; set; }

        [DisplayName("Otros")]
        public string OtrosComentarios { get; set; }



    }
}