using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Eps
    {
        public Eps()
        {
            Convenios = new HashSet<Convenios>();
            Empleados = new HashSet<Empleados>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        public string NomEps { get; set; }
        public string TelEps { get; set; }

        public virtual ICollection<Convenios> Convenios { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Pacientes> Pacientes { get; set; }
    }
}
