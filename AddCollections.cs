using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Models
{
    public class AddCollections
    {
        [Key]
        public int collectionid { get; set; }

        

        [Required(ErrorMessage ="This field is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string source { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string description { get; set; }

        [ForeignKey("SellerRegistration")]
        public int SellerId { get; set; }

        public SellerRegistration sellerRegistration { get; set; }

        ICollection<AddProducts> addProducts;


    }
}
