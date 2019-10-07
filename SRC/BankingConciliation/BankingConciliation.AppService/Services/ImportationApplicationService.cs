using BankingConciliation.AppService.Contracts;
using BankingConciliation.AppService.Useful;
using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BankingConciliation.AppService.Services
{
    public class ImportationApplicationService
        : IImportationApplicationService
    {
        public ImportationApplicationService()
        {

        }

        public List<Transaction> ReadOfxFile(string url)
        {
            var doc = OfxImportation.toXElement(url);
            var transactionsList = new List<Transaction>();


            var imps = (from c in doc.Descendants("STMTTRN")
                        select new
                        {
                            Tipo = c.Element("TRNTYPE").Value,
                            Amount = decimal.Parse(c.Element("TRNAMT").Value.Replace(",", ".")),
                            Data = DateTime.ParseExact(c.Element("DTPOSTED").Value, "yyyyMMdd", null),
                            Description = c.Element("MEMO").Value
                        });

            var lista = imps.ToList();

            foreach (var item in lista)
            {
                var t = new Transaction();
                if (item.Amount > 0) t.Type = "CREDIT";
                else t.Type = "DEBIT";

                t.Amount = item.Amount;
                t.Date = item.Data;
                t.Description = item.Description;
                t.Id = Guid.NewGuid();

                transactionsList.Add(t);
            }

            var result = AddTransactionIdentifier(transactionsList.ToList());

            return result;
        }

        public List<Transaction> AddTransactionIdentifier(List<Transaction> transactionsList)
        {
            Cryptography cryptography = new Cryptography();

            foreach (var item in transactionsList.ToList())
            {
                item.Identifier = cryptography.GetMD5(item.GetIdentifierContent());

                if (transactionsList.Any(t => t.Identifier == item.Identifier && t.Id != item.Id))
                    transactionsList.Remove(item);
            };

            return transactionsList.ToList();
        }
    }
}
