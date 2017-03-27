using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using System;

namespace AbiokaBoilerplate.Infrastructure.Common.Helper
{
    public class CurrentContext : ICurrentContext
    {
        public CurrentContext() {
            IP = Guid.NewGuid().ToString();
        }

        public ICurrentContext Current {
            get {
                return DependencyContainer.Container.Resolve<ICurrentContext>();
            }
        }

        public string IP { get; set; }

        public ICustomPrincipal Principal { get; set; }

        public ActionType ActionType { get; set; }
    }
}