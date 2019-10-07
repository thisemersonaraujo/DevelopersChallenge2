using AutoMapper;
using BankingConciliation.AppService.Contracts;
using BankingConciliation.Domain.Entities;
using BankingConciliation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BankingConciliation.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionApplicationService _appService;

        public TransactionController(ITransactionApplicationService appService)
        {
            _appService = appService ?? throw new ArgumentException(nameof(appService));
        }

        private List<TransactionModel> GetAll()
        {
            var modelList = new List<TransactionModel>();
            var transactionsList = _appService.GetAll().OrderByDescending(o => o.Date).ToList();
            var amount = transactionsList.ToList().Sum(b => b.Amount);
            ViewBag.Amount = amount.ToString("N");

            modelList = Mapper.Map<List<Transaction>, List<TransactionModel>>(transactionsList);
            return modelList.ToList();
        }

        //
        // GET: /Transaction/
        public ActionResult List()
        {
            var modelList = GetAll();

            return View(modelList.ToList());
        }
    }
}