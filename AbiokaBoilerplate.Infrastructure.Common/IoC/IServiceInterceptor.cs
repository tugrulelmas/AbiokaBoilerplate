﻿namespace AbiokaBoilerplate.Infrastructure.Common.IoC
{
    public interface IServiceInterceptor
    {
        int Order { get; }

        void BeforeProceed(IInvocationContext context);
    }
}
