using BankingConciliation.Domain.Entities;
using BankingConciliation.Infra.Configurations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BankingConciliation.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["BankingConciliationDB"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Mapping
            modelBuilder.Configurations.Add(new TransactionConfiguration());
        }

        public DbSet<Transaction> Transactions { get; set; } // TransactionRepository
    }
}
