using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookNation.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AppUserId { get; set; }
    }
}