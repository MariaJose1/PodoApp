using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Angle.Models
{
    public class FormConsulta
    {

        public Guid? IdConsulta { get; set; }

        public Guid? IdPaciente { get; set; }

        public Guid? IdPodologo { get; set; }

        [DisplayName("Fecha de la consulta")]
        public DateTime? Fecha { get; set; }

        [DisplayName("Descripción")]
        public String Descripcion { get; set; }


        public static FormConsulta Rellenar(consulta consulta)
        {

            return new FormConsulta
            {
                IdConsulta = consulta.idConsulta,
                Fecha = consulta.fecha,
                Descripcion = consulta.descripcion          

            };

        }

        public void InsertarEn(podologiaEntities podo, paciente paciente)
        {
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    var nuevoIdConsulta = Guid.NewGuid();

                    int retConsulta = podo.Database.ExecuteSqlCommand(
                         @"INSERT INTO consulta(
                            [idConsulta],
                            [fecha],
                            [descripcion],
                            [id_paciente]
                            ) VALUES (
                            @p0, @p1,
                            @p2, @p3        
                           )",
                      nuevoIdConsulta,
                      this.Fecha,
                      this.Descripcion,
                      paciente.idPaciente
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
            consulta consulta = podo.consulta.Where(p => p.idConsulta == this.IdConsulta).FirstOrDefault();
            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    int retConsulta = podo.Database.ExecuteSqlCommand(
                         @"UPDATE consulta SET
                            [fecha]=@p1,
                            [descripcion]=@p2
                            WHERE [idConsulta]=@p0",
                          consulta.idConsulta,
                          this.Fecha,
                          this.Descripcion
                      );

                }
                catch (Exception)
                {
                    tr.Rollback();
                    throw;
                }
                tr.Commit();
            }

        }

        public void Seleccionar(podologiaEntities podo, paciente paciente)
        {

            using (var tr = podo.Database.BeginTransaction())
            {
                try
                {
                    int retConsulta = podo.Database.ExecuteSqlCommand(
                         @"SELECT * FROM Consulta
                            
                            WHERE [id_paciente]=@p0",
                            paciente.idPaciente

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