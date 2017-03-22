using System;

namespace AbiokaBoilerplate.Infrastructure.Common.Dynamic
{
    public class ExceptionContext : IExceptionContext
    {
        public ExceptionContext(object context) {
            Context = context;
        }

        public object Context { get; }
    }
}
