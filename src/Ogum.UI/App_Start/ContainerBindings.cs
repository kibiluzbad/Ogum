using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Ninject.Modules;
using NinjectAdapter;
using Raven.Client;
using Raven.Client.Document;

namespace Ogum.UI.App_Start
{
    public class ContainerBindings : NinjectModule
    {
      public override void Load()
      {
        var locator = new NinjectServiceLocator(Kernel);

        ServiceLocator.SetLocatorProvider(() => locator);

        Bind<IServiceLocator>().ToConstant(locator).InSingletonScope();
        Bind<IDocumentStore>().ToConstant(new DocumentStore
                                            {
                                              ConnectionStringName = "default"
                                            }.Initialize())
          .InSingletonScope();
        Bind<IDocumentSession>()
          .ToConstant(ServiceLocator.Current.GetInstance<IDocumentStore>().OpenSession())
          .InRequestScope();
      }
    }
}