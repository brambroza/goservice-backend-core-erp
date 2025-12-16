using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core_erp.Data;
using core_erp.Models;

namespace core_erp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErpController : ControllerBase
    {
        private readonly ErpContext _context;

        public ErpController(ErpContext context)
        {
            _context = context;
        }

        [HttpGet("health")]
        public IActionResult Health() => Ok(new { status = "ok" });

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers() =>
            await _context.Customers.AsNoTracking().ToListAsync();

        [HttpPost("customers")]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer payload)
        {
            _context.Customers.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomers), new { id = payload.Id }, payload);
        }

        [HttpGet("contracts")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts() =>
            await _context.Contracts.Include(c => c.Customer).AsNoTracking().ToListAsync();

        [HttpPost("contracts")]
        public async Task<ActionResult<Contract>> CreateContract(Contract payload)
        {
            _context.Contracts.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContracts), new { id = payload.Id }, payload);
        }

        [HttpGet("slas")]
        public async Task<ActionResult<IEnumerable<Sla>>> GetSlas() =>
            await _context.Slas.Include(s => s.Contract).AsNoTracking().ToListAsync();

        [HttpPost("slas")]
        public async Task<ActionResult<Sla>> CreateSla(Sla payload)
        {
            _context.Slas.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSlas), new { id = payload.Id }, payload);
        }

        [HttpGet("assets")]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets() =>
            await _context.Assets.Include(a => a.Contract).AsNoTracking().ToListAsync();

        [HttpPost("assets")]
        public async Task<ActionResult<Asset>> CreateAsset(Asset payload)
        {
            _context.Assets.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssets), new { id = payload.Id }, payload);
        }

        [HttpGet("billings")]
        public async Task<ActionResult<IEnumerable<Billing>>> GetBillings() =>
            await _context.Billings.Include(b => b.Contract).AsNoTracking().ToListAsync();

        [HttpPost("billings")]
        public async Task<ActionResult<Billing>> CreateBilling(Billing payload)
        {
            _context.Billings.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBillings), new { id = payload.Id }, payload);
        }

        [HttpGet("invoices")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices() =>
            await _context.Invoices.Include(i => i.Billing).AsNoTracking().ToListAsync();

        [HttpPost("invoices")]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice payload)
        {
            _context.Invoices.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInvoices), new { id = payload.Id }, payload);
        }
    }
}
