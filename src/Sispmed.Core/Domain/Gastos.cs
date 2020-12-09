using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Gastos
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public DateTime FecGasto { get; set; }
        public string ForPago { get; set; }
        public double Valor { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleados Empleado { get; set; }
    }
}
