using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public Address Address { get; set; }
                
        public ICollection<Product> Products { get; set; }

        public ICollection<ProductBid> ProductBids { get; set; }
    }
}
