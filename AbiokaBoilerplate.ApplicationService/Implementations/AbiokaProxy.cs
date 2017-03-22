using System;
using System.Net;

namespace AbiokaBoilerplate.ApplicationService.Implementations
{
    internal class AbiokaProxy : IWebProxy
    {
        public AbiokaProxy(Uri proxyUri) {
            ProxyUri = proxyUri;
        }

        public Uri ProxyUri { get; private set; }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination) {
            return ProxyUri;
        }

        public bool IsBypassed(Uri host) {
            return false;
        }
    }
}
