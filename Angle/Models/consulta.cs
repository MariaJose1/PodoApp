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
    
    public partial class consulta
    {
        public System.Guid idConsulta { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.Guid> id_paciente { get; set; }
        public Nullable<System.Guid> id_podologo { get; set; }
    
        public virtual paciente paciente { get; set; }
        public virtual podologo podologo { get; set; }
    }
}