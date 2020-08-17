using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Total { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}