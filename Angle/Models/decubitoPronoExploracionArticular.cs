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
    
    public partial class decubitoPronoExploracionArticular
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public decubitoPronoExploracionArticular()
        {
            this.estudioOrtopodologico = new HashSet<estudioOrtopodologico>();
        }
    
        public System.Guid idEArticularPieIzdo { get; set; }
        public System.Guid idEArticularPieDcho { get; set; }
        public Nullable<double> caderaRotInternaIzdo { get; set; }
        public Nullable<double> caderaRotInternaDcho { get; set; }
        public Nullable<double> caderaRotExternaIzdo { get; set; }
        public Nullable<double> caderaRotExternaDcho { get; set; }
        public Nullable<double> torsionFemoralInternaIzdo { get; set; }
        public Nullable<double> torsionFemoralInternaDcho { get; set; }
        public Nullable<double> torsionFemoralExternaIzdo { get; set; }
        public Nullable<double> torsionFemoralExternaDcho { get; set; }
        public Nullable<double> torsionTibialInternaIzdo { get; set; }
        public Nullable<double> torsionTibialInternaDcho { get; set; }
        public Nullable<double> torsionTibialExternaIzdo { get; set; }
        public Nullable<double> torsionTibialExternaDcho { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estudioOrtopodologico> estudioOrtopodologico { get; set; }
    }
}
