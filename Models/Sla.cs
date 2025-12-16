namespace core_erp.Models
{
    public class Sla
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
        public string Metric { get; set; } = string.Empty;
        public string Threshold { get; set; } = string.Empty;
    }
}
