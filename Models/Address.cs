using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pin { get; set; }

        public virtual User User { get;set;}    
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
