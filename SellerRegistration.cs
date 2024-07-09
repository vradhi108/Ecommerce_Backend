using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Models
{
    public class SellerRegistration
    {
        [Key]
        public int SellerId { get; set; }

        [Required(ErrorMessage =("This field is required"))]

        public string userid { get; set; }

        [Required(ErrorMessage =("This field is required"))]
        public string firstname { get; set; }

        [Required(ErrorMessage =("This fied is required"))]

        public string lastname { get; set; }

        [Required(ErrorMessage =("This field is required"))]
        [EmailAddress]
        public string emailid { get; set; }

        [Required(ErrorMessage =("This field is required"))]
        [Phone]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = ("This field is required"))]
        [DataType(DataType.Password)]
        public string sellerpassword { get; set; }

        public int status { get; set; }

        ICollection<AddCollections> Collections { get; set; }

    }
}
