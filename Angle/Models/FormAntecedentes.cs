using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormAntecedentes
    {
        // Historial Clinico

        [Required()]
        public Guid IdHistorialClinico { get; set; }

        [DisplayName("Introduzca el número del historial clínico:")]
        [Required()]
        public string NumeroHistorialClinico { get; set; }

        public Guid? IdAntPodologicos { get; set; }
        public Guid? IdAntFisiologicos { get; set; }
        public Guid? IdAntPatologicos { get; set; }
        public Guid? IdAntFamiliares { get; set; }

        // ANTECEDENTES PODOLÓGICOS

        [DisplayName("¿Ha ido al podólogo anteriormente?")]
        [Required()]
        public bool? HaIdoPodologo { get; set; }

        [DisplayName("Antecedentes: ")]
        public string Antecedentes { get; set; }

        // ANTECEDENTES PATOLÓGICOS

        [DisplayName("Patología previa: ")]
        public string PatologiaPrevia { get; set; }

        [DisplayName("Enfermedad infantil: ")]
        public string EnfermedadInfantil { get; set; }

        [DisplayName("Antecedentes traumáticos")]
        public string AntecedentesTraumaticos { get; set; }

        [DisplayName("Bursistis")]
        public bool? Bursitis { get; set; }

        [DisplayName("Capsulitis")]
        public bool? Capsulitis { get; set; }

        [DisplayName("Enfermedad reumática")]
        public bool? EnfermedadReumatica { get; set; }

        [DisplayName("Tipo enfermedad reumática:")]
        public string TipoEnfermedadReumatica { get; set; }

        [DisplayName("Ciática")]
        public bool? Ciatica { get; set; }

        [DisplayName("Otros")]
        public string Otros { get; set; }

        [DisplayName("Distensión")]
        public bool? Distension { get; set; }

        [DisplayName("Esguince")]
        public bool? Esguince { get; set; }

        [DisplayName("Tendinitis")]
        public bool? Tendinitis { get; set; }

        [DisplayName("Contracturas")]
        public bool? Contracturas { get; set; }

        [DisplayName("Luxación")]
        public bool? Luxacion { get; set; }

        [DisplayName("Subluxación")]
        public bool? Subluxacion { get; set; }

        [DisplayName("Fisura")]
        public bool? Fisura { get; set; }

        [DisplayName("Fractura")]
        public bool? Fractura { get; set; }

        // ANTECEDENTES FISIOLÓGICOS

        [DisplayName("Andador")]
        public bool? Andador { get; set; }

        [DisplayName("Tacata")]
        public bool? Tacata { get; set; }

        [DisplayName("Inicio Deambulación:")]
        public int? InicioDeambulacion { get; set; }

        [DisplayName("Hábitos Posturales")]
        public string HabitosPosturales { get; set; }

        [DisplayName("Cambios Ponderales")]
        public int? CambiosPonderales { get; set; }

        [DisplayName("Zurdo")]
        public bool? Zurdo { get; set; }

        [DisplayName("Diestro")]
        public bool? Diestro { get; set; }

        [DisplayName("Ambidiestro")]
        public bool? Ambidiestro { get; set; }

        [DisplayName("Parto de cabeza")]
        public bool? PartoCabeza { get; set; }

        [DisplayName("Parto de nalgas")]
        public bool? PartoNalgas { get; set; }

        // ANTECEDENTES FAMILIARES

        [DisplayName("Dismetrías")]
        public bool? Dismetrias { get; set; }

        [DisplayName("Escoliosis")]
        public bool? Escoliosis { get; set; }

        [DisplayName("Tibias Varas")]
        public bool? TibiasVaras { get; set; }

        [DisplayName("Pies planos")]
        public bool? PiesPlanos { get; set; }

        [DisplayName("Pies cavos")]
        public bool? PiesCavos { get; set; }

        [DisplayName("Pies valgos")]
        public bool? PiesValgos { get; set; }

        [DisplayName("Pies zambos")]
        public bool? PiesZambos { get; set; }

        [DisplayName("Hallus Valgus")]
        public bool? HallusValgus { get; set; }

        [DisplayName("Dedos garra")]
        public bool? DedosGarra { get; set; }

        [DisplayName("Genu Varo")]
        public bool? GenuVaro { get; set; }

        [DisplayName("Genu Valgo")]
        public bool? GenuValgo { get; set; }

        [DisplayName("Meta Aductus")]
        public bool? MetaAductus { get; set; }

        [DisplayName("Meta Varus")]
        public bool? MetaVarus { get; set; }



        public static FormAntecedentes Rellenar (historialClinico historial)
        {
            antecedentesFamiliares familiares = historial.antecedentesFamiliares;
            antecedentesFisiologicos fisiologicos = historial.antecedentesFisiologicos;
            antecedentesPatologicos patologicos = historial.antecedentesPatologicos;
            antecedentesPodologicos podologicos = historial.antecedentesPodologicos;

            return new FormAntecedentes
            {
                // historial
                IdHistorialClinico = historial.idHistorialClinico,
                NumeroHistorialClinico = historial.numeroHistorialClinico,

                // podológicos
                IdAntPodologicos = historial.id_ant_podologicos,
                HaIdoPodologo = podologicos.haidoPodologo,
                Antecedentes = podologicos.antecedentes,
                
                // patológicos
                IdAntPatologicos = historial.id_ant_patologicos,
                PatologiaPrevia = patologicos.patologiaPrevia,
                EnfermedadInfantil = patologicos.enfermedadInfantil,
                AntecedentesTraumaticos = patologicos.antecedentesTraumatico,
                Bursitis = patologicos.bursitis,
                Capsulitis = patologicos.capsulitis,
                EnfermedadReumatica = patologicos.enfermedadReumatica,
                TipoEnfermedadReumatica = patologicos.tipoEnfermedadReumatica,
                Ciatica = patologicos.ciatica,
                Distension = patologicos.distension,
                Esguince = patologicos.esguince,
                Tendinitis = patologicos.tendinitis,
                Contracturas = patologicos.contracturas,
                Luxacion = patologicos.luxacion,
                Subluxacion = patologicos.subluxacion,
                Fisura = patologicos.fisura,
                Fractura = patologicos.fractura,
                Otros = patologicos.otros,
                
                // fisiológicos
                IdAntFisiologicos = historial.id_ant_fisiologicos,
                Andador = fisiologicos.andador,
                Tacata = fisiologicos.tacata,
                InicioDeambulacion = fisiologicos.inicioDeambulacion,
                HabitosPosturales = fisiologicos.habitosPosturales,
                CambiosPonderales = fisiologicos.cambiosPonderales,
                Zurdo = fisiologicos.zurdo,
                Diestro = fisiologicos.diestro,
                Ambidiestro = fisiologicos.ambidiestro,
                PartoCabeza = fisiologicos.partoCabeza,
                PartoNalgas = fisiologicos.partoNalgas,


                // familiares
                IdAntFamiliares = historial.id_ant_familiares,
                Dismetrias = familiares.dismetrias,
                Escoliosis = familiares.escoliosis,
                TibiasVaras = familiares.tibiasVaras,
                PiesPlanos = familiares.piesPlanos,
                PiesCavos = familiares.piesCavos,
                PiesValgos = familiares.piesValgos,
                PiesZambos = familiares.piesZambos,
                HallusValgus = familiares.hallusValgus,
                DedosGarra = familiares.dedosGarra,
                GenuVaro = familiares.genuVaro,
                GenuValgo = familiares.genuValgo,
                MetaAductus = familiares.metaAductus,
                MetaVarus = familiares.metaVarus

                
                
            };
        }

        public void InsertarEn (podologiaEntities podo)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoIdHistorial = Guid.NewGuid();
                    var nuevoIdPodo= Guid.NewGuid();
                    var nuevoIdFam = Guid.NewGuid();
                    var nuevoIdFisio = Guid.NewGuid();
                    var nuevoIdPato = Guid.NewGuid();

                   

                    int retPodologicos = podo.Database.ExecuteSqlCommand(
                        @"INSERT INTO antecedentesPodologicos(
                            [idAPodologicos],
                            [haidoPodologo],
                            [antecedentes]
                            ) VALUES (
                            @p0, @p1,
                            @p2
                            )",
                        nuevoIdPodo,
                        this.HaIdoPodologo,
                        this.Antecedentes
                        );

                    int retPatologicos = podo.Database.ExecuteSqlCommand(
                       @"INSERT INTO antecedentesPatologicos(
                            [idAPatologico],
                            [patologiaPrevia],
                            [enfermedadInfantil],
                            [antecedentesTraumatico],
                            [bursitis],
                            [capsulitis],
                            [enfermedadReumatica],
                            [tipoEnfermedadReumatica],
                            [ciatica],
                            [otros],
                            [distension],
                            [esguince],
                            [tendinitis],
                            [contracturas],
                            [luxacion],
                            [subluxacion],
                            [fisura],
                            [fractura]
                            ) VALUES (
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7,
                            @p8, @p9,
                            @p10, @p11,
                            @p12, @p13,
                            @p14, @p15,
                            @p16, @p17                            
                           )",
                       nuevoIdPato,
                       this.PatologiaPrevia,
                       this.EnfermedadInfantil,
                       this.AntecedentesTraumaticos,
                       this.Bursitis,
                       this.Capsulitis,
                       this.EnfermedadReumatica,
                       this.TipoEnfermedadReumatica,
                       this.Ciatica,
                       this.Otros,
                       this.Distension,
                       this.Esguince,
                       this.Tendinitis,
                       this.Contracturas,
                       this.Luxacion,
                       this.Subluxacion,
                       this.Fisura,
                       this.Fractura
                       );

                    int retFamiliares = podo.Database.ExecuteSqlCommand(
                       @"INSERT INTO antecedentesFamiliares(
                            [idAFamiliares],
                            [dismetrias],
                            [escoliosis],
                            [tibiasVaras],
                            [piesPlanos],
                            [piesCavos],
                            [piesValgos],
                            [piesZambos],
                            [hallusValgus],
                            [dedosGarra],
                            [otros],
                            [genuVaro],
                            [genuValgo],
                            [metaAductus],
                            [metaVarus]
                           ) VALUES (
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7,
                            @p8, @p9,
                            @p10, @p11,
                            @p12, @p13,
                            @p14
                            )",
                       nuevoIdFam,
                       this.Dismetrias,
                       this.Escoliosis,
                       this.TibiasVaras,
                       this.PiesPlanos,
                       this.PiesCavos,
                       this.PiesValgos,
                       this.PiesZambos,
                       this.HallusValgus,
                       this.DedosGarra,
                       null,
                       this.GenuVaro,
                       this.GenuValgo,
                       this.MetaAductus,
                       this.MetaVarus
                       );

                    int retFisiologicos = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO antecedentesFisiologicos(
                            [idAFisiologico],
                            [andador],
                            [tacata],
                            [inicioDeambulacion],
                            [habitosPosturales],
                            [cambiosPonderales],
                            [zurdo],
                            [diestro],
                            [ambidiestro],
                            [otros],
                            [partoCabeza],
                            [partoNalgas]
                           ) VALUES (
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7,
                            @p8, @p9,
                            @p10, @p11
                           )",
                      nuevoIdFisio,
                      this.Andador,
                      this.Tacata,
                      this.InicioDeambulacion,
                      this.HabitosPosturales,
                      this.CambiosPonderales,
                      this.Zurdo,
                      this.Diestro,
                      this.Ambidiestro,
                      null,
                      this.PartoCabeza,
                      this.PartoNalgas
                      );

                    int retHistorial = podo.Database.ExecuteSqlCommand(
                       @"INSERT INTO historialClinico(
                            [idHistorialClinico],
                            [numeroHistorialClinico],
                            [id_ant_podologicos],
                            [id_ant_fisiologicos],
                            [id_ant_familiares],
                            [id_ant_patologicos]
                            ) VALUES (
                            @p0, @p1, @p2,@p3,@p4,@p5
                            )",
                       nuevoIdHistorial,
                       this.NumeroHistorialClinico,
                       nuevoIdPodo,
                       nuevoIdFisio,
                       nuevoIdFam,
                       nuevoIdPato
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
            historialClinico historial = podo.historialClinico.Where(p => p.idHistorialClinico == this.IdHistorialClinico).FirstOrDefault();

            antecedentesFamiliares familiares = historial.antecedentesFamiliares;
            antecedentesFisiologicos fisiologicos = historial.antecedentesFisiologicos;
            antecedentesPatologicos patologicos = historial.antecedentesPatologicos;
            antecedentesPodologicos podologicos = historial.antecedentesPodologicos;

            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    Debug.Assert(this.IdHistorialClinico == historial.idHistorialClinico);
                    Debug.Assert(this.IdAntFamiliares == historial.id_ant_familiares);
                    Debug.Assert(this.IdAntFisiologicos == historial.id_ant_fisiologicos);
                    Debug.Assert(this.IdAntPatologicos == historial.id_ant_patologicos);
                    Debug.Assert(this.IdAntPodologicos == historial.id_ant_podologicos);

                    int retPodologicos = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [antecedentesPodologicos] SET
                             [haidoPodologo] = @p1,
                             [antecedentes] = @p2
                            WHERE [idAPodologicos] = @p0",
                        podologicos.idAPodologicos,
                        this.HaIdoPodologo,
                        this.Antecedentes
                        );

                    int retFamiliares = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [antecedentesFamiliares] SET
                            [dismetrias] = @p1,
                            [escoliosis] = @p2,
                            [tibiasVaras] = @p3,
                            [piesPlanos] = @p4,
                            [piesCavos] = @p5,
                            [piesValgos] = @p6,
                            [piesZambos] = @p7,
                            [hallusValgus] = @p8,
                            [dedosGarra] = @p9,
                            [otros] = @p10,
                            [genuVaro] = @p11,
                            [genuValgo] = @p12,
                            [metaAductus] = @p13,
                            [metaVarus] = @p14
                           WHERE [idAFamiliares] = @p0",
                        familiares.idAFamiliares,
                        this.Dismetrias,
                        this.Escoliosis,
                        this.TibiasVaras,
                        this.PiesPlanos,
                        this.PiesCavos,
                        this.PiesValgos,
                        this.PiesZambos,
                        this.HallusValgus,
                        this.DedosGarra,
                        null,
                        this.GenuVaro,
                        this.GenuValgo,
                        this.MetaAductus,
                        this.MetaVarus
                        );

                    int retFisiologicos = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [antecedentesFisiologicos] SET
                            [andador] = @p1,
                            [tacata] = @p2,
                            [inicioDeambulacion] = @p3,
                            [habitosPosturales] = @p4,
                            [cambiosPonderales] = @p5,
                            [zurdo] = @p6,
                            [diestro] = @p7,
                            [ambidiestro] = @p8,
                            [otros] = @p9,
                            [partoCabeza] = @p10,
                            [partoNalgas] = @p11
                           WHERE [idAFisiologico] = @p0",
                        fisiologicos.idAFisiologico,
                        this.Andador,
                        this.Tacata,
                        this.InicioDeambulacion,
                        this.HabitosPosturales,
                        this.CambiosPonderales,
                        this.Zurdo,
                        this.Diestro,
                        this.Ambidiestro,
                        null,
                        this.PartoCabeza,
                        this.PartoNalgas
                        );


                    int retPatologicos = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [antecedentesPatologicos] SET
                            [patologiaPrevia] = @p1,
                            [enfermedadInfantil] = @p2,
                            [antecedentesTraumatico] = @p3,
                            [bursitis] = @p4,
                            [capsulitis] = @p5,
                            [enfermedadReumatica] = @p6,
                            [tipoEnfermedadReumatica] = @p7,
                            [ciatica] = @p8,
                            [otros] = @p9,
                            [distension] = @p10,
                            [esguince] = @p11,
                            [tendinitis] = @p12,
                            [contracturas] = @p13,
                            [luxacion] = @p14,
                            [subluxacion] = @p15,
                            [fisura] = @p16,
                            [fractura] = @p17
                          WHERE [idAPatologico] = @p0",
                        patologicos.idAPatologico,
                        this.PatologiaPrevia,
                        this.EnfermedadInfantil,
                        this.AntecedentesTraumaticos,
                        this.Bursitis,
                        this.Capsulitis,
                        this.EnfermedadReumatica,
                        this.TipoEnfermedadReumatica,
                        this.Ciatica,
                        this.Otros,
                        this.Distension,
                        this.Esguince,
                        this.Tendinitis,
                        this.Contracturas,
                        this.Luxacion,
                        this.Subluxacion,
                        this.Fisura,
                        this.Fractura
                        );

                    int retHistorial = podo.Database.ExecuteSqlCommand(
                     @"UPDATE historialClinico SET
                            [numeroHistorialClinico] = @p1,
                            [id_ant_podologicos] = @p2,
                            [id_ant_fisiologicos] = @p3,
                            [id_ant_familiares] = @p4,
                            [id_ant_patologicos] = @p5
                         WHERE [idHistorialClinico] = @p0,
                            ",
                     historial.idHistorialClinico,
                     this.NumeroHistorialClinico,
                     this.IdAntPodologicos,
                     this.IdAntFisiologicos,           
                     this.IdAntFamiliares,
                     this.IdAntPatologicos
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