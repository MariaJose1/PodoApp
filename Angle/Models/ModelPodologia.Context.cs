﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class podologiaEntities : DbContext
    {
        public podologiaEntities()
            : base("name=podologiaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<anguloFick> anguloFick { get; set; }
        public virtual DbSet<antecedentesFamiliares> antecedentesFamiliares { get; set; }
        public virtual DbSet<antecedentesFisiologicos> antecedentesFisiologicos { get; set; }
        public virtual DbSet<antecedentesPatologicos> antecedentesPatologicos { get; set; }
        public virtual DbSet<antecedentesPodologicos> antecedentesPodologicos { get; set; }
        public virtual DbSet<antepie> antepie { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<bipedestacion> bipedestacion { get; set; }
        public virtual DbSet<calzadoHabitual> calzadoHabitual { get; set; }
        public virtual DbSet<consulta> consulta { get; set; }
        public virtual DbSet<deambulacion> deambulacion { get; set; }
        public virtual DbSet<decubitoPronoExploracionArticular> decubitoPronoExploracionArticular { get; set; }
        public virtual DbSet<decubitoSupinoAntepiePosicion1Radio> decubitoSupinoAntepiePosicion1Radio { get; set; }
        public virtual DbSet<decubitoSupinoExploracionArticular> decubitoSupinoExploracionArticular { get; set; }
        public virtual DbSet<decubitoSupinoExploracionMorfologica> decubitoSupinoExploracionMorfologica { get; set; }
        public virtual DbSet<decubitoSupinoExploracionMuscular> decubitoSupinoExploracionMuscular { get; set; }
        public virtual DbSet<decubitoSupinoPosicionAnguloAntepie> decubitoSupinoPosicionAnguloAntepie { get; set; }
        public virtual DbSet<decubitoSupinoPulsos> decubitoSupinoPulsos { get; set; }
        public virtual DbSet<decubitoSupinoPulsosTipo> decubitoSupinoPulsosTipo { get; set; }
        public virtual DbSet<diagnostico> diagnostico { get; set; }
        public virtual DbSet<estudioOrtopodologico> estudioOrtopodologico { get; set; }
        public virtual DbSet<formulaDigital> formulaDigital { get; set; }
        public virtual DbSet<formulaMetatarsal> formulaMetatarsal { get; set; }
        public virtual DbSet<formulaPodal> formulaPodal { get; set; }
        public virtual DbSet<FPI> FPI { get; set; }
        public virtual DbSet<historialClinico> historialClinico { get; set; }
        public virtual DbSet<materialSoportePlantar> materialSoportePlantar { get; set; }
        public virtual DbSet<paciente> paciente { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<podologo> podologo { get; set; }
        public virtual DbSet<primeraVisita> primeraVisita { get; set; }
        public virtual DbSet<retropie> retropie { get; set; }
        public virtual DbSet<sedestacionExploracionArticular> sedestacionExploracionArticular { get; set; }
        public virtual DbSet<sedestacionExploracionMuscular> sedestacionExploracionMuscular { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipoEstudio> tipoEstudio { get; set; }
        public virtual DbSet<tratamiento> tratamiento { get; set; }
        public virtual DbSet<visionFrontal> visionFrontal { get; set; }
        public virtual DbSet<visionSagital> visionSagital { get; set; }
        public virtual DbSet<pruebasComplementarias> pruebasComplementarias { get; set; }
    }
}
