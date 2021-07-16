using Logistic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistic.data.Model
{
    public class OrderWithEmail
    {
        public Order order { get; set; }
        public string email { get; set; }

    }
}
