using System;
using System.Collections.Generic;

namespace Carstock.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
        }

        public int IdCustomer { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
