using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
