using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using AbiokaBoilerplate.Infrastructure.Common.Dynamic;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using AbiokaBoilerplate.Infrastructure.Framework.Authentication;
using AbiokaBoilerplate.Infrastructure.Framework.Handlers;
using AbiokaBoilerplate.Infrastructure.Framework.IoC;

namespace AbiokaBoilerplate.Infrastructure.Framework
{
    public class Bootstrapper
    {
        public static void Initialise() {
            DependencyContainer.Container
                // TODO: uncomment
               // .Register<ServiceInterceptor>(LifeStyle.Transient)
                .Register<IAbiokaToken, AbiokaToken>(isFallback: true)
                .Register<IDynamicHandler, AuthenticationHandler>(LifeStyle.PerWebRequest)
                .Register<IDynamicHandler, ExceptionHandler>();
        }
    }
}
