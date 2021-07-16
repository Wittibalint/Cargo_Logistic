using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? LicensePlate { get; set; }
        public double Speed { get; set; }
        public double MaxSize { get; set; }
        public double MaxWeight { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Depot? Depot { get; set; }
        public int? DepotId { get; set; }
    }
}
