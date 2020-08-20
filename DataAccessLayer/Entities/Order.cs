using Microsoft.AspNet.Identity.EntityFramework;
using Shop.MVC.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.DAL.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int Total { get; set; }
        public int UserId { get; set; }

        public virtual AppUser User {get; set;}
        public DateTime? PurchaseDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}