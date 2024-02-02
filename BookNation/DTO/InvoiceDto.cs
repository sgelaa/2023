using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookNation.DTO
{
    public class InvoiceDto
    {
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AppUserId { get; set; }
    }
}