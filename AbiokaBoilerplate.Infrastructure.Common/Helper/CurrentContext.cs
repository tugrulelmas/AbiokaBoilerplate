using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using System;

namespace AbiokaBoilerplate.Infrastructure.Common.Helper
{
    public class CurrentContext : ICurrentContext
    {
        private static readonly string contextName = "_AbiokaContext_";
        private readonly IContextHolder contextHolder;

        public CurrentContext(IContextHolder contextHolder) {
            this.contextHolder = contextHolder;
            contextHolder.SetData(contextName, this);
        }

        public ICurrentContext Current {
            get {
                object obj = contextHolder.GetData(contextName);
                if (obj == null) {
                    throw new Exception("Abioka context is empty");
                }
                return (CurrentContext)obj;
            }
        }

        public string IP { get; set; }

        public ICustomPrincipal Principal { get; set; }

        public ActionType ActionType { get; set; }
    }
}