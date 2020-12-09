using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Citas
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int AcompananteId { get; set; }
        public int EmpleadoId { get; set; }
        public int PacienteId { get; set; }
        public int SedeId { get; set; }

        public virtual Acompanantes Acompanante { get; set; }
        public virtual Empleados Empleado { get; set; }
        public virtual Pacientes Paciente { get; set; }
        public virtual Sedes Sede { get; set; }
    }
}
