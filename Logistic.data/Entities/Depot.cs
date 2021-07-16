using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Data.Entities
{
    public class Depot
    {
        public int Id { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string Address { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
