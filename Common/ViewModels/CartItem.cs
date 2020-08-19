using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class CartItem
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The quantity {0} must be greater than {1}.")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The unit price {0} must be greater than {1}.")]
        public int SingleUnitPrice { get; set; }
    }
}
