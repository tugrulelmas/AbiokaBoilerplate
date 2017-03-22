using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Infrastructure.Common.Domain;
using System;

namespace AbiokaBoilerplate.Repository.DatabaseObjects
{
    public class UserRoleDB : IdEntity<Guid>
    {
        public virtual Guid UserId { get; set; }

        public virtual Role Role { get; set; }
    }
}
