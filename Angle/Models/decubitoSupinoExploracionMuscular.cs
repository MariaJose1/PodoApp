//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Angle.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class decubitoSupinoExploracionMuscular
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public decubitoSupinoExploracionMuscular()
        {
            this.estudioOrtopodologico = new HashSet<estudioOrtopodologico>();
        }
    
        public System.Guid idEMuscularPieIzdo { get; set; }
        public System.Guid idEMuscularPieDcho { get; set; }
        public string aductoresCaderaIzdo { get; set; }
        public string aductoresCaderaDcho { get; set; }
        public string cudricepsFemoralIzdo { get; set; }
        public string cudricepsFemoralDcho { get; set; }
        public string isquiotibialesIzdo { get; set; }
        public string isquiotibialesDcho { get; set; }
        public string tibialPosteriorIzdo { get; set; }
        public string tibialPosteriorDcho { get; set; }
        public string flexProp1Izdo { get; set; }
        public string flexProp1Dcho { get; set; }
        public string plcYpplIzdo { get; set; }
        public string plcYpplDcho { get; set; }
        public string tibialAnterioryExteriorIzdo { get; set; }
        public string tibialAnterioryExteriorDcho { get; set; }
        public string extComunDedosIzdo { get; set; }
        public string extComunDedosDcho { get; set; }
        public string musculosFlexoresDorsalesIzdo { get; set; }
        public string musculosFlexoresDorsalesDcho { get; set; }
        public string musculosFlexoresPlantaresIzdo { get; set; }
        public string musculosFlexoresPlantaresDcho { get; set; }
        public string musculosPronatoriosIzdo { get; set; }
        public string musculosPronatoriosDcho { get; set; }
        public string musculosSemipronatoriosIzdo { get; set; }
        public string musculosSemipronatoriosDcho { get; set; }
        public bool simetriaIzdo { get; set; }
        public bool simetriaDcho { get; set; }
        public bool asimetriaIzdo { get; set; }
        public bool asimetriaDcho { get; set; }
        public string otrosIzdo { get; set; }
        public string otrosDcho { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estudioOrtopodologico> estudioOrtopodologico { get; set; }
    }
}
