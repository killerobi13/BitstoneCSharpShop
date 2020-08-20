using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class Order
    {

        public int Id { get; set; }
        public int Total { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
