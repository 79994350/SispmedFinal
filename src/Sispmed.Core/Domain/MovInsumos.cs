using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class MovInsumos
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Concepto { get; set; }
        public string Tipo { get; set; }
        public int InsumoId { get; set; }

        public virtual Insumos Insumo { get; set; }
    }
}
