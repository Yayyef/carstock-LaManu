using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carstock.Models
{
    public partial class Admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string Name { get; set; } = null!;

        [Display(Name ="Password")]
        public string Password { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
    }
}
