using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class StockInsumos
    {
        public int Id { get; set; }
        public int Disponi { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int InsumoId { get; set; }

        public virtual Insumos Insumo { get; set; }
    }
}
