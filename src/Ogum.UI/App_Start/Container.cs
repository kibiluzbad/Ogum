using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace Ogum.UI.App_Start
{
    public static class Container
    {
        private static readonly Lazy<IKernel> kernel = new Lazy<IKernel>(() => new StandardKernel(new ContainerBindings()));

        public static IKernel Kernel
        {
            get
            {
                return kernel.Value;
            }
        }
    }
}