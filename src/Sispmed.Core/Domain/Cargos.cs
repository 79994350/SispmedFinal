using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Cargos
    {
        public Cargos()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public string NomCar { get; set; }
        public double SalCar { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
