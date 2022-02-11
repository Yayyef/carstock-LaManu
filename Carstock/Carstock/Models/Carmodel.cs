using System;
using System.Collections.Generic;

namespace Carstock.Models
{
    public partial class Carmodel
    {
        public Carmodel()
        {
            Cars = new HashSet<Car>();
        }

        public int IdModel { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
