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
    
    public partial class calzadoHabitual
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calzadoHabitual()
        {
            this.primeraVisita = new HashSet<primeraVisita>();
        }
    
        public System.Guid idCalzado { get; set; }
        public Nullable<bool> deportivos { get; set; }
        public Nullable<bool> vestir { get; set; }
        public Nullable<bool> sandalias { get; set; }
        public Nullable<bool> botines { get; set; }
        public Nullable<bool> tacones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<primeraVisita> primeraVisita { get; set; }
    }
}
