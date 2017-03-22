using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Domain.Repositories;
using System.Linq;

namespace AbiokaBoilerplate.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AbiokaDbContext context)
            : base(context) {
        }

        public int Count() {
            return GetQuery<User>().Count();
        }
    }
}
