using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductBid : IRequest<bool>
    {
        public int ProductBidId { get; set; }

        public int ProductId { get; set; }

        public int BidAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string EmailId { get; set; }
        [ForeignKey("User")]
        public int BidderId { get; set; }
        public virtual User User { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
