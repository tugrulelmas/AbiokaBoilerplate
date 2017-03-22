using AbiokaBoilerplate.ApplicationService.DTOs;
using AbiokaBoilerplate.ApplicationService.Validation;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using FluentValidation;

namespace AbiokaBoilerplate.ApplicationService.Messaging
{
    public class AddUserRequest : UserDTO
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }

    public class RegisterUserRequest : AddUserRequest
    {
    }

    public class AddUserRequestValidator : CustomValidator<AddUserRequest>
    {
        private readonly IUserSecurityRepository userSecurityRepository;

        public AddUserRequestValidator(IUserSecurityRepository userSecurityRepository) {
            this.userSecurityRepository = userSecurityRepository;

            RuleFor(r => r.Email).NotEmpty().WithMessage("IsRequired").EmailAddress().WithMessage("ShouldBeCorrectEmail");
            RuleFor(r => r.Password).NotEmpty().WithMessage("IsRequired");
        }

        protected override void DataValidate(AddUserRequest instance, ActionType actionType) {
            var tmpUser = userSecurityRepository.GetByEmail(instance.Email);
            if (tmpUser != null)
                throw new DenialException("UserIsAlreadyRegistered", instance.Email);
        }
    }
}
