using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace AbiokaBoilerplate.Infrastructure.Framework.IoC
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
