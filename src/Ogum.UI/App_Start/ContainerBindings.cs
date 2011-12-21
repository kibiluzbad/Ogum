using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using Ninject.Modules;
using NinjectAdapter;
using Xango.Data;
using Xango.Data.NHibernate;
using Xango.Data.NHibernate.Configuration;
using Xango.Data.NHibernate.Queries;
using Xango.Data.Query;

namespace Ogum.UI.App_Start
{
    public class ContainerBindings : NinjectModule
    {
        public override void Load()
        {
            var locator = new NinjectServiceLocator(Kernel);
            
            ServiceLocator.SetLocatorProvider(() => locator);
            
            Bind(typeof(IRepository<>)).To(typeof(NHibernateRepository<>));
            Bind<IServiceLocator>().ToConstant(locator).InSingletonScope();
            Bind<ISessionFactory>().ToConstant(NHFluentConfiguration.SessionFactory).InSingletonScope();
            Bind<IQueryFactory>().To<QueryFactory>();

            //Queries
            Bind(typeof(IGetEntityById<>)).To(typeof(GetEntityById<>));
        }
    }
}