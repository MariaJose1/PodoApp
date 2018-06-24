using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormPaciente : IEnumerable
    {
        [Key()]
        IEnumerable<FormPaciente> pacientes { get; set; }

        // PACIENTE

        [Required()]
        public Guid IdPaciente { get; set; }

        [DisplayName("Medicación habitual")]
        [Required()]
        public string MedicacionHabitual { get; set; }

        [DisplayName("Observación")]
        public string Observacion { get; set; }

        [DisplayName("Número Historia Clínica")]
        [Required()]
        public string NumeroHistoriaClinica { get; set; }

        [DisplayName("Podólogo que realiza la consulta")]
        public Guid? IdPodologo { get; set; }

        // PERSONA
        [DisplayName("Nombre")]
        [Required()]
        public string Nombre { get; set; }

        [DisplayName("Primer apellido")]
        [Required()]
        public string PrimerApellido { get; set; }

        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; }

        [DisplayName("Fecha nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required()]
        public DateTime? FechaNacimiento { get; set; }

        [DisplayName("Edad")]
        [Required()]
        public int? Edad { get; set; }

        [DisplayName("Profesión")]
        public string Profesion { get; set; }

        [DisplayName("Dirección")]
        [Required()]
        public string Direccion { get; set; }

        [DisplayName("Ciudad")]
        [Required()]
        public string Ciudad { get; set; }

        [DisplayName("Provincia")]
        public string Provincia { get; set; }

        [DisplayName("País")]
        [Required()]
        public string Pais { get; set; }

        [DisplayName("Teléfono")]
        [Required()]
        [MaxLength(9, ErrorMessage ="El número de teléfono debe estar formado por 9 dígitos")]
        [MinLength(9, ErrorMessage = "El número de teléfono debe estar formado por 9 dígitos")]
        public string Telefono { get; set; }

        [DisplayName("DNI")]
        [Required()]
        [RegularExpression(@"^((([A-Z]|[a-z])\d{8})|(\d{8}([A-Z]|[a-z])))$", ErrorMessage = "Introduzca un DNI válido")]
        public string Dni { get; set; }





        public static FormPaciente Rellenar(paciente paciente)
        {
            persona persona = paciente.persona;
            historialClinico historial = paciente.historialClinico;

            return new FormPaciente
            {
                IdPaciente = paciente.idPaciente,
                MedicacionHabitual = paciente.medicacionHabitual,
                Observacion = paciente.observacion,
                NumeroHistoriaClinica = historial.numeroHistorialClinico,
                IdPodologo = paciente.id_podologo,

                Nombre = persona.nombre,
                PrimerApellido = persona.apellido1,
                SegundoApellido = persona.apellido2,
                FechaNacimiento = persona.fechaNacimiento,
                Edad = persona.edad,
                Profesion = persona.profesion,
                Direccion = persona.calle,
                Ciudad = persona.ciudad,
                Provincia = persona.provincia,
                Pais = persona.pais,
                Telefono = persona.telefono,
                Dni = persona.dni,
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
                    var nuevoIdHistorial = Guid.NewGuid();
                    var nuevoIdPV = Guid.NewGuid();

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
                       nuevoID,
                       this.Nombre,
                       this.PrimerApellido,
                       this.SegundoApellido,
                       this.FechaNacimiento,
                       this.Edad,
                       this.Profesion,
                       this.Direccion,
                       this.Ciudad,
                       this.Provincia,
                       this.Pais,
                       this.Telefono,
                       this.Dni);

                    int retHistorial = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO historialClinico(
                            [idHistorialClinico],
                            [numeroHistorialClinico]
                            ) VALUES (
                            @p0, @p1
                            )",
                      nuevoIdHistorial,
                      this.NumeroHistoriaClinica
                      );

                    int ret2 = podo.Database.ExecuteSqlCommand(

                        @"INSERT INTO paciente(
                            [idPaciente],
                            [medicacionHabitual], 
                            [observacion], 
                            [id_podologo],
                            [id_historial_clinico],
                            [id_persona]
                        )   VALUES(
                            @p0, @p1,
                            @p2, @p3,
                            @p4, @p5
                        )",
                        nuevoID2,
                        this.MedicacionHabitual,
                        this.Observacion,
                        this.IdPodologo,
                        nuevoIdHistorial,
                        nuevoID
                        );

                    int retPV = podo.Database.ExecuteSqlCommand(
                      @"INSERT INTO primeraVisita(
                            [idPrimeraVisita],
                            [diabetes],
                            [alergias],
                            [hayDolor],
                            [fechaPrimeraConsulta],
                            [id_paciente],
                            [id_historial_clinico]
                            ) VALUES (
                            @p0, @p1,@p2,@p3,@p4,@p5,@p6
                            )",
                     nuevoIdPV,
                     0,
                     0,
                     0,
                     DateTime.Now,
                     nuevoID2,
                     nuevoIdHistorial
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
            paciente paciente = podo.paciente.Where(p => p.idPaciente == this.IdPaciente).FirstOrDefault();
            persona persona = paciente.persona;
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    Debug.Assert(this.IdPaciente == paciente.idPaciente);
                    Debug.Assert(this.IdPodologo == paciente.id_podologo);


                    int ret = podo.Database.ExecuteSqlCommand(
                        @"UPDATE [paciente] SET
                            [medicacionHabitual] = @p1, 
                            [observacion] = @p2, 
                            [id_podologo] = @p3
                        WHERE [idPaciente] = @p0
                        ",
                            paciente.idPaciente,
                            this.MedicacionHabitual,
                            this.Observacion,
                            this.IdPodologo
                            );

                  

                    int ret2 = podo.Database.ExecuteSqlCommand(

                            @"UPDATE [persona] SET
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
                           this.Nombre,
                           this.PrimerApellido,
                           this.SegundoApellido,
                           this.FechaNacimiento,
                           this.Edad,
                           this.Profesion,
                           this.Direccion,
                           this.Ciudad,
                           this.Provincia,
                           this.Pais,
                           this.Telefono,
                           this.Dni
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

        // Enumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)pacientes).GetEnumerator();
        }

      
    }
}