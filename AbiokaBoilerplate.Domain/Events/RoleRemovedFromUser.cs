﻿using AbiokaBoilerplate.Infrastructure.Common.Domain;
using System;

namespace AbiokaBoilerplate.Domain.Events
{
    public class RoleRemovedFromUser : IEvent
    {
        public RoleRemovedFromUser(IIdEntity<Guid> user, Guid roleId) {
            User = user;
            RoleId = roleId;
        }

        public IIdEntity<Guid> User { get; }

        public Guid RoleId { get; }
    }
}
