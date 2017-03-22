using AbiokaBoilerplate.Infrastructure.Common.Dynamic;
using AbiokaBoilerplate.Infrastructure.Common.Exceptions.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace AbiokaBoilerplate.Infrastructure.Framework.Handlers
{
    public class ExceptionHandler : IDynamicHandler
    {
        private readonly IExceptionAdapterFactory exceptionAdapterFactory;

        public ExceptionHandler(IExceptionAdapterFactory exceptionAdapterFactory)
        {
            this.exceptionAdapterFactory = exceptionAdapterFactory;
        }

        public short Order => 100;

        public void AfterSend(IResponseContext responseContext)
        {
        }

        public void BeforeSend(IRequestContext requestContext)
        {
        }

        public void OnException(IExceptionContext exceptionContext)
        {
            var context = (Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)exceptionContext.Context;
            IExceptionAdapter exceptionAdapter = exceptionAdapterFactory.GetAdapter(context.Exception);

            context.Result = new JsonResult(exceptionAdapter.Content)
            {
                StatusCode = (int)exceptionAdapter.HttpStatusCode
            };

            if (exceptionAdapter.ExtraHeaders != null)
            {
                foreach (var headerItem in exceptionAdapter.ExtraHeaders)
                {
                    context.HttpContext.Response.Headers.Add(headerItem.Key, headerItem.Value);
                }
            }
        }
    }
}
