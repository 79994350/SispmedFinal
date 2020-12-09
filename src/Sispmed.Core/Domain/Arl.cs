using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Arl
    {
        public Arl()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public string NomArl { get; set; }
        public string TelArl { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
