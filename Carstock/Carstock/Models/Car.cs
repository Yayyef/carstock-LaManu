using System;
using System.Collections.Generic;

namespace Carstock.Models
{
    public partial class Car
    {
        public int IdCar { get; set; }
        public int? IdCustomer { get; set; }
        public int IdModel { get; set; }

        public virtual Customer? IdCustomerNavigation { get; set; }
        public virtual Carmodel IdModelNavigation { get; set; } = null!;
    }
}
