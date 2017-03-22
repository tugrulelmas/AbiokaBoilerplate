using AbiokaBoilerplate.ApplicationService.DTOs;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using FluentValidation;

namespace AbiokaBoilerplate.ApplicationService.Validation
{
    public class RoleValidator : CustomValidator<RoleDTO>
    {
        private readonly IRoleRepository repository;

        public RoleValidator(IRoleRepository repository) {
            this.repository = repository;

            RuleFor(r => r.Name).NotEmpty().WithMessage("IsRequired");
        }

        protected override void DataValidate(RoleDTO instance, ActionType actionType) {
            if (actionType == ActionType.Add || actionType == ActionType.Update) {
                var role = repository.GetByName(instance.Name);
                if (role != null && role.Id != instance.Id)
                    throw new DenialException("RoleIsAlreadyRegistered", instance.Name);
            }
        }
    }
}
