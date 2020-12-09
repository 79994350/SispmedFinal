using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Insumos
    {
        public Insumos()
        {
            MovInsumos = new HashSet<MovInsumos>();
            StockInsumos = new HashSet<StockInsumos>();
        }

        public int Id { get; set; }
        public string CodIns { get; set; }
        public string Concen { get; set; }
        public string Labora { get; set; }
        public string NomIns { get; set; }
        public decimal PrecioU { get; set; }
        public string Pres { get; set; }
        public string Unid { get; set; }
        public int CategoriaId { get; set; }

        public virtual CategoriasInsumos Categoria { get; set; }
        public virtual ICollection<MovInsumos> MovInsumos { get; set; }
        public virtual ICollection<StockInsumos> StockInsumos { get; set; }
    }
}
