using System;
using System.Collections.Generic;

namespace Sispmed.Core.Domain
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
