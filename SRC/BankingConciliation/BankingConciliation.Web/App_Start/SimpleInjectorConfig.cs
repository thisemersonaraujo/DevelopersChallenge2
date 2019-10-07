using BankingConciliation.AppService.Contracts;
using BankingConciliation.AppService.Services;
using BankingConciliation.Domain.Contracts.Repositories;
using BankingConciliation.Domain.Contracts.Services;
using BankingConciliation.Domain.Services;
using BankingConciliation.Infra.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace BankingConciliation.Web.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Repositories Register
            container.Register<ITransactionRepository, TransactionRepository>(Lifestyle.Singleton);

            // DomainService Register
            container.Register<ITransactionDomainService, TransactionDomainService>(Lifestyle.Singleton);

            // ApplicationService Register
            //container.Register(typeof(IBaseApplicationService<,>), typeof(BaseApplicationService<,>));
            container.Register<ITransactionApplicationService, TransactionApplicationService>(Lifestyle.Singleton);
            container.Register<IImportationApplicationService, ImportationApplicationService>(Lifestyle.Singleton);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}