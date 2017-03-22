using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Infrastructure.Common.Domain;
using AbiokaBoilerplate.Infrastructure.Common.Dynamic;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using AbiokaBoilerplate.Data.Repositories;
using AbiokaBoilerplate.Domain.Repositories;

namespace AbiokaBoilerplate.Data
{
    public class Bootstrapper
    {
        public static void Initialise() {
            Infrastructure.Common.Bootstrapper.Initialise();

            DependencyContainer.Container
                // TODO: uncomment
                .RegisterWithDefaultInterfaces(typeof(IRepository<>), typeof(Repository<>))
                .Register<IRepository<LoginAttempt>, LoginAttemptRepository>()
                //.Register<IDynamicHandler, NhUnitOfWorkHandler>(LifeStyle.PerWebRequest)
                .Register<IUnitOfWork, UnitOfWork>(LifeStyle.PerWebRequest, true)
                //.Register<IDisposableUnitOfWork, DisposableUnitOfWork>(LifeStyle.Transient, true)
                ;
        }
    }
}
