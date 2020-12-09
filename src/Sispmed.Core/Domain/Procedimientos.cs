using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Procedimientos
    {
        public int Id { get; set; }
        public string CodProc { get; set; }
        public string NomProc { get; set; }
        public string PreProc { get; set; }
        public double Valor { get; set; }
    }
}
