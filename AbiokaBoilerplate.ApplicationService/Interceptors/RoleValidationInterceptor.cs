using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using System.Linq;
using System.Reflection;

namespace AbiokaBoilerplate.ApplicationService.Interceptors
{
    internal class RoleValidationInterceptor : IServiceInterceptor
    {
        private readonly ICurrentContext currentContext;

        public RoleValidationInterceptor(ICurrentContext currentContext) {
            this.currentContext = currentContext;
        }

        public int Order => 0;

        public void BeforeProceed(IInvocationContext context) {
            var attributes = context.Method.GetCustomAttributes(typeof(AllowedRole), true);
            if (attributes == null || attributes.Count() == 0)
                return;

            if(currentContext.Current.Principal == null || currentContext.Current.Principal.Roles == null)
                throw new DenialException("AccessDenied");


            var allowedRoles = (AllowedRole)attributes.First();
            if (currentContext.Current.Principal.Roles.Any(r => allowedRoles.Roles.Contains(r)))
                return;

            throw new DenialException("AccessDenied");
        }
    }
}
