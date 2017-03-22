using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Repository.DatabaseObjects;
using System;
using System.Linq;

namespace AbiokaBoilerplate.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AbiokaDbContext context)
            : base(context)
        {
        }

        public void AddToUser(Guid roleId, Guid userId)
        {
            var userRole = new UserRoleDB
            {
                Role = new Role(roleId, string.Empty),
                UserId = userId
            };
            // TODO: uncomment
            // Save(userRole);
        }

        public Role GetByName(string name)
        {
            var result = Query().Where(q => q.Name.ToLowerInvariant() == name.ToLowerInvariant()).FirstOrDefault();
            return result;
        }

        public void RemoveFromUser(Guid roleId, Guid userId)
        {
            var userRole = GetQuery<UserRoleDB>().Where(ur => ur.UserId == userId && ur.Role.Id == roleId).FirstOrDefault();
            // TODO: uncomment
            //Delete(userRole);
        }
    }
}
