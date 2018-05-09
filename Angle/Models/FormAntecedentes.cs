using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormAntecedentes
    {
        [Required()]
        public Guid IdAPodologicos { get; set; }

        [DisplayName("¿Ha ido al podólogo anteriormente?")]
        [Required()]
        public bool? HaIdoPodologo { get; set; }

        [DisplayName("Antecedentes: ")]
        public string Antecedentes { get; set; }

        [Required()]
        public Guid IdAPatologicos { get; set; }

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

        [Required()]
        public Guid IdAFisiologicos { get; set; }

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

        [Required()]
        public Guid IdAFamiliares { get; set; }

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



        public static FormAntecedentes Rellenar (antecedentesFamiliares familiares, antecedentesFisiologicos fisiologicos,
            antecedentesPatologicos patologicos, antecedentesPodologicos podologicos)
        {
            return new FormAntecedentes
            {
                // podológicos
                IdAPodologicos = podologicos.idAPodologicos,
                HaIdoPodologo = podologicos.haidoPodologo,
                Antecedentes = podologicos.antecedentes,

                // patológicos
                IdAPatologicos = patologicos.idAPatologico,
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
                IdAFisiologicos = fisiologicos.idAFisiologico,
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
                IdAFamiliares = familiares.idAFamiliares,
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
                MetaVarus = familiares.metaVarus,


            };
        }

        public void InsertarEn (podologiaEntities podo)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoId = Guid.NewGuid();

                    int retPodologicos = podo.Database.ExecuteSqlCommand(
                        @"INSERT INTO antecedentesPodologicos(
                            [idAPodologicos],
                            [haIdoPodologo],
                            [antecedentes]
                            ) VALUES (
                            @p0, @p1,
                            @p2
                            )",
                        nuevoId,
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
                       nuevoId,
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
                       nuevoId,
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
                      nuevoId,
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