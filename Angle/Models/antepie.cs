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
    
    public partial class antepie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public antepie()
        {
            this.bipedestacion = new HashSet<bipedestacion>();
        }
    
        public System.Guid idAntepie { get; set; }
        public Nullable<bool> varo { get; set; }
        public Nullable<bool> supinado { get; set; }
        public Nullable<bool> valgo { get; set; }
        public Nullable<bool> neutro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bipedestacion> bipedestacion { get; set; }
    }
}
