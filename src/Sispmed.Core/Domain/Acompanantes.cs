using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Acompanantes
    {
        public Acompanantes()
        {
            Citas = new HashSet<Citas>();
        }

        public int Id { get; set; }
        public int Edad { get; set; }
        public string MailAcom { get; set; }
        public string NIdAcom { get; set; }
        public string PApe { get; set; }
        public string ParPac { get; set; }
        public string PNom { get; set; }
        public string SApe { get; set; }
        public string SNom { get; set; }
        public string TelAcom { get; set; }
        public int TipoIdId { get; set; }
        public int PacienteId { get; set; }

        public virtual Pacientes Paciente { get; set; }
        public virtual Tiposid TipoId { get; set; }
        public virtual ICollection<Citas> Citas { get; set; }
    }
}
