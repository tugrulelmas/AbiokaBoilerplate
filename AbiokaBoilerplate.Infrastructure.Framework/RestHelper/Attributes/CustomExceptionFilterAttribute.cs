using AbiokaBoilerplate.Infrastructure.Common.Dynamic;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AbiokaBoilerplate.Infrastructure.Framework.RestHelper.Attributes
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext context)
        {
            var dynamicHandlers = DependencyContainer.Container.ResolveAll<IDynamicHandler>().OrderBy(d => d.Order);
            IExceptionContext exceptionContext = new Common.Dynamic.ExceptionContext(context);
            foreach (var dynamicHandlerItem in dynamicHandlers)
            {
                dynamicHandlerItem.OnException(exceptionContext);
            }
        }
    }
}