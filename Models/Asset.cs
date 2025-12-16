namespace core_erp.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
