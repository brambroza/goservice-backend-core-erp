using Microsoft.EntityFrameworkCore;
using core_erp.Models;

namespace core_erp.Data
{
    public class ErpContext : DbContext
    {
        public ErpContext(DbContextOptions<ErpContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Sla> Slas => Set<Sla>();
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Billing> Billings => Set<Billing>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
    }
}
