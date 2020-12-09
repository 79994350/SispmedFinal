using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Empleados
    {
        public Empleados()
        {
            Citas = new HashSet<Citas>();
            Gastos = new HashSet<Gastos>();
            Recaudos = new HashSet<Recaudos>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string CiuRes { get; set; }
        public string DirRes { get; set; }
        public string ECivil { get; set; }
        public string MailEmp { get; set; }
        public DateTime? FecIng { get; set; }
        public DateTime? FecNac { get; set; }
        public string Genero { get; set; }
        public string NIdEmp { get; set; }
        public string PApe { get; set; }
        public string PNom { get; set; }
        public string Rh { get; set; }
        public string SApe { get; set; }
        public string SNom { get; set; }
        public string TelEmp { get; set; }
        public int? ArlId { get; set; }
        public int? CargoId { get; set; }
        public int? EpsId { get; set; }
        public int? TiposIdId { get; set; }
        public int Estado { get; set; }

        public virtual Arl Arl { get; set; }
        public virtual Cargos Cargo { get; set; }
        public virtual Eps Eps { get; set; }
        public virtual Tiposid TiposId { get; set; }
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual ICollection<Gastos> Gastos { get; set; }
        public virtual ICollection<Recaudos> Recaudos { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
