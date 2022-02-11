using System;
using System.Collections.Generic;

namespace Carstock.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
    }
}
