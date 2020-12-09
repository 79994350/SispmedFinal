using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Convenios
    {
        public int Id { get; set; }
        public double CosConv { get; set; }
        public double DurConv { get; set; }
        public DateTime FecAper { get; set; }
        public string NomConv { get; set; }
        public string ObjConv { get; set; }
        public string Resolu { get; set; }
        public int EpsId { get; set; }
        public int Estado { get; set; }

        public virtual Eps Eps { get; set; }
    }
}
