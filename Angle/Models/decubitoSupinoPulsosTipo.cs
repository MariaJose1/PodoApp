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
    
    public partial class decubitoSupinoPulsosTipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public decubitoSupinoPulsosTipo()
        {
            this.decubitoSupinoPulsos = new HashSet<decubitoSupinoPulsos>();
        }
    
        public System.Guid idPulsosTipo { get; set; }
        public bool presente { get; set; }
        public bool ausente { get; set; }
        public string debil { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<decubitoSupinoPulsos> decubitoSupinoPulsos { get; set; }
    }
}
