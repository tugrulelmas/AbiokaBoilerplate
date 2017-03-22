using AbiokaBoilerplate.Infrastructure.Common.Domain;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions.Adapters;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using AbiokaBoilerplate.Infrastructure.Common.IoC;

namespace AbiokaBoilerplate.Infrastructure.Common
{
    public class Bootstrapper
    {
        public static void Initialise() {
            DependencyContainer.Container
                // TODO: include following functions.
                /*
                .Register<IConnectionStringRepository, WebConfigConnectionStringRepository>(isFallback: true)
                */
                .Register<IContextHolder, ContextHolder>(isFallback: true)
                .Register<IExceptionAdapterFactory, ExceptionAdapterFactory>()
                .Register<ICurrentContext, CurrentContext>(LifeStyle.PerWebRequest, true)
                .Register<IEventDispatcher, EventDispatcher>(isFallback: true);
        }
    }
}
