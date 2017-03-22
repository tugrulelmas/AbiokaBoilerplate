using System;
using System.Collections.Generic;
using System.Text;
using AbiokaBoilerplate.Infrastructure.Common.Authentication;

namespace AbiokaBoilerplate.Infrastructure.Common.Helper
{
    public class ContextHolder : ICurrentContext
    {
        // TODO: implement
        public ICurrentContext Current => null;

        public ICustomPrincipal Principal { get; set; }

        public ActionType ActionType { get; set; }

        public string IP { get; set; }
    }
}
