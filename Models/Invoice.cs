using System;

namespace core_erp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BillingId { get; set; }
        public Billing? Billing { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public bool Paid { get; set; } = false;
    }
}
