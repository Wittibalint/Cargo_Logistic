using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string TransportFrom { get; set; }
        public string TransportTo { get; set; }
        public int TransportFromX { get; set; }
        public int TransportFromY { get; set; }
        public int TransportToX { get; set; }
        public int TransportToY { get; set; }
        public DateTime RegistryDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public string PhoneNumber { get; set; }
        public string Delivered { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int? VehicleId { get; set; }
    }
}
