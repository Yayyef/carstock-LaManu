using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carstock.Models
{
    public partial class Roles
    {
        [Key]
        public string Admin { get; set; } = null!;
        public string User { get; set; } = null!;
        public string superAdmin { get; set; } = null!;
    }
}