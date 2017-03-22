using AbiokaBoilerplate.Infrastructure.Common.Domain;

namespace AbiokaBoilerplate.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Count of users.
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
