using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public int RolId { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Empleados Empleado { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
