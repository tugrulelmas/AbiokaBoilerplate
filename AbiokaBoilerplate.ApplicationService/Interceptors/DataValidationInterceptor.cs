using AbiokaBoilerplate.ApplicationService.Validation;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using System.Reflection;

namespace AbiokaBoilerplate.ApplicationService.Interceptors
{
    internal class DataValidationInterceptor : IServiceInterceptor
    {
        private readonly ICurrentContext currentContext;

        public DataValidationInterceptor(ICurrentContext currentContext) {
            this.currentContext = currentContext;
        }

        public int Order => 1;

        public void BeforeProceed(IInvocationContext context) {
            foreach (var item in context.Arguments) {
                if (item == null)
                    continue;

                var itemType = item.GetType();
                if (itemType.GetTypeInfo().IsPrimitive || itemType.IsArray)
                    continue;

                var type = typeof(ICustomValidator<>).MakeGenericType(item.GetType());
                var validator = (ICustomValidator)DependencyContainer.Container.Resolve(type);
                if (validator == null)
                    continue;

                var result = validator.Validate(item, currentContext.Current.ActionType);
                if (result.IsValid)
                    continue;

                foreach (var errorItem in result.Errors) {
                    throw new DenialException(errorItem.ErrorMessage, errorItem.PropertyName);
                    // TODO: throw exception for all error messages
                }
            }
        }
    }
}
