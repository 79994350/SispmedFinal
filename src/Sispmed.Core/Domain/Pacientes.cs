using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Acompanantes = new HashSet<Acompanantes>();
            Citas = new HashSet<Citas>();
        }

        public int Id { get; set; }
        public string CiuRes { get; set; }
        public string DirRes { get; set; }
        public string ECivil { get; set; }
        public string MailPac { get; set; }
        public DateTime FecNac { get; set; }
        public string Genero { get; set; }
        public string NIdPac { get; set; }
        public string PApe { get; set; }
        public string PNom { get; set; }
        public string Regimen { get; set; }
        public string Rh { get; set; }
        public string SApe { get; set; }
        public string SNom { get; set; }
        public string TelPac { get; set; }
        public int EpsId { get; set; }
        public int TipoIdId { get; set; }

        public virtual Eps Eps { get; set; }
        public virtual Tiposid TipoId { get; set; }
        public virtual ICollection<Acompanantes> Acompanantes { get; set; }
        public virtual ICollection<Citas> Citas { get; set; }
    }
}
