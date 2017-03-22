using AbiokaBoilerplate.Domain.Events;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Infrastructure.Common.Domain;

namespace AbiokaBoilerplate.ApplicationService.EventHandlers
{
    public class RoleAddedToUserHandler : IEventHandler<RoleAddedToUser>
    {
        private readonly IRoleRepository roleRepository;

        public RoleAddedToUserHandler(IRoleRepository roleRepository) {
            this.roleRepository = roleRepository;
        }

        public void Handle(RoleAddedToUser eventInstance) {
            roleRepository.AddToUser(eventInstance.RoleId, eventInstance.User.Id);
        }
    }
}
