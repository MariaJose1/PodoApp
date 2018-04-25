using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormPaciente
    {
        [Required()]
        public Guid idPaciente { get; set; }

        [DisplayName("Medicación habitual")]
        [Required()]
        public string medicacionHabitual { get; set; }
        [DisplayName("Observación")]
        public string observacion { get; set; }
        [DisplayName("Número Historia Clínica")] //CREO QUE SOBRA
        public int numeroHistoriaClinica { get; set; }

        [DisplayName("Podólogo que realiza la consulta")]
        public Guid? idPodologo { get; set; }

        [DisplayName("Persona que va a la consulta")]
        public Guid? idPersona { get; set; }

        [DisplayName("Historia Clínica de la persona")]
        public Guid? idHistorialClinico { get; set; }


        public static FormPaciente Rellenar(paciente paciente)
        {
            return new FormPaciente
            {
                idPaciente = paciente.idPaciente,
                medicacionHabitual = paciente.medicacionHabitual,
                observacion = paciente.observacion,
                idPodologo = paciente.id_podologo,
                idPersona = paciente.id_persona,
                idHistorialClinico = paciente.id_historial_clinico,
            };
        }

        public void InsertarEn(podologiaEntities podo)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    int ret = podo.Database.ExecuteSqlCommand(
                        @"INSERT INTO paciente(
                            [idPaciente],
                            [medicacionHabitual], 
                            [observacion], 
                            [numeroHistoriaClinica], 
                            [id_podologo],
                            [id_historiaClinico],
                            [id_persona]
                        )VALUES(
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6)",
                        this.idPaciente,
                        this.medicacionHabitual,
                        this.observacion,
                        this.numeroHistoriaClinica,
                        this.idPodologo,
                        this.idHistorialClinico,
                        this.idPersona
                );
                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public void GuardarEn(podologiaEntities podo, paciente paciente)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    Debug.Assert(this.idPaciente == paciente.idPaciente);
                    //claves ajenas también (¿?)
                    Debug.Assert(this.idPersona == paciente.id_persona);
                    Debug.Assert(this.idPodologo == paciente.id_podologo);
                    Debug.Assert(this.idHistorialClinico == paciente.id_historial_clinico);

                    int ret = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [paciente] SET
                            [medicacionHabitual] = @p1, 
                            [observacion] = @p2, 
                            [numeroHistoriaClinica] = @p3, 
                            [id_podologo] = @p4,
                            [id_historiaClinico] = @p5,
                            [id_persona]
                        WHERE [idPaciente] = @p0
                        ",
                            paciente.idPaciente,
                            this.medicacionHabitual,
                            this.observacion,
                            this.numeroHistoriaClinica,
                            this.idPodologo,
                            this.idHistorialClinico,
                            this.idPersona
                        );
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