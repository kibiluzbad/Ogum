using Ogum.UI.Infra.Automapper;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogum.UI.App_Start.NinjectMVC3), "Start", Order = 1)]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Ogum.UI.App_Start.NinjectMVC3), "Stop", Order = 1)]

namespace Ogum.UI.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3
    {
        private static readonly Ninject.Web.Mvc.Bootstrapper Bootstrapper = new Ninject.Web.Mvc.Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            Bootstrapper.Initialize(CreateKernel);
            AutoMapperConfig.Configure();
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            return Container.Kernel;
        }
    }
}
