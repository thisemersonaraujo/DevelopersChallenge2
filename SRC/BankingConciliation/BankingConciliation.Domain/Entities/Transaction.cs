using System;

namespace BankingConciliation.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }


        public string GetIdentifierContent()
        {
            return Type.ToUpper() + Amount.ToString() + Date.ToString("ddMMyyyy");
        }
    }
}
