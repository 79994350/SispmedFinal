using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Tiposid
    {
        public Tiposid()
        {
            Acompanantes = new HashSet<Acompanantes>();
            Empleados = new HashSet<Empleados>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string NomTipo { get; set; }

        public virtual ICollection<Acompanantes> Acompanantes { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Pacientes> Pacientes { get; set; }
    }
}
