using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Models
{
    public class UserRegistration
    {
        [Key]
        [Required(ErrorMessage ="This is required field")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This is required field")]
        [MaxLength(50)]
        public string firstname { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "This is required field")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "This is required field")]
        [EmailAddress]
        public string email { get; set; }


        [Required(ErrorMessage = "This is required field")]
        [Phone]
        [MinLength(10)]
        [MaxLength(10)]
        public string phonenumber { get; set; }


        [Required(ErrorMessage = "This is required field")]
        public int age { get; set; }

        [Required(ErrorMessage = "This is required field")]
        public string gender { get; set; }

        [Required(ErrorMessage = "This is required field")]
        public string country { get; set; }

        [Required(ErrorMessage = "This is required field")]
        public string state { get; set; }

        [Required(ErrorMessage = "This is required field")]
        public string address { get; set; }

        [Required(ErrorMessage = "This is required field")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "This is required field")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmPassword {  get; set; }

    }
}
