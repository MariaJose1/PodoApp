using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormPrimeraVisita
    {
        public Guid IdPaciente { get; set; }

        // Primera Visita

        [Required()]
        public Guid IdPrimeraVisita { get; set; }

        [DisplayName("Peso")]
        public double? Peso { get; set; }

        [DisplayName("Altura")]
        public double? Altura { get; set; }

        [DisplayName("Actividad deportiva que realiza")]
        public string ActividadDeportiva { get; set; }

        [DisplayName("Diabetes")]
        public bool Diabetes { get; set; }

        [DisplayName("Alergias")]
        public bool Alergias { get; set; }

        [DisplayName("Tipo de alergia")]
        public string TipoAlergia { get; set; }

        [DisplayName("Motivo Primera Consulta")]
        public string MotivoPrimeraConsulta { get; set; }

        [DisplayName("¿Hay dolor?")]
        public bool HayDolor { get; set; }

        [DisplayName("Zona del dolor")]
        public string ZonaDolor { get; set; }

        [DisplayName("Tipo de dolor")]
        public string TipoDolor { get; set; }

        [DisplayName("Fecha primera consulta")]
        public DateTime? FechaPrimeraConsulta { get; set; }

        // Calzado Habitual

        public Guid? IdCalzado { get; set; }

        [DisplayName("Deportivos")]
        public bool Deportivos { get; set; }

        [DisplayName("Vestir")]
        public bool Vestir { get; set; }

        [DisplayName("Sandalias")]
        public bool Sandalias { get; set; }

        [DisplayName("Botines")]
        public bool Botines { get; set; }

        [DisplayName("Tacones")]
        public bool Tacones { get; set; }

        // podologo
        
        public Guid? IdPodologo { get; set; }

        public string IdTitulo { get; set; }

        public string Email { get; set; }



        public static FormPrimeraVisita Rellenar (primeraVisita visita)
        {
            calzadoHabitual calzado = visita.calzadoHabitual;
            podologo podologo = visita.podologo;

            FormPrimeraVisita res = new FormPrimeraVisita();
            res.IdPrimeraVisita = visita.idPrimeraVisita;
            res.Peso = visita.peso;
            res.Altura = visita.talla;
            res.ActividadDeportiva = visita.actividadDeportiva;
            res.Diabetes = visita.diabetes;
            res.Alergias = visita.alergias;
            res.TipoAlergia = visita.tipoAlergias;
            res.MotivoPrimeraConsulta = visita.motivoPrimeraConsulta;
            res.HayDolor = visita.hayDolor;
            res.TipoDolor = visita.dolorTipo;
            res.FechaPrimeraConsulta = visita.fechaPrimeraConsulta;

            if (calzado != null)
            {
                res.IdCalzado = visita.id_calzado_habitual;
                res.Deportivos = calzado.deportivos;
                res.Vestir = calzado.vestir;
                res.Sandalias = calzado.sandalias;
                res.Botines = calzado.botines;
                res.Tacones = calzado.tacones;
            }

            /*return new FormPrimeraVisita
            {
                res

                // podologo
                //IdPodologo = visita.id_podologo,
                //IdTitulo = podologo.idTitulo,
                //Email = podologo.email

            };*/
            return res;
        }


        public void InsertarEn(podologiaEntities podo, primeraVisita visita)
        {
            visita = podo.primeraVisita.Where(p => p.idPrimeraVisita == this.IdPrimeraVisita).FirstOrDefault();

            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoIdCalzado = Guid.NewGuid();
                    var nuevoIdPodologo = Guid.NewGuid();
                    var nuevoIdPrimeraVisita = Guid.NewGuid();

                    int retCalzado = podo.Database.ExecuteSqlCommand(
                       @"INSERT INTO calzadoHabitual(
                            [idCalzado],
                            [deportivos],
                            [vestir],
                            [sandalias],
                            [botines],
                            [tacones]
                            ) VALUES (
                            @p0, @p1, @p2, @p3, @p4, @p5
                            )",
                       nuevoIdCalzado,
                       this.Deportivos,
                       this.Vestir,
                       this.Sandalias,
                       this.Botines,
                       this.Tacones
                       );
/*
                    int retPodologo = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO podologo(
                            [idPodologo],
                            [idTitulo],
                            [email]
                            
                            ) VALUES (
                            @p0, @p1, @p2
                            )",
                      nuevoIdPodologo,
                      this.IdTitulo,
                      this.Email
                      );
*/

            /*          int retPrimeraVisita = podo.Database.ExecuteSqlCommand(
                           @"INSERT INTO primeraVisita(
                              [idPrimeraVisita],
                              [peso],
                              [talla],
                              [actividadDeportiva],
                              [diabetes],
                              [alergias],
                              [tipoAlergias],
                              [motivoPrimeraConsulta],
                              [hayDolor],
                              [dolorSitio],
                              [dolorTipo],
                              [fechaPrimeraConsulta],
                              [id_paciente],
                              [id_calzado_habitual]
                              ) VALUES (
                              @p0, @p1,
                              @p2, @p3,
                              @p4, @p5,
                              @p6, @p7,
                              @p8, @p9,
                              @p10, @p11, @p12, @p13           
                             )",
                          nuevoIdPrimeraVisita,
                          this.Peso,
                          this.Altura,
                          this.ActividadDeportiva,
                          this.Diabetes,
                          this.Alergias,
                          this.TipoAlergia,
                          this.MotivoPrimeraConsulta,
                          this.HayDolor,
                          this.ZonaDolor,
                          this.TipoDolor,
                          this.FechaPrimeraConsulta,
                          this.IdPaciente,
                          nuevoIdCalzado
                          );
                        */
                    /*    int retDiagnostico = podo.Database.ExecuteSqlCommand(
                      @"UPDATE diagnostico SET
                            [id_primera_visita] = @p1
                            WHERE idDiagnostico = @p0
                               ",
                      this.IdPrimeraVisita,


                      );
                      */
                    int retPrimeraVisita = podo.Database.ExecuteSqlCommand(
                          @"UPDATE primeraVisita SET
                            [peso]=@p1,
                            [talla]=@p2,
                            [actividadDeportiva]=@p3,
                            [diabetes]=@p4,
                            [alergias]=@p5,
                            [tipoAlergias]=@p6,
                            [motivoPrimeraConsulta]=@p7,
                            [hayDolor]=@p8,
                            [dolorSitio]=@p9,
                            [dolorTipo]=@p10,
                            [fechaPrimeraConsulta]=@p11,
                            [id_paciente]=@p12,
                            [id_calzado_habitual]=@p13
                            WHERE [idPrimeraVisita] = @p0",
                         visita.idPrimeraVisita,
                         this.Peso,
                         this.Altura,
                         this.ActividadDeportiva,
                         this.Diabetes,
                         this.Alergias,
                         this.TipoAlergia,
                         this.MotivoPrimeraConsulta,
                         this.HayDolor,
                         this.ZonaDolor,
                         this.TipoDolor,
                         this.FechaPrimeraConsulta,
                         this.IdPaciente,
                         nuevoIdCalzado
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
            primeraVisita visita = podo.primeraVisita.Where(p => p.idPrimeraVisita == this.IdPrimeraVisita).FirstOrDefault();

            calzadoHabitual calzado = visita.calzadoHabitual;


            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    Debug.Assert(this.IdPrimeraVisita == visita.idPrimeraVisita);
                    Debug.Assert(this.IdCalzado == visita.id_calzado_habitual);

                    var nuevoIdCalzado = Guid.NewGuid();

                    if (visita.id_calzado_habitual == null)
                    {
                        visita.id_calzado_habitual = nuevoIdCalzado;
                    }
                    

                    if (calzado != null)
                    {
                        int retCalzadoHabitual = podo.Database.ExecuteSqlCommand(
                       @"UPDATE [calzadoHabitual] SET
                             [deportivos] = @p1,
                             [vestir] = @p2,
                             [sandalias] = @p3, 
                             [botines] = @p4,
                             [tacones] = @p5
                            WHERE [idCalzado] = @p0",
                       calzado.idCalzado,
                       this.Deportivos,
                       this.Vestir,
                       this.Sandalias,
                       this.Botines,
                       this.Tacones
                       );
                    }
                    else
                    {
                        int retCalzado = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO calzadoHabitual(
                            [idCalzado],
                            [deportivos],
                            [vestir],
                            [sandalias],
                            [botines],
                            [tacones]
                            ) VALUES (
                            @p0, @p1, @p2, @p3, @p4, @p5
                            )",
                      nuevoIdCalzado,
                      this.Deportivos,
                      this.Vestir,
                      this.Sandalias,
                      this.Botines,
                      this.Tacones
                      );
                    }
                   

                   

                    int retPrimeraVisita = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [primeraVisita] SET
                            [peso] = @p1,
                            [talla] = @p2,
                            [actividadDeportiva] = @p3,
                            [diabetes] = @p4,
                            [alergias] = @p5,
                            [tipoAlergias] = @p6,
                            [motivoPrimeraConsulta] = @p7,
                            [hayDolor] = @p8,
                            [dolorSitio] = @p9,
                            [dolorTipo] = @p10,
                            [fechaPrimeraConsulta] = @p11,
                            [id_calzado_habitual]=@p12
                           WHERE [idPrimeraVisita] = @p0",
                        visita.idPrimeraVisita,
                        this.Peso,
                        this.Altura,
                        this.ActividadDeportiva,
                        this.Diabetes,
                        this.Alergias,
                        this.TipoAlergia,
                        this.MotivoPrimeraConsulta,
                        this.HayDolor,
                        this.ZonaDolor,
                        this.TipoDolor,
                        this.FechaPrimeraConsulta,
                                                visita.id_calzado_habitual


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