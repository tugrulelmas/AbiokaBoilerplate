﻿using System.Net.Http;

namespace AbiokaBoilerplate.Infrastructure.Common.Dynamic
{
    public class RequestContext : IRequestContext
    {
        public RequestContext(HttpRequestMessage request) {
            Request = request;
        }

        public HttpRequestMessage Request { get; }
    }
}
