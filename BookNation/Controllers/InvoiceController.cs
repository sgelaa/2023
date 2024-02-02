using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class InvoiceController : BaseApiController
    {
        private readonly DataContext _context;

        public InvoiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("All/{userId}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAll(int userId)
        {
            return await _context.Invoices.Where(inv => inv.AppUserId == userId).ToListAsync();
        }
      
        [HttpGet("GetInvoice/{userId}/{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int userId, int invoiceId)
        {
            return await _context.Invoices.Where(inv => inv.AppUserId == userId && inv.Id == invoiceId).FirstOrDefaultAsync();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<InvoiceDto>> Add(InvoiceDto invoiceDto)
        {
            var invoice = new Invoice
            {
                Amount = invoiceDto.Amount,
                AppUserId = invoiceDto.AppUserId,
                PaymentDate = invoiceDto.PaymentDate
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return new InvoiceDto
            {
                Amount = invoice.Amount,
                AppUserId = invoice.AppUserId,
                PaymentDate = invoice.PaymentDate,
            };
        }
    }
}