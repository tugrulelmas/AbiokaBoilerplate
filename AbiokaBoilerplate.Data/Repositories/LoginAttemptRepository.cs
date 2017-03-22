using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Domain.Repositories;

namespace AbiokaBoilerplate.Data.Repositories
{
    public class LoginAttemptRepository : Repository<LoginAttempt>, ILoginAttemptRepository
    {
        public LoginAttemptRepository(AbiokaDbContext context) 
            : base(context)
        {
        }

        // TODO: uncomment
        /*
        public override void Add(LoginAttempt entity)
        {
            using (var unitOfWork = DependencyContainer.Container.Resolve<IDisposableUnitOfWork>())
            {
                Add(unitOfWork.Session, entity);

                unitOfWork.Commit();
            }
        }

        public override IPage<LoginAttempt> GetPage(PageRequest pageRequest)
        {
            if (currentContext.Current.Principal.IsInRole("Admin"))
            {
                return base.GetPage(pageRequest);
            }

            return GetPage(pageRequest, la => la.User.Id == currentContext.Current.Principal.Id);
        }
        */
    }
}
