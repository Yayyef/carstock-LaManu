using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carstock.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
        }
        [Key]
        public int IdCustomer { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]

        public string Password { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; }
    }
}
