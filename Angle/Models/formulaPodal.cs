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
    
    public partial class formulaPodal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formulaPodal()
        {
            this.decubitoSupinoExploracionMorfologica = new HashSet<decubitoSupinoExploracionMorfologica>();
        }
    
        public System.Guid idFormulaPodal { get; set; }
        public Nullable<bool> normolineo { get; set; }
        public Nullable<bool> longilineo { get; set; }
        public Nullable<bool> brevilineo { get; set; }
        public string otra { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<decubitoSupinoExploracionMorfologica> decubitoSupinoExploracionMorfologica { get; set; }
    }
}
