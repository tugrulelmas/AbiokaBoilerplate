using System;
using System.Reflection;

namespace AbiokaBoilerplate.Infrastructure.Common.IoC
{
    public class InvocationContext : IInvocationContext
    {
        public object[] Arguments { get; set; }

        public Type[] GenericArguments { get; set; }

        public object InvocationTarget { get; set; }

        public MethodInfo Method { get; set; }

        public MethodInfo MethodInvocationTarget { get; set; }

        public object Proxy { get; set; }

        public object ReturnValue { get; set; }

        public Type TargetType { get; set; }
    }

}