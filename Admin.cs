using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "This is required")]
        public int Id { get; set; }


        [Required(ErrorMessage ="This is required")]
        public string username  { get; set; }


        [Required(ErrorMessage = "This is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
