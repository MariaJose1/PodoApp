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
    
    public partial class historialClinico
    {
        public System.Guid idHistorialClinico { get; set; }
        public string numeroHistorialClinico { get; set; }
        public Nullable<System.Guid> id_ant_podologicos { get; set; }
        public Nullable<System.Guid> id_ant_patologicos { get; set; }
        public Nullable<System.Guid> id_ant_fisiologicos { get; set; }
        public Nullable<System.Guid> id_ant_familiares { get; set; }
        public Nullable<System.Guid> id_estudio { get; set; }
    
        public virtual antecedentesFamiliares antecedentesFamiliares { get; set; }
        public virtual antecedentesFisiologicos antecedentesFisiologicos { get; set; }
        public virtual antecedentesPatologicos antecedentesPatologicos { get; set; }
        public virtual antecedentesPodologicos antecedentesPodologicos { get; set; }
    }
}
