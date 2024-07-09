using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Models
{
    public class AddProducts
    {
        [Key]
        public int productid { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public string product_name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string product_category { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string product_details { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string product_image { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int product_price { get; set; }

        [ForeignKey("AddCollections")]
        public int collectionid { get; set; }

        public AddCollections addCollections { get; set; }
    }
}
