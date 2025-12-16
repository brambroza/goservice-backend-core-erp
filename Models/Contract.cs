using System;

namespace core_erp.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}
