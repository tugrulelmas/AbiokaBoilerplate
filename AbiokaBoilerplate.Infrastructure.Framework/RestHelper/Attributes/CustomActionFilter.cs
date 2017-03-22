using AbiokaBoilerplate.Infrastructure.Common.Dynamic;
using AbiokaBoilerplate.Infrastructure.Common.IoC;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaBoilerplate.Infrastructure.Framework.RestHelper.Attributes
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // TODO: uncommnet
            IRequestContext requestContext = null;// new RequestContext(context.HttpContext.Request);

            foreach (var dynamicHandlerItem in dynamicHandlers)
            {
                dynamicHandlerItem.BeforeSend(requestContext);
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            if (context.Exception == null)
            {
                foreach (var dynamicHandlerItem in dynamicHandlers)
                {
                    dynamicHandlerItem.AfterSend(null);
                }
            }
            else
            {
                IExceptionContext exceptionContext = new Common.Dynamic.ExceptionContext(context);
                foreach (var dynamicHandlerItem in dynamicHandlers)
                {
                    dynamicHandlerItem.OnException(exceptionContext);
                }
            }
        }

        private IEnumerable<IDynamicHandler> dynamicHandlers => DependencyContainer.Container.ResolveAll<IDynamicHandler>().OrderBy(d => d.Order);
    }
}