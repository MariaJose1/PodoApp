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
    
    public partial class paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paciente()
        {
            this.consulta = new HashSet<consulta>();
            this.primeraVisita = new HashSet<primeraVisita>();
        }
    
        public System.Guid idPaciente { get; set; }
        public string medicacionHabitual { get; set; }
        public string observacion { get; set; }
        public string numeroHistoriaClinica { get; set; }
        public Nullable<System.Guid> id_podologo { get; set; }
        public Nullable<System.Guid> id_historial_clinico { get; set; }
        public Nullable<System.Guid> id_persona { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consulta> consulta { get; set; }
        public virtual persona persona { get; set; }
        public virtual podologo podologo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<primeraVisita> primeraVisita { get; set; }
    }
}
