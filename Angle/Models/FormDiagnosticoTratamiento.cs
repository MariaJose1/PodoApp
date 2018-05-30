using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormDiagnosticoTratamiento
    {

        public Guid IdPaciente { get; set; }

        // Diagnostico

        public Guid? IdDiagnostico { get; set; }

        [DisplayName("Anotaciones")]
        [Required()]
        public string Anotaciones { get; set; }

        // Tratamiento
        public Guid? IdTratamiento { get; set; }

        [DisplayName("Físico")]
        public bool Fisico { get; set; }

        [DisplayName("Ejercicios Propioceptivos")]
        public string EjerciciosPropioceptivos { get; set; }

        [DisplayName("Farmacológico")]
        public bool Farmacologico { get; set; }

        [DisplayName("Quiropodológico")]
        public bool Quiropodologico { get; set; }

        [DisplayName("Ortosis Digital")]
        public bool Ortosis { get; set; }

        [DisplayName("Tipo Ortosis Digital")]
        public string TipoOrtosis { get; set; }

        [DisplayName("Soporte Plantar")]
        public bool SoportePlantar { get; set; }

        [DisplayName("Vendaje Funcional")]
        public bool VendajeFuncional { get; set; }

        [DisplayName("Preventivo")]
        public bool Preventivo { get; set; }

        [DisplayName("Preventivo Observaciones")]
        public string PreventivoObservaciones { get; set; }

        [DisplayName("Calzadoterapia")]
        public bool Calzadoterapia { get; set; }

        [DisplayName("Otros")]
        public string Otros { get; set; }

        // Material Soporte Plantar

        public Guid? IdMaterialSoporte { get; set; }

        [DisplayName("TAD")]
        public bool Tad { get; set; }

        [DisplayName("Resinas")]
        public bool Resinas { get; set; }

        [DisplayName("EVA")]
        public bool Eva { get; set; }

        [DisplayName("Propileno")]
        public bool Propileno { get; set; }

        [DisplayName("Componentes")]
        public string Componentes { get; set; }

        [DisplayName("Otros")]
        public string OtrosComentarios { get; set; }



        public static FormDiagnosticoTratamiento Rellenar(diagnostico diagnostico)
        {
            tratamiento tratamiento = diagnostico.tratamiento;

            return new FormDiagnosticoTratamiento
            {
                // diagnostico
                IdDiagnostico = diagnostico.idDiagnostico,
                Anotaciones = diagnostico.anotaciones,

                // tratamiento
                IdTratamiento = diagnostico.id_tratamiento,
                Fisico = tratamiento.fisico,
                EjerciciosPropioceptivos = tratamiento.ejerciciosPropioceptivos,
                Farmacologico = tratamiento.farmacologico,
                Quiropodologico = tratamiento.quiropodologico,
                Ortosis = tratamiento.ortosisDigital,
                TipoOrtosis = tratamiento.ortosisDigitalTipo,
                SoportePlantar = tratamiento.soportePlantar,
                VendajeFuncional = tratamiento.vendajeFuncional,
                Preventivo = tratamiento.preventivo,
                PreventivoObservaciones = tratamiento.preventivoObservacion,
                Calzadoterapia = tratamiento.calzadoterapia,
                Otros = tratamiento.otros,

                // material soporte plantar
                Tad = tratamiento.materialSoportePlantar.FirstOrDefault().TAD,
                Resinas = tratamiento.materialSoportePlantar.FirstOrDefault().resinas,
                Eva = tratamiento.materialSoportePlantar.FirstOrDefault().EVA,
                Propileno = tratamiento.materialSoportePlantar.FirstOrDefault().propileno,
                Componentes = tratamiento.materialSoportePlantar.FirstOrDefault().componentes,
                OtrosComentarios = tratamiento.materialSoportePlantar.FirstOrDefault().otros


            };

        }

        public void InsertarEn(podologiaEntities podo, paciente paciente)
        {
            primeraVisita visita = paciente.primeraVisita.FirstOrDefault();
            

            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoIdDiagnostico = Guid.NewGuid();
                    var nuevoIdTratamiento = Guid.NewGuid();
                    var nuevoIdMaterial = Guid.NewGuid();


                    int retTratamiento = podo.Database.ExecuteSqlCommand(
                       @"INSERT INTO tratamiento(
                            [idTratamiento],
                            [fisico],
                            [ejerciciosPropioceptivos],
                            [farmacologico],
                            [quiropodologico],
                            [ortosisDigital],
                            [ortosisDigitalTipo],
                            [soportePlantar],
                            [vendajeFuncional],
                            [preventivo],
                            [preventivoObservacion],
                            [calzadoterapia],
                            [otros]
                            ) VALUES (
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7,
                            @p8, @p9,
                            @p10, @p11,
                            @p12                           
                           )",
                       nuevoIdTratamiento,
                       this.Fisico,
                       this.EjerciciosPropioceptivos,
                       this.Farmacologico,
                       this.Quiropodologico,
                       this.Ortosis,
                       this.TipoOrtosis,
                       this.SoportePlantar,
                       this.VendajeFuncional,
                       this.Preventivo,
                       this.PreventivoObservaciones,
                       this.Calzadoterapia,
                       this.Otros

                       );

                    int retMaterial = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO materialSoportePlantar(
                            [idMaterialSoportePlantar],
                            [TAD],
                            [resinas],
                            [EVA],
                            [propileno],
                            [componentes],
                            [otros],
                            [id_tratamiento]
                            ) VALUES (
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7          
                           )",
                      nuevoIdMaterial,
                      this.Tad,
                      this.Resinas,
                      this.Eva,
                      this.Propileno,
                      this.Componentes,
                      this.Otros,
                      nuevoIdTratamiento
                      );
                      
                    int retDiagnostico = podo.Database.ExecuteSqlCommand(
                        @"INSERT INTO diagnostico(
                            [idDiagnostico],
                            [anotaciones],
                            [id_primera_visita],
                            [id_tratamiento]
                            ) VALUES (
                            @p0, @p1, @p2, @p3
                            )",
                        nuevoIdDiagnostico,
                        this.Anotaciones,
                        visita.idPrimeraVisita,
                        nuevoIdTratamiento
                        );

                   

                    tr.Commit();
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public void GuardarEn(podologiaEntities podo)
        {
            diagnostico diagnostico = podo.diagnostico.Where(p => p.idDiagnostico == this.IdDiagnostico).FirstOrDefault();

            tratamiento tratamiento = diagnostico.tratamiento;


            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    Debug.Assert(this.IdDiagnostico == diagnostico.idDiagnostico);
                    Debug.Assert(this.IdTratamiento == diagnostico.id_tratamiento);
                  
                    int retDiagnostico = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [diagnostico] SET
                             [anotaciones] = @p1                             
                            WHERE [idDiagnostico] = @p0",
                        diagnostico.idDiagnostico,
                        this.Anotaciones
                        );

                    int retTratamiento = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [tratamiento] SET
                            [fisico] = @p1,
                            [ejerciciosPropioceptivos] = @p2,
                            [farmacologico] = @p3,
                            [quiropodologico] = @p4,
                            [ortosisDigital] = @p5,
                            [ortosisDigitalTipo] = @p6,
                            [soportePlantar] = @p7,
                            [vendajeFuncional] = @p8,
                            [preventivo] = @p9,
                            [preventivoObservacion] = @p10,
                            [calzadoterapia] = @p11,
                            [otros] = @p12
                           WHERE [idTratamiento] = @p0",
                        tratamiento.idTratamiento,
                        this.Fisico,
                        this.EjerciciosPropioceptivos,
                        this.Farmacologico,
                        this.Quiropodologico,
                        this.Ortosis,
                        this.TipoOrtosis,
                        this.SoportePlantar,
                        this.VendajeFuncional,
                        this.Preventivo,
                        this.PreventivoObservaciones,
                        this.Calzadoterapia,
                        this.Otros
                        );

                    int retMaterial = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [materialSoportePlantar] SET
                            [TAD] = @p1,
                            [resinas] = @p2,
                            [EVA] = @p3,
                            [propileno] = @p4,
                            [componentes] = @p5,
                            [otros] = @p6                            
                           WHERE [idMaterialSoportePlantar] = @p0",
                        tratamiento.materialSoportePlantar.FirstOrDefault().idMaterialSoportePlantar,
                        this.Tad,
                        this.Resinas,
                        this.Eva,
                        this.Propileno,
                        this.Componentes,
                        this.Otros
                        );
                    tr.Commit();
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

    }
}