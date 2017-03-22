using AbiokaBoilerplate.Infrastructure.Common.IoC;
using System.Linq;

namespace AbiokaBoilerplate.Infrastructure.Framework.IoC
{
    // TODO: uncommet
    /*
    public class ServiceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation) {
            IInvocationContext context = new InvocationContext() {
                Arguments = invocation.Arguments,
                GenericArguments = invocation.GenericArguments,
                Method = invocation.Method,
                InvocationTarget = invocation.InvocationTarget,
                MethodInvocationTarget = invocation.MethodInvocationTarget,
                Proxy = invocation.Proxy,
                ReturnValue = invocation.ReturnValue,
                TargetType = invocation.TargetType
            };

            var interceptors = DependencyContainer.Container.ResolveAll<IServiceInterceptor>().OrderBy(d => d.Order);
            if (interceptors != null) {
                foreach (var interceptorItem in interceptors) {
                    interceptorItem.BeforeProceed(context);
                }
            }

            invocation.Proceed();
        }
    }
    */
}
