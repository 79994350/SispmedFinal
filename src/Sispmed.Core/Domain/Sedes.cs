using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Sedes
    {
        public Sedes()
        {
            Citas = new HashSet<Citas>();
        }

        public int Id { get; set; }
        public string DirSede { get; set; }
        public string NomSede { get; set; }
        public string TelSede { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
