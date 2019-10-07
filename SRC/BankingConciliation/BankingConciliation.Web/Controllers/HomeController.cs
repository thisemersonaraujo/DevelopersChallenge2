using BankingConciliation.AppService.Contracts;
using BankingConciliation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingConciliation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionApplicationService _appService;
        private readonly IImportationApplicationService _importationAppService;

        public HomeController(ITransactionApplicationService appService, IImportationApplicationService importationAppService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
            _importationAppService = importationAppService ?? throw new ArgumentNullException(nameof(importationAppService));
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewImport()
        {
            ViewBag.Error = null;
            ViewBag.Message = null;

            return View();
        }

        [HttpPost]
        public ActionResult FileImport(HttpPostedFileBase[] ofxFiles)
        {
            try
            {
                if (!ofxFiles.Any())
                {
                    ViewBag.Error = "Por favor, selecione um ou mais arquivos para realizar a importação.";
                    return View("NewImport");
                }
                else
                {
                    var transactionsList = new List<Transaction>();

                    ofxFiles.ToList().ForEach(file =>
                    {
                        if (file == null)
                        {
                            ViewBag.Error = "Para realizar a importação, é necessário selecionar um ou mais arquivos.";
                            return;
                        }
                        else
                        {
                            string path = HttpContext.Server.MapPath("~/Images/");
                            string fileName = "ofxFile" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "_" + file.FileName;
                            file.SaveAs(path + fileName);
                            var newTransactionsList = _importationAppService.ReadOfxFile(path + fileName);
                            transactionsList.AddRange(newTransactionsList);
                        }
                    });

                    _appService.SaveList(transactionsList);
                }

                ModelState.Clear();
                ViewBag.Message = "Importação realizada com sucesso.";
                return View("NewImport");
            }
            catch (FileNotFoundException ex)
            {
                var message = ex.Message;
                ViewBag.Error = @"Não conseguimos encontrar o seu arquivo. Por favor, tente realizar a operação novamente.";

                return View("NewImport");
                throw;
            }
            catch (Exception exs)
            {
                var message = exs.Message;
                ViewBag.Error = @"Ocorreu um imprevisto ao tentar importar o seu arquivo, entre em contato conosco para podermos te ajudar.";

                return View("NewImport");
            }
        }
    }
}