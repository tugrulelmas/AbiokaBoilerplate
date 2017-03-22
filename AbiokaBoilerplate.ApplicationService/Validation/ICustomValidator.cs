using AbiokaBoilerplate.Infrastructure.Common.Helper;
using FluentValidation.Results;

namespace AbiokaBoilerplate.ApplicationService.Validation
{
    public interface ICustomValidator
    {
        ValidationResult Validate(object instance, ActionType actionType);
    }

    public interface ICustomValidator<in T>
    {
        ValidationResult Validate(T instance, ActionType actionType);
    }
}
