using AbiokaBoilerplate.Domain.Events;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Infrastructure.Common.Domain;

namespace AbiokaBoilerplate.ApplicationService.EventHandlers
{
    public class RoleRemovedFromUserHandler : IEventHandler<RoleRemovedFromUser>
    {
        private readonly IRoleRepository roleRepository;

        public RoleRemovedFromUserHandler(IRoleRepository roleRepository) {
            this.roleRepository = roleRepository;
        }

        public void Handle(RoleRemovedFromUser eventInstance) {
            roleRepository.RemoveFromUser(eventInstance.RoleId, eventInstance.User.Id);
        }
    }
}
