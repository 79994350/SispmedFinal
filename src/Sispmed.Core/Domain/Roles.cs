using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string NomRol { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
