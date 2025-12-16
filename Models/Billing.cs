using System;

namespace core_erp.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingDate { get; set; } = DateTime.UtcNow;
    }
}
