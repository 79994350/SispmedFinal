using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class CategoriasInsumos
    {
        public CategoriasInsumos()
        {
            Insumos = new HashSet<Insumos>();
        }

        public int Id { get; set; }
        public string NomCate { get; set; }
        public int TipoCate { get; set; }

        public virtual ICollection<Insumos> Insumos { get; set; }
    }
}
