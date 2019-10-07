using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConciliation.Infra.Configurations
{
    public class TransactionConfiguration
        : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Type)
                .IsRequired();

            Property(t => t.Date)
                .IsRequired();

            Property(t => t.Description)
                .IsRequired();

            Property(t => t.Identifier)
                .IsRequired();

            Property(t => t.Amount)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
