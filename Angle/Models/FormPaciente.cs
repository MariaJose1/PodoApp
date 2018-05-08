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
        // PACIENTE

        [Required()]
        public Guid idPaciente { get; set; }

        [DisplayName("Medicación habitual")]
        [Required()]
        public string medicacionHabitual { get; set; }

        [DisplayName("Observación")]
        public string observacion { get; set; }

        [DisplayName("Número Historia Clínica")] //CREO QUE SOBRA
        public string numeroHistoriaClinica { get; set; }

        [DisplayName("Podólogo que realiza la consulta")]
        public Guid? idPodologo { get; set; }

        [DisplayName("Persona que va a la consulta")]
        public Guid? idPersona { get; set; }

        [DisplayName("Historia Clínica de la persona")]
        public Guid? idHistorialClinico { get; set; }

        // PERSONA
        [Required()]
        public Guid idPersonaP { get; set; }

        [DisplayName("Nombre")]
        [Required()]
        public string nombre { get; set; }

        [DisplayName("Primer apellido")]
        [Required()]
        public string primerApellido { get; set; }

        [DisplayName("Segundo apellido")]
        public string segundoApellido { get; set; }

        [DisplayName("Fecha nacimiento")]
        [Required()]
        public DateTime? fechaNacimiento { get; set; }

        [DisplayName("Edad")]
        [Required()]
        public int? edad { get; set; }

        [DisplayName("Profesión")]
        public string profesion { get; set; }

        [DisplayName("Dirección")]
        [Required()]
        public string direccion { get; set; }

        [DisplayName("Ciudad")]
        [Required()]
        public string ciudad { get; set; }

        [DisplayName("Provincia")]
        public string provincia { get; set; }

        [DisplayName("País")]
        [Required()]
        public string pais { get; set; }

        [DisplayName("Teléfono")]
        [Required()]
        public string telefono { get; set; }

        [DisplayName("DNI")]
        [Required()]
        public string dni { get; set; }





        public static FormPaciente Rellenar(paciente paciente, persona persona)
        {
            return new FormPaciente
            {
                idPaciente = paciente.idPaciente,
                medicacionHabitual = paciente.medicacionHabitual,
                observacion = paciente.observacion,
                numeroHistoriaClinica = paciente.numeroHistoriaClinica,
                idPodologo = paciente.id_podologo,
                idPersona = paciente.id_persona,
                idHistorialClinico = paciente.id_historial_clinico,
                idPersonaP = persona.idPersona,
                nombre = persona.nombre,
                primerApellido = persona.apellido1,
                segundoApellido = persona.apellido2,
                fechaNacimiento = persona.fechaNacimiento,
                edad = persona.edad,
                profesion = persona.profesion,
                direccion = persona.calle,
                ciudad = persona.ciudad,
                provincia = persona.provincia,
                pais = persona.pais,
                telefono = persona.telefono,
                dni = persona.dni,
            };
        }


        public void InsertarEn(podologiaEntities podo)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoID = Guid.NewGuid();
                    var nuevoID2 = Guid.NewGuid();

                    int ret = podo.Database.ExecuteSqlCommand(
                         @"INSERT INTO persona(
                            [idPersona],
                            [nombre], 
                            [apellido1], 
                            [apellido2], 
                            [fechaNacimiento],
                            [edad],
                            [profesion],
                            [calle],
                            [ciudad], 
                            [provincia], 
                            [pais], 
                            [telefono],
                            [dni]
                        )   VALUES(
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6, @p7,
                            @p8, @p9,
                            @p10, @p11,
                            @p12
                        )",
                       nuevoID2,
                       this.nombre,
                       this.primerApellido,
                       this.segundoApellido,
                       this.fechaNacimiento,
                       this.edad,
                       this.profesion,
                       this.direccion,
                       this.ciudad,
                       this.provincia,
                       this.pais,
                       this.telefono,
                       this.dni);

                  int ret2 = podo.Database.ExecuteSqlCommand(

                        @"INSERT INTO paciente(
                            [idPaciente],
                            [medicacionHabitual], 
                            [observacion], 
                            [numeroHistoriaClinica], 
                            [id_podologo],
                            [id_historial_clinico],
                            [id_persona]
                        )   VALUES(
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5,
                            @p6
                        )",
                        nuevoID,
                        this.medicacionHabitual,
                        this.observacion,
                        this.numeroHistoriaClinica,
                        this.idPodologo,
                        this.idHistorialClinico,
                        this.idPersona

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

        public void GuardarEn(podologiaEntities podo, paciente paciente, persona persona)
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
                    Debug.Assert(this.idPersonaP == persona.idPersona);

                    int ret = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [paciente] SET
                            [medicacionHabitual] = @p1, 
                            [observacion] = @p2, 
                            [numeroHistoriaClinica] = @p3, 
                            [id_podologo] = @p4,
                            [id_historial_clinico] = @p5,
                            [id_persona] = @p6
                        WHERE [idPaciente] = @p0
                        ",
                            paciente.idPaciente,
                            this.medicacionHabitual,
                            this.observacion,
                            this.numeroHistoriaClinica,
                            this.idPodologo,
                            this.idHistorialClinico,
                            this.idPersona,
                            
                        @"UPDATE [persona] SET(
                            [nombre] = @p1, 
                            [apellido1] = @p2, 
                            [apellido2] = @p3, 
                            [fechaNacimiento] = @p4,
                            [edad] = @p5,
                            [profesion] = @p6,
                            [calle] = @p7,
                            [ciudad] = @p8, 
                            [provincia] = @p9, 
                            [pais] = @p10, 
                            [telefono] = @p11,
                            [dni] = @p12
                       WHERE [idPersona] = @p0",
                       persona.idPersona,
                       this.nombre,
                       this.primerApellido,
                       this.segundoApellido,
                       this.fechaNacimiento,
                       this.edad,
                       this.profesion,
                       this.direccion,
                       this.ciudad,
                       this.provincia,
                       this.pais,
                       this.telefono,
                       this.dni
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