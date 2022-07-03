using Common.Attributes;
using Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string DetailedDescription { get; set; }

        [RequiredEnum(ErrorMessage = "Category is Required")]
        public Category Category { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Starting Price must be number")]
        public double StartingPrice { get; set; }

        [DateValidation(IsFutureDate = true)]
        [Display(Name = "Bid End Date")]
        public DateTime BidEndDate { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
