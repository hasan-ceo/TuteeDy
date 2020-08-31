using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using Wps.Domain.Abstract;
using Wps.Domain.Concrete;
using Wps.Domain.Entities;
//using AbcReportBd.WebUI.Infrastructure.Abstract;
//using AbcReportBd.WebUI.Infrastructure.Concrete;

namespace Wps.WebUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICategoryRep>().To<EFCategoryRep>();
            kernel.Bind<IWordRep>().To<EFWordRep>();
            kernel.Bind<INewsPaperRep>().To<EFNewsPaperRep>();
            kernel.Bind<INewsletterRep>().To<EFNewsletterRep>();
            kernel.Bind<IWordUserRep>().To<EFWordUserRep>();

            //EmailSettings emailSettings = new EmailSettings
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager
            //        .AppSettings["Email.WriteAsFile"] ?? "false")
            //};

            //kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            //    .WithConstructorArgument("settings", emailSettings);

            //kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}
